﻿// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

namespace Lucrasoft.uMadeEasy.Core.Logging
{
    /// <summary>
    /// Defines all logtypes supported
    /// </summary>
    public enum LogTypes
    {
        /// <summary>
        /// Debug logging type: will only be logged when application is in Debug mode
        /// </summary>
        Debug = -1,

        /// <summary>
        /// Inserts an info message into the current log providers
        /// </summary>
        Info = 0,

        /// <summary>
        /// Inserts a trace message into the current log provider
        /// </summary>
        Trace = 1,

        /// <summary>
        /// Inserts a warning message into the current log providers
        /// </summary>
        Warn = 2,

        /// <summary>
        /// Inserts an error message into the current log providers
        /// </summary>
        Error = 3,

        /// <summary>
        /// Inserts a fatal mesage into the current log providers. This logtype will also gather as much information as possible about the current application state
        /// </summary>
        Fatal = 4
    }
}