using Lucrasoft.uMadeEasy.Actions.ActionHelpers;
using Lucrasoft.uMadeEasy.Actions.InputFields;
using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.FileSystem
{
    /// <summary>
    /// Adds a new entry in the hosts file
    /// </summary>
    public class EitHostFileAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Edit hosts file"; }
        }

        public string RollBackMessage
        {
            get { return "This will remove the newly created hosts entry."; }
        }

        public bool AllowContinueAfterError
        {
            get { return true; }
        }

        public bool SupportsRollback
        {
            get { return true; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var editHostsFile = values.GetBool("EditHostsFile");
            var hostName = values.GetString("HostName");

            if (editHostsFile)
            {
                // Create backup
                System.IO.File.WriteAllText(string.Concat(HostFileWriter.HostFilePath, ".backup"),
                                            System.IO.File.ReadAllText(HostFileWriter.HostFilePath, Encoding.UTF8),
                                            Encoding.UTF8);

                var hostEditor = new HostFileWriter();

                hostEditor.AddOrUpdateEntry(hostName, "127.0.0.1", String.Concat("Dev URL for ", arguments.Name));

                hostEditor.Save();
            }

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var editHostsFile = values.GetBool("EditHostsFile");

            if (editHostsFile)
            {
                if (System.IO.File.Exists(string.Concat(HostFileWriter.HostFilePath, ".backup")))
                {
                    // Replace backup
                    System.IO.File.WriteAllText(HostFileWriter.HostFilePath,
                                                System.IO.File.ReadAllText(string.Concat(HostFileWriter.HostFilePath, ".backup"), Encoding.UTF8),
                                                Encoding.UTF8);
                }
            }

            return new GeneratorActionResult(true, "");
        }

        public Type InputControl
        {
            get { return typeof(EditHostsFileField); }
        }

        public IEnumerable<string> RequiredInputFields
        {
            get
            {
                yield return "DestinationFolder";
                yield return "HostName";
            }
        }
    }
}