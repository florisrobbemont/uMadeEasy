// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Writes the template's xml file
    /// </summary>
    public static class TemplateWriter
    {
        /// <summary>
        /// Writes the template's configuration file to disk
        /// </summary>
        /// <param name="templateInformation">The template information to be written</param>
        /// <param name="xmlFile">The full path to the XML file</param>
        /// <remarks>If the XML already exists, it will be removed.</remarks>
        public static void WriteTemplateFile(TemplateInformation templateInformation, string xmlFile)
        {
            if (templateInformation == null)
                throw new ArgumentNullException("templateInformation");

            if (string.IsNullOrEmpty(xmlFile))
                throw new ArgumentNullException("xmlFile");

            if (File.Exists(xmlFile))
                File.Delete(xmlFile);

            var newDocument = GenerateXmlDocument(templateInformation);
            newDocument.Save(xmlFile);
        }

        private static XDocument GenerateXmlDocument(TemplateInformation templateInformation)
        {
            return
                new XDocument(
                    new XElement("template",
                        new XElement("name", templateInformation.DisplayName),
                        new XElement("extensions",
                                        GenerateExtensionList("renameExtensions", templateInformation.RenameExtensions, true),
                                        GenerateExtensionList("excludeExtensions", templateInformation.ExcludeExtensions, false),
                                        GenerateExtensionList("removeExtensions", templateInformation.RenameExtensions, false)
                                    ),
                        new XElement("guids",
                                        templateInformation.Guids.Select(x => new XElement("guid", x))
                                    ),
                        new XElement("renameWords",
                                        templateInformation.Words.Select(x => new XElement("word", x))
                                    ),
                        new XElement("actions",
                                        templateInformation.Actions.Select(GenerateAction)
                                    )
                    )
                );
        }

        private static XElement GenerateExtensionList(string name, IEnumerable<XmlExtension> extensions, bool includeUtf)
        {
            if (includeUtf)
                return new XElement(name, extensions.Select(x => new XElement("ext", x.FileExtension, new XAttribute("utf", ConvertXmlBoolean(x.UseUtf8Encoding)))));
            else
                return new XElement(name, extensions.Select(x => new XElement("ext", x.FileExtension)));
        }

        private static XElement GenerateAction(XmlGeneratorAction action)
        {
            return new XElement("action",
                                    new XElement("type", action.ActionType),
                                    new XElement("parameters",
                                            action.Parameters.Select(x => new XElement("parameter", x.Value, new XAttribute("name", x.Key)))
                                        )
                );
        }

        private static string ConvertXmlBoolean(bool value)
        {
            return value ? "1" : "0";
        }
    }
}