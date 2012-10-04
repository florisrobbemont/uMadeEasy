using Lucrasoft.uMadeEasy.Core;
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
            Injector = new DependencyInjector(new string[]
                                                  {
                                                      Path.Combine(IoHelpers.GetStartupPath(), ""),
                                                      Path.Combine(IoHelpers.GetStartupPath(), "Actions")
                                                  });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}