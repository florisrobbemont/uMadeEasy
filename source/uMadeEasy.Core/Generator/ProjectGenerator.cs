using Lucrasoft.uMadeEasy.Core.InputFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Generates a new project based on <c>GeneratorArguments</c>
    /// </summary>
    public sealed class ProjectGenerator
    {
        /// <summary>
        /// Generates a new project.
        /// </summary>
        /// <param name="arguments">The arguments needed to generate the project.</param>
        /// <param name="inputValues">The values from the input controls</param>
        /// <returns>The outcome of the operation</returns>
        public GeneratorResult Generate(GeneratorArguments arguments, ActionInputValues inputValues)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            if (arguments.TemplateInformation == null)
                throw new InvalidOperationException("No template information in Generate method.");

            return GenerateInternal(arguments, inputValues);
        }

        private GeneratorResult GenerateInternal(GeneratorArguments arguments, ActionInputValues inputValues)
        {
            var generatorResults = new GeneratorResult();

            foreach (var action in arguments.TemplateInformation.Actions)
            {
                var actionClass = ReflectionHelpers.CreateTypeInstance<IGeneratorAction>(action.ActionType);

                if (actionClass == null)
                    throw new InvalidOperationException("Could not create instance of action type");

                var actionResults = actionClass.ExecuteAction(arguments, inputValues, action.Parameters);

                if (!actionResults.OperationSuccesfull)
                {
                    // Rollback
                }
            }

            return generatorResults;
        }
    }
}