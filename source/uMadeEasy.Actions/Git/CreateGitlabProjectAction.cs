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
    /// Creates a GitLab project
    /// </summary>
    public class CreateGitlabProjectAction : IGeneratorAction
    {
        private string url = "";
        private string token = "";
        private string moveToken = "";

        public string ActionName
        {
            get { return "Create GitLab project"; }
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
            moveToken = parameters["moveToken"];

            try
            {
                var projectId = CreateProject(arguments.Name, "", "Websites");
                values.Add("projectId", projectId);
            }
            catch (Exception ex)
            {
                return new GeneratorActionResult(false, ex.Message);
            }
            
            return new GeneratorActionResult(true, "");
        }

        private int CreateProject(string projectName, string description, string groupName)
        {
            var project = Post(url + "projects", token, JsonConvert.SerializeObject(new
            {
                name = projectName,
                description = description ?? ""
            }));

            var projectObject = JsonConvert.DeserializeObject<dynamic>(project);

            if (!string.IsNullOrEmpty(groupName))
            {
                var groupId = GetGroupId(groupName);

                Post(url + "groups/" + groupId + "/projects/" + projectObject.id.ToString(), moveToken, JsonConvert.SerializeObject(new
                {
                    id = groupId,
                    project_id = projectObject.id.ToString()
                }));
            }

            return (int)projectObject.id;
        }

        public int GetGroupId(string groupName)
        {
            var groups = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(Get(url + "groups", token));

            foreach (var group in groups)
            {
                if (((string)group.name.ToString()).Equals(groupName, StringComparison.OrdinalIgnoreCase))
                {
                    return (int)group.id;
                }
            }

            return -1;
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

        private static string Post(string url, string token, string jsonContent)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            var byteArray = Encoding.UTF8.GetBytes(jsonContent);
            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";
            request.Headers["PRIVATE-TOKEN"] = token;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
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