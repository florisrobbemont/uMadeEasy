// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.Core
{
    /// <summary>
    /// Contains helpers methods for IO actions.
    /// </summary>
    public static class IoHelpers
    {
        /// <summary>
        /// Gets the starup path for the application (where the application is run from).
        /// </summary>
        public static string GetStartupPath()
        {
            return Application.StartupPath;
        }

        /// <summary>
        /// Gets the template path.
        /// </summary>
        /// <returns></returns>
        public static string GetTemplatePath()
        {
            return Path.Combine(GetStartupPath(), "Templates");
        }

        /// <summary>
        /// Gets the action path.
        /// </summary>
        /// <returns></returns>
        public static string GetActionPath()
        {
            return Path.Combine(GetStartupPath(), "Actions");
        }
    }
}