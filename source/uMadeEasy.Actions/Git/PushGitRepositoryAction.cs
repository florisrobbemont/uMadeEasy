// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Lucrasoft.uMadeEasy.Core.Generator;

namespace Lucrasoft.uMadeEasy.Actions.Git
{
    /// <summary>
    /// Pushes a git repository
    /// </summary>
    public class PushGitRepositoryAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Push Git repository"; }
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
            var location = values.GetString("DestinationFolder");
            
            try
            {
                GitCommandRunner.RunCommand("config --global http.postBuffer 1548576000", location);
                GitCommandRunner.RunCommand("push --all origin", location);
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
            get { return null; }
        }

        public virtual IEnumerable<string> RequiredInputFields
        {
            get { yield return "DestinationFolder"; }
        }
    }
}