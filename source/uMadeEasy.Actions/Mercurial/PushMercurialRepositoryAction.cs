// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.Generator;
using Mercurial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.Mercurial
{
    /// <summary>
    /// Pushes the newly created Mercurial repository to the remote server (committing all changes to the live source control server).
    /// </summary>
    public class PushMercurialRepositoryAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Push Mercurial repository"; }
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

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var location = values.GetString("DestinationFolder");

            var repo = new Repository(location);
            repo.Push(new PushCommand().WithTimeout(60 * 60));

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return null; }
        }

        public IEnumerable<string> RequiredInputFields
        {
            get { yield return "DestinationFolder"; }
        }
    }
}