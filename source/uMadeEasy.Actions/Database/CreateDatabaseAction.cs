// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.Database
{
    /// <summary>
    /// Creates and restores the database for the newly created project
    /// </summary>
    public class CreateDatabaseAction : IGeneratorAction
    {
        private const string DatabaseNameFormat = "{0}{1}";
        private const string DatabaseCreateStatement = "CREATE DATABASE [{0}];";
        private const string DatabaseDropStatement = "DROP DATABASE [{0}];";
        private const string DatabaseOsqlCommand = "-S {0} -U {1} -P {2} ";

        public string ActionName
        {
            get { return "Create database"; }
        }

        public string RollBackMessage
        {
            get { return "The new database will be removed."; }
        }

        public bool AllowContinueAfterError
        {
            get { return false; }
        }

        public bool SupportsRollback
        {
            get { return true; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var location = values.GetString("DestinationFolder");
            var connectionString = parameters["connectionString"];
            var databasePrefix = parameters["databasePrefix"];
            var databaseScriptName = parameters["databaseScriptName"];
            var databaseServerName = parameters["databaseServerName"];
            var databaseUsername = parameters["databaseUsername"];
            var databasePassword = parameters["databasePassword"];

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand(string.Format(DatabaseCreateStatement, string.Format(DatabaseNameFormat, databasePrefix, arguments.Name))
                                                                    , sqlConnection))
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
            }

            var databaseScriptFilePath = System.IO.Path.Combine(location, databaseScriptName);
            var osqlCommand = string.Concat(string.Format(DatabaseOsqlCommand, databaseServerName, databaseUsername, databasePassword), " -d ", string.Format(DatabaseNameFormat, databasePrefix, arguments.Name),
                                                " -i \"", databaseScriptFilePath, "\"");

            using (var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Arguments = osqlCommand,
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = false,
                    FileName = "osql.exe"
                }
            })
            {
                process.Start();
                process.WaitForExit(300 * 1000);

                if (!process.HasExited)
                {
                    process.Kill();
                    throw new Exception("OSQL process was niet klaar binnen 5 minuten");
                }
            }

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            var connectionString = parameters["connectionString"];
            var databasePrefix = parameters["databasePrefix"];

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = new SqlCommand(string.Format(DatabaseDropStatement, string.Format(DatabaseNameFormat, databasePrefix, arguments.Name)),
                                                       sqlConnection))
                {
                    sqlCommand.Connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Connection.Close();
                }
            }

            return new GeneratorActionResult(true, "");
        }

        public Type InputControl
        {
            get { return null; }
        }

        public IEnumerable<string> RequiredInputFields
        {
            get { yield return "DestinationFolder"; }
        }
    }
}