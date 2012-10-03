using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Contains information about a template.
    /// </summary>
    [Serializable]
    public sealed class TemplateInformation
    {
        /// <summary>
        /// Gets of sets the display name of the template.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets of sets the file path of the template.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets all the extensions that should be renamed
        /// </summary>
        public IEnumerable<XmlExtension> RenameExtensions { get; set; }

        /// <summary>
        /// Gets or sets all the extensions that should be excluded from renaming
        /// (but should be copied to the new directory)
        /// </summary>
        public IEnumerable<XmlExtension> ExcludeExtensions { get; set; }

        /// <summary>
        /// Gets or sets all the extensions that should NOT be copied to the directory
        /// </summary>
        public IEnumerable<XmlExtension> RemoveExtensions { get; set; }

        /// <summary>
        /// Gets or sets the actions associated with this template
        /// </summary>
        public IEnumerable<XmlGeneratorAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the words that should be renamed, and their new values
        /// </summary>
        public IEnumerable<string> Guids { get; set; }

        /// <summary>
        /// Gets or sets the words that should be renamed, and their new values
        /// </summary>
        public Dictionary<string, string> RenameWords { get; private set; }

        public TemplateInformation()
        {
            RenameWords = new Dictionary<string, string>();
        }
    }
}