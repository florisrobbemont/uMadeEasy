﻿// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core;
using Lucrasoft.uMadeEasy.Core.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.ProjectGenerator
{
    internal static class Program
    {
        /// <summary>
        /// Gets the Core DI container object
        /// </summary>
        internal static DependencyInjector Injector { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Prepare();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void Prepare()
        {
            Injector = new DependencyInjector(new string[]
                                              {
                                                  IoHelpers.GetStartupPath(),
                                                  IoHelpers.GetActionPath()
                                              });

            var templatePath = Path.Combine(IoHelpers.GetStartupPath(), "Templates");
            if (!Directory.Exists(templatePath))
                Directory.CreateDirectory(templatePath);
        }
    }
}