using Lucrasoft.uMadeEasy.Actions.InputFields;
using Lucrasoft.uMadeEasy.Core.Generator;
using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.General
{
    /// <summary>
    /// Registeres the new website into IIS
    /// </summary>
    public class RegisterIisAction : IGeneratorAction
    {
        public string ActionName
        {
            get { return "Register IIS"; }
        }

        public string RollBackMessage
        {
            get { return "The newly create website and application pool will be removed from IIS."; }
        }

        public bool AllowContinueAfterError
        {
            get { return true; }
        }

        public bool SupportsRollback
        {
            get { return true; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var registerIis = values.GetBool("RegisterIis");
            var hosttName = values.GetString("HostName");
            var location = values.GetString("DestinationFolder");
            var umbracoRelativePath = parameters["umbracoRelativePath"];

            if (registerIis)
            {
                // Get IIS reference
                var serverManager = new ServerManager();

                // Create new AppPool or use existing
                var appPool = serverManager.ApplicationPools.FirstOrDefault(x => x.Name == arguments.Name) ??
                              serverManager.ApplicationPools.Add(arguments.Name);

                // Umbraco is .NET 4.0
                appPool.ManagedRuntimeVersion = "v4.0";

                // Add site and configure
                var physicalPath = System.IO.Path.Combine(location, umbracoRelativePath);
                serverManager.Sites.Add(arguments.Name, physicalPath, 80);

                serverManager.Sites[arguments.Name].ApplicationDefaults.ApplicationPoolName = arguments.Name;
                serverManager.Sites[arguments.Name].Bindings.Clear();
                serverManager.Sites[arguments.Name].Bindings.Add("*:80:" + hosttName, "http");
                serverManager.Sites[arguments.Name].ServerAutoStart = true;

                // Commit
                serverManager.CommitChanges();
            }

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var registerIis = values.GetBool("RegisterIis");

            if (registerIis)
            {
                // Get IIS reference
                var serverManager = new ServerManager();

                // Create new AppPool or use existing
                var appPool = serverManager.ApplicationPools.FirstOrDefault(x => x.Name == arguments.Name);

                if (appPool != null)
                    serverManager.ApplicationPools.Remove(appPool);

                // Commit
                serverManager.CommitChanges();
            }

            return new GeneratorActionResult(true, "");
        }

        public Type InputControl
        {
            get { return typeof(RegisterIisField); }
        }
    }
}