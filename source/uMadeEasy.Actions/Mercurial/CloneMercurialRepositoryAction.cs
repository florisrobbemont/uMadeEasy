using Lucrasoft.uMadeEasy.Actions.InputFields;
using Lucrasoft.uMadeEasy.Core.Generator;
using Mercurial;
using Mercurial.Gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.Mercurial
{
    /// <summary>
    /// Clones a Mercurial repository from a clone URL
    /// </summary>
    public class CloneMercurialRepositoryAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Clone Mercurial repository"; }
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
            var cloneUrl = values.GetString("MercurialCloneUrl");

            if (Directory.Exists(location))
            {
                var repo = new Repository(location);
                repo.CloneGui(new CloneGuiCommand { Source = cloneUrl, WaitForGuiToClose = true });
            }
            else
            {
                return new GeneratorActionResult(false, "Directory doesn't exist!");
            }

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return typeof(CloneMercurialRepositoryField); }
        }
    }
}