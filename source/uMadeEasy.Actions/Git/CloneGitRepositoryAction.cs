// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Lucrasoft.uMadeEasy.Actions.InputFields;
using Lucrasoft.uMadeEasy.Core.Generator;

namespace Lucrasoft.uMadeEasy.Actions.Git
{
    /// <summary>
    /// Clones a Git project
    /// </summary>
    public class CloneGitRepositoryAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Clone Git repository"; }
        }

        public string RollBackMessage
        {
            get { return ""; }
        }

        public bool AllowContinueAfterError
        {
            get { return false; }
        }

        public bool SupportsRollback
        {
            get { return false; }
        }

        public virtual GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var cloneUrl = values.GetString("CloneUrl");
            var location = values.GetString("DestinationFolder");

            try
            {
                GitCommandRunner.RunCommand(string.Format("clone {0} ./", cloneUrl), location);
            }
            catch (Exception ex)
            {
                return new GeneratorActionResult(false, ex.Message);
            }
            
            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public virtual Type InputControl
        {
            get { return typeof(CloneRepositoryField); }
        }

        public virtual IEnumerable<string> RequiredInputFields
        {
            get
            {
                yield return "DestinationFolder";
                yield return "CloneUrl";
            }
        }
    }
}