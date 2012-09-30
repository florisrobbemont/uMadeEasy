using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Reads the template's configuration.
    /// </summary>
    public static class TemplateReader
    {
        /// <summary>
        /// Reads the template archive file and returns its information.
        /// </summary>
        /// <param name="filePath">The full path to the template archive file.</param>
        public static TemplateInformation ReadTemplate(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            return ParseXmlDocument(XDocument.Load(filePath));
        }

        private static TemplateInformation ParseXmlDocument(XDocument document)
        {
            var templateInformation = new TemplateInformation();
            var template = (from x in document.Elements("template") select x).FirstOrDefault();

            return ReadXmlDocument(templateInformation, template);
        }

        private static TemplateInformation ReadXmlDocument(TemplateInformation templateInformation, XElement template)
        {
            var nameElement = template.Element("name");
            if (nameElement != null)
                templateInformation.DisplayName = nameElement.Value;
            else
                throw new XmlSchemaException("Name element not present in template file");

            var extensionsElement = template.Element("extensions");
            if (extensionsElement != null)
            {
                templateInformation.RenameExtensions = ReadExtenstionList(extensionsElement.Element("renameExtensions"));
                templateInformation.ExcludeExtensions = ReadExtenstionList(extensionsElement.Element("excludeExtensions"));
                templateInformation.RemoveExtensions = ReadExtenstionList(extensionsElement.Element("removeExtensions"));
            }
            else
                throw new XmlSchemaException("Extensions element not present in template file");

            var actionsElement = template.Element("actions");
            if (actionsElement != null)
            {
                templateInformation.Actions = ReadActionsList(actionsElement).ToList();
            }
            else
                throw new XmlSchemaException("Actions element not present in template file");

            var guidsElement = template.Element("guids");
            if (guidsElement != null)
            {
                foreach(var guid in guidsElement.Descendants("guid"))
                    templateInformation.RenameWords.Add(guid.Value, Guid.NewGuid().ToString());
            }

            return templateInformation;
        }

        private static IEnumerable<XmlExtension> ReadExtenstionList(XElement extensionList)
        {
            if (extensionList == null)
                yield break;

            foreach(var extension in extensionList.Descendants("ext"))
            {
                var xmlExtension = new XmlExtension(extension.Value, false);
                var utfAttribute = extension.Attribute("utf");

                if (utfAttribute != null)
                    xmlExtension.UseUtf8Encoding = ParseXmlBoolean(utfAttribute.Value);

                yield return xmlExtension;
            }
        }

        private static IEnumerable<XmlAction> ReadActionsList(XElement actionsList)
        {
            if (actionsList == null)
                yield break;

            foreach (var action in actionsList.Descendants("action"))
            {
                var xmlAction = new XmlAction();

                var typeElement = action.Element("type");
                if (typeElement != null)
                    xmlAction.ActionType = typeElement.Value;
                else
                    throw new XmlSchemaException("Type element not present in template <action> file");

                xmlAction.Parameters = ReadActionParameterList(action.Element("parameters"));

                yield return xmlAction;
            }
        }

        private static Dictionary<string, string> ReadActionParameterList(XElement parameterList)
        {
            var parameters = new Dictionary<string, string>();

            if (parameterList == null)
                return parameters;

            foreach (var parameter in parameterList.Descendants("parameter"))
            {
                var nameAttribute = parameter.Attribute("name");

                parameters.Add((nameAttribute == null) ? "" : nameAttribute.Value,
                               parameter.Value);
            }

            return parameters;
        }

        private static bool ParseXmlBoolean(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return value == "1" | value == "true";
        }
    }
}