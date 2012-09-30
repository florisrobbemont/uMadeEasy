using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Represents a file extension
    /// </summary>
    public class XmlExtension
    {
        /// <summary>
        /// Gets or sets the file extensions (including the .)
        /// </summary>
        public string FileExtension { get; set; }
        
        /// <summary>
        /// Gets or sets wether this extension should be handled as UTF-8 encoding
        /// </summary>
        public bool UseUtf8Encoding { get; set; }

        public XmlExtension() { }

        public XmlExtension(string extension, bool useUtf8Encoding)
        {
            FileExtension = extension;
            UseUtf8Encoding = useUtf8Encoding;
        }
    }
}
