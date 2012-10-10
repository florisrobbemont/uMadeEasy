// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

namespace Lucrasoft.uMadeEasy.Core.Logging
{
    /// <summary>
    /// Provides logging functionality
    /// </summary>
    public sealed class Logger
    {
        #region "Singleton"

        /// <summary>
        /// Gets the current instance of the Logger class
        /// </summary>
        internal static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                }

                return instance;
            }
        }

        private NLog.Logger logger;
        private static volatile Logger instance;
        private static readonly object InstanceLock = new object();

        private Logger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        #endregion "Singleton"

        private static NLog.LogLevel ConvertLogLevel(LogTypes logType)
        {
            switch (logType)
            {
                case LogTypes.Debug:
                    return NLog.LogLevel.Debug;
                case LogTypes.Error:
                    return NLog.LogLevel.Error;
                case LogTypes.Fatal:
                    return NLog.LogLevel.Fatal;
                case LogTypes.Info:
                    return NLog.LogLevel.Info;
                case LogTypes.Trace:
                    return NLog.LogLevel.Trace;
                case LogTypes.Warn:
                    return NLog.LogLevel.Warn;
                default:
                    return NLog.LogLevel.Off;
            }
        }

        /// <summary>
        /// Writes the diagnostic message for the default level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        public void Log(string message)
        {
            logger.Log(NLog.LogLevel.Info, message);
        }

        /// <summary>
        /// Writes the diagnostic message for the specified level
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="type">The log type.</param>
        public void Log(string message, LogTypes type)
        {
            logger.Log(ConvertLogLevel(type), message);
        }

        /// <summary>
        /// Writes the diagnostic message at the Info level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="args">Additional formatting parameters</param>
        public void Info(string message, params object[] args)
        {
            logger.Log(NLog.LogLevel.Info, message, args);
        }

        /// <summary>
        /// Writes the diagnostic message at the Debug level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="args">Additional formatting parameters</param>
        public void Debug(string message, params object[] args)
        {
            logger.Log(NLog.LogLevel.Debug, message, args);
        }

        /// <summary>
        /// Writes the diagnostic message at the Warning level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="args">Additional formatting parameters</param>
        public void Warn(string message, params object[] args)
        {
            logger.Log(NLog.LogLevel.Warn, message, args);
        }

        /// <summary>
        /// Writes the diagnostic message at the Error level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="args">Additional formatting parameters</param>
        public void Error(string message, params object[] args)
        {
            logger.Log(NLog.LogLevel.Error, message, args);
        }

        /// <summary>
        /// Writes the diagnostic message at the Fatal level.
        /// </summary>
        /// <param name="message">A <see langword="string" /> to be written.</param>
        /// <param name="args">Additional formatting parameters</param>
        public void Fatal(string message, params object[] args)
        {
            logger.Log(NLog.LogLevel.Fatal, message, args);
        }

        public void Dispose()
        {
            logger.Factory.Dispose();
            logger = null;
        }
    }
}