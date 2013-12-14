// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Lucrasoft.uMadeEasy.Core.Generator;
using Newtonsoft.Json;

namespace Lucrasoft.uMadeEasy.Actions.Git
{
    /// <summary>
    /// Gets a GitLab clone URL
    /// </summary>
    public class GetGitlabCloneUrlAction : IGeneratorAction
    {
        private string url = "";
        private string token = "";

        public string ActionName
        {
            get { return "Get GitLab clone url"; }
        }

        public string RollBackMessage
        {
            get { return ""; }
        }

        public bool AllowContinueAfterError
        {
            get { return false; }
        }

        public bool SupportsRollback
        {
            get { return false; }
        }

        public GeneratorActionResult ExecuteAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            url = parameters["url"];
            token = parameters["token"];

            try
            {
                values.Add("CloneUrl", GetCloneUrl(values.GetString("projectId")));
            }
            catch (Exception ex)
            {
                return new GeneratorActionResult(false, ex.Message);
            }
            
            return new GeneratorActionResult(true, "");
        }

        public string GetCloneUrl(string projectId)
        {
            var project = JsonConvert.DeserializeObject<dynamic>(Get(url + "projects/" + projectId, token));

            return project.http_url_to_repo.ToString() as string;
        }

        private static string Get(string url, string token)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers["PRIVATE-TOKEN"] = token;

            var response = request.GetResponse();
            using (var responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return null; }
        }

        public IEnumerable<string> RequiredInputFields
        {
            get
            {
                yield return "DestinationFolder";
            }
        }
    }
}