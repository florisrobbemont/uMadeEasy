using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Represents a configured action from the template's XML
    /// </summary>
    public class XmlAction
    {
        /// <summary>
        /// Gets or sets the action typename
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets the action's parameters
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        public XmlAction() { }

        public XmlAction(string actionType, Dictionary<string, string> parameters)
        {
            ActionType = actionType;
            Parameters = parameters;
        }
    }
}
