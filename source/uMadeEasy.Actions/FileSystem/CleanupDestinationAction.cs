// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.FileSystem
{
    /// <summary>
    /// Removes all files created by the generator before submitting it into source control
    /// </summary>
    public class CleanupDestinationAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Cleanup destination"; }
        }

        public string RollBackMessage
        {
            get { return ""; }
        }

        public bool AllowContinueAfterError
        {
            get { return true; }
        }

        public bool SupportsRollback
        {
            get { return false; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var location = values.GetString("DestinationFolder");

            RemoveFile(Path.Combine(location, "Template.xml"));

            return new GeneratorActionResult(true, "");
        }

        private static void RemoveFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
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