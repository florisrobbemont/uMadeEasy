using Lucrasoft.uMadeEasy.Actions.ActionHelpers;
using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.General
{
    /// <summary>
    /// Copies all files to the new location and performes the renames
    /// </summary>
    public class RenameTemplateSiteAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Rename template site"; }
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

            var copier = new DirectoryRenamerCopier(arguments.TemplateInformation.TemplatePath, location)
                             {
                                 ExcludeExtensions = arguments.TemplateInformation.ExcludeExtensions.Select(x => x.FileExtension).ToList(),
                                 RemoveExtensions = arguments.TemplateInformation.RemoveExtensions.Select(x => x.FileExtension).ToList(),
                                 RenameExtensions = arguments.TemplateInformation.RenameExtensions.Select(x => x.FileExtension).ToList(),
                                 UtfExtensions = arguments.TemplateInformation.RenameExtensions.Where(x => x.UseUtf8Encoding).Select(x => x.FileExtension).ToList(),
                                 RenameWords = arguments.TemplateInformation.Renames
                             };

            if (copier.StartRenaming())
                return new GeneratorActionResult(true, "");
            else
                return new GeneratorActionResult(false, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return null; }
        }
    }
}