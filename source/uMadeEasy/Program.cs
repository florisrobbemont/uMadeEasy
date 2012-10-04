﻿using Lucrasoft.uMadeEasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy
{
    internal static class Program
    {
        /// <summary>
        /// Gets the Core DI container object
        /// </summary>
        internal static Core.DependencyInjector Injector { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Injector = new DependencyInjector(null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}