using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Actions
{
    /// <summary>
    /// Represents the list of actions performed by the generator.
    /// </summary>
    [Serializable]
    public class ActionList : List<string>
    {
        /// <summary>
        /// Adds an action to the list.
        /// </summary>
        /// <param name="actionType">The action to add.</param>
        public void AddAction(Type actionType)
        {
            Add(actionType.AssemblyQualifiedName);
        }

        /// <summary>
        /// Adds an action to the list.
        /// </summary>
        /// <param name="action">The action to add.</param>
        public void AddAction(IAction action)
        {
            Add(action.GetType().AssemblyQualifiedName);
        }

        /// <summary>
        /// Saves the contents of the ActionList to a specific path.
        /// </summary>
        /// <param name="filePath">The path to save the ActionList to</param>
        /// <remarks>This method will overwrite any existing ActionList file</remarks>
        public void Save(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, Serializers.XmlSerializers.SerializeClassToXml(this), Encoding.UTF8);
        }

        /// <summary>
        /// Returns a new instance of the <see cref="ActionList"/> based of the contents of a file
        /// </summary>
        /// <param name="filePath">The full path of the actionlist file</param>
        public static ActionList GetFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("filePath");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Could not find the actionlist XML configuration file",
                                                filePath);

            return DeserializeActionFile(filePath);
        }

        private static ActionList DeserializeActionFile(string filePath)
        {
            var contents = File.ReadAllText(filePath, Encoding.UTF8);

            return Serializers.XmlSerializers.SerializeXmlToClass<ActionList>(contents);
        }
    }
}