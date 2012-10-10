// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.InputFields;
using Lucrasoft.uMadeEasy.Core.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Generates a new project based on <c>GeneratorArguments</c>.
    /// </summary>
    public sealed class ProjectGenerator
    {
        #region "Delegates"

        /// <summary>
        /// Reports progress for all generator actions.
        /// </summary>
        /// <param name="percentage">The total percentage of the progress.</param>
        /// <param name="message">The message associated with this progress report.</param>
        public delegate void ReportProgressDelegate(int percentage, string message);

        /// <summary>
        /// Delegate to ask the user if an action should be rolled back or not.
        /// </summary>
        /// <param name="rollbackName">The name of the action to rollback.</param>
        /// <param name="rollbackMessage">The message from the action.</param>
        /// <param name="rollbackAllowed">(out) Wether the action should be rolled back (user input)</param>
        public delegate void ReportRollBackDelegate(string rollbackName, string rollbackMessage, out bool rollbackAllowed);

        #endregion "Delegates"

        private GeneratorArguments arguments;
        private ReportProgressDelegate progress;
        private ReportRollBackDelegate rollback;
        private Func<bool> continueAllowed;

        /// <summary>
        /// Generates a new project.
        /// </summary>
        /// <param name="genatorArguments">The arguments needed to generate the project.</param>
        /// <param name="progressDelegate">Reports progress for all generator actions.</param>
        /// <param name="rollbackDelegate">Delegate to ask the user if an action should be rolled back or not.</param>
        /// <param name="continueAllowedFunc">Delegate to ask the main form if we are allowed to continue.</param>
        /// <returns>The outcome of the operation.</returns>
        public GeneratorResult Generate(GeneratorArguments genatorArguments, ReportProgressDelegate progressDelegate,
                                        ReportRollBackDelegate rollbackDelegate, Func<bool> continueAllowedFunc)
        {
            if (genatorArguments == null)
                throw new ArgumentNullException("genatorArguments");

            if (progressDelegate == null)
                throw new ArgumentNullException("progressDelegate");

            if (rollbackDelegate == null)
                throw new ArgumentNullException("rollbackDelegate");

            if (continueAllowedFunc == null)
                throw new ArgumentNullException("continueAllowedFunc");

            if (genatorArguments.TemplateInformation == null)
                throw new InvalidOperationException("No template information in Generate method.");

            arguments = genatorArguments;
            progress = progressDelegate;
            rollback = rollbackDelegate;
            continueAllowed = continueAllowedFunc;

            progressDelegate(0, "Starting generator");

            return GenerateInternal();
        }

        private GeneratorResult GenerateInternal()
        {
            var generatorResults = new GeneratorResult();
            var actions = arguments.TemplateInformation.Actions.ToList();
            var taskCounter = 0;

            foreach (var action in actions)
            {
                var allowContinue = true;
                var actionClass = GetActionFromTypeName(action.ActionType);

                progress((int)((100 / (double)actions.Count) * taskCounter), "Executing action: " + actionClass.ActionName);

                GeneratorActionResult actionResults = null;

                try
                {
                    actionResults = actionClass.ExecuteAction(arguments, arguments.InputValues, action.Parameters);
                }
                catch (Exception ex)
                {
                    allowContinue = false;
                    progress(-1, string.Format("Action '{0}' failed with message: {1}", actionClass.ActionName, ex.Message));
                }

                taskCounter++;

                if (allowContinue && (actionResults == null || actionResults.OperationSuccesfull))
                {
                    if (!continueAllowed.Invoke())
                    {
                        generatorResults.LastAction = actionClass;
                        generatorResults.OperationSuccesfull = false;

                        Rollback(actions, actionClass);
                        return generatorResults;
                    }

                    continue;
                }

                if (actionClass.AllowContinueAfterError)
                    progress(-1, string.Format("Action '{0}' failed, but is allowed to continue.", actionClass.ActionName));
                else
                {
                    generatorResults.LastAction = actionClass;
                    generatorResults.OperationSuccesfull = false;

                    Rollback(actions, actionClass);
                    return generatorResults;
                }
            }

            // Complete report
            progress(100, "");

            generatorResults.OperationSuccesfull = true;
            return generatorResults;
        }

        private void Rollback(List<XmlGeneratorAction> actions, IGeneratorAction lastAction)
        {
            var rollbackList = new Dictionary<IGeneratorAction, XmlGeneratorAction>();

            actions.Reverse();

            foreach (var action in actions)
            {
                var actionClass = GetActionFromTypeName(action.ActionType);

                // If the actionname matched the last executed action (the one that failed),
                // or we already added a rollbackaction, we are allowed to add to the rollback list
                if (actionClass.ActionName == lastAction.ActionName || rollbackList.Count > 0)
                {
                    // From this point we add to our rollback list
                    rollbackList.Add(actionClass, action);
                }
            }

            foreach (var rollbackAction in rollbackList)
            {
                // Only rollback when the item supports it
                if (!rollbackAction.Key.SupportsRollback)
                    continue;

                var userAllowsRollback = false;

                // Ask the user if the rollback is allowed. Sometime not all actions have to be rolled back
                rollback(rollbackAction.Key.ActionName, rollbackAction.Key.RollBackMessage, out userAllowsRollback);

                if (userAllowsRollback)
                {
                    progress(-1, "Rolling back action: " + rollbackAction.Key.ActionName);

                    try
                    {
                        rollbackAction.Key.RollbackAction(arguments, arguments.InputValues, rollbackAction.Value.Parameters);
                    }
                    catch (Exception ex)
                    {
                        progress(-1, string.Format("Exception in rollback '{0}': {1}", rollbackAction.Key.ActionName, ex.Message));
                    }
                }
            }
        }

        private static IGeneratorAction GetActionFromTypeName(string typeName)
        {
            var actionClass = ReflectionHelpers.CreateTypeInstance<IGeneratorAction>(typeName);

            if (actionClass == null)
                throw new InvalidOperationException("Could not create instance of action type");

            return actionClass;
        }
    }
}