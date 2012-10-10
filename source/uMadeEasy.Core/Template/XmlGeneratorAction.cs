// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Core.Template
{
    /// <summary>
    /// Represents a configured action from the template's XML
    /// </summary>
    public class XmlGeneratorAction
    {
        /// <summary>
        /// Gets or sets the action typename
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets the action's parameters
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        public XmlGeneratorAction()
        {
        }

        public XmlGeneratorAction(string actionType, Dictionary<string, string> parameters)
        {
            ActionType = actionType;
            Parameters = parameters;
        }
    }
}