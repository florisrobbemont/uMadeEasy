// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.Generator;
using Lucrasoft.uMadeEasy.Core.InputFields;
using Lucrasoft.uMadeEasy.Core.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Generator
{
    /// <summary>
    /// Represents a single action performed by the generator.
    /// </summary>
    [InheritedExport]
    public interface IGeneratorAction
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
        GeneratorActionResult ExecuteAction(GeneratorArguments arguments, ActionInputValues values, Dictionary<string, string> parameters);

        /// <summary>
        /// Rolls back the action (if supported).
        /// </summary>
        GeneratorActionResult RollbackAction(GeneratorArguments arguments, ActionInputValues values, Dictionary<string, string> parameters);

        /// <summary>
        /// Gets the optional input control for this action.
        /// </summary>
        Type InputControl { get; }

        /// <summary>
        /// Gets the required fields for this action to work
        /// </summary>
        IEnumerable<string> RequiredInputFields { get; }
    }
}