using System.ComponentModel.Composition;
using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Actions
{
    /// <summary>
    /// Represents a single action performed by the WebsiteGenerator.
    /// </summary>
    [InheritedExport]
    public interface IAction
    {
        /// <summary>
        /// Gets the display name for this action.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Gets the message shown when this action is being rolled back.
        /// </summary>
        string RollBackMessage { get; }

        /// <summary>
        /// Gets wether to allow the process to continue if this action fails.
        /// </summary>
        bool AllowContinueAfterError { get; }

        /// <summary>
        /// Gets wheter this action support to be rolled back.
        /// </summary>
        bool SupportsRollback { get; }

        /// <summary>
        /// Executes the action.
        /// </summary>
        bool ExecuteAction(GeneratorArguments arguments);

        /// <summary>
        /// Rolls back the action (if supported)
        /// </summary>
        bool RollbackAction(GeneratorArguments arguments);
    }
}