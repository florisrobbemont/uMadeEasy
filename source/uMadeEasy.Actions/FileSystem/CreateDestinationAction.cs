// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.Generator;
using Lucrasoft.uMadeEasy.Core.InputFields;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lucrasoft.uMadeEasy.Actions.FileSystem
{
    public class CreateDestinationAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Create destination folder"; }
        }

        public string RollBackMessage
        {
            get { return "This rollback will permanently remove the newly created folder (even though there may already be files in it)."; }
        }

        public bool AllowContinueAfterError
        {
            get { return false; }
        }

        public bool SupportsRollback
        {
            get { return true; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, ActionInputValues values, Dictionary<string, string> parameters)
        {
            var location = values.GetString("DestinationFolder");

            if (Directory.Exists(location))
            {
                if (Directory.GetFiles(location).Length > 0 | Directory.GetDirectories(location).Length > 0)
                {
                    return new GeneratorActionResult(false, "Directory already exists and is not empty!");
                }
            }
            else
                Directory.CreateDirectory(location);

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, ActionInputValues values, Dictionary<string, string> parameters)
        {
            var location = values.GetString("DestinationFolder");

            if (Directory.Exists(location))
                Directory.Delete(location, true);

            return new GeneratorActionResult(true, "");
        }

        public Type InputControl
        {
            get { return typeof(InputFields.CreateDestinationField); }
        }

        public IEnumerable<string> RequiredInputFields
        {
            get { yield return "DestinationFolder"; }
        }
    }
}