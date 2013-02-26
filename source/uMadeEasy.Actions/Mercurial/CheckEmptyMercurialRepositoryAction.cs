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
    /// Commits all files from the newly generator project into Mercurial
    /// </summary>
    public class CheckEmptyMercurialRepositoryAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Checck empty Mercurial repository"; }
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
            if (repo.Manifest().Any())
            {
                return new GeneratorActionResult(false, "Repository has commits, and is therefor not empty!");
            }

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