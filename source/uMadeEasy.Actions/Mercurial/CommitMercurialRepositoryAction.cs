using Lucrasoft.uMadeEasy.Core.Generator;
using Mercurial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions.Mercurial
{
    /// <summary>
    /// Commits all files from the newly generator project into Mercurial
    /// </summary>
    public class CommitMercurialRepositoryAction : IGeneratorAction
    {
        private const string MercurialCommitMessage = "Initial Commit by {0}";

        public string ActionName
        {
            get { return "Commit Mercurial repository"; }
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
            var location = values.GetString("DestinationFolder");

            var repo = new Repository(location);
            repo.Add(new AddCommand().WithPaths(location));

            repo.Commit(string.Format(MercurialCommitMessage, Environment.UserName));

            return new GeneratorActionResult(true, "");
        }

        public GeneratorActionResult RollbackAction(GeneratorArguments arguments, Core.InputFields.ActionInputValues values, Dictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return null; }
        }
    }
}