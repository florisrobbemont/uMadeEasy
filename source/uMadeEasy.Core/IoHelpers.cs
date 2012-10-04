using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.Core
{
    /// <summary>
    /// Contains helpers methods for IO actions
    /// </summary>
    public static class IoHelpers
    {
        /// <summary>
        /// Gets the starup path for the application (where the application is run from)
        /// </summary>
        public static string GetStartupPath()
        {
            return Application.StartupPath;
        }
    }
}