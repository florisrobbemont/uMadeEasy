using Lucrasoft.uMadeEasy.Core.Actions;
using Lucrasoft.uMadeEasy.Core.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions
{
    public class CreateDestinationAction : IAction
    {
        public string ActionName
        {
            get { return "Create destination folder"; }
        }

        public string RollBackMessage
        {
            get { return "This rollback will permanently remove the newly created folder (even though there may already be files in it)"; }
        }

        public bool AllowContinueAfterError
        {
            get { return false; }
        }

        public bool SupportsRollback
        {
            get { return true; }
        }

        public bool ExecuteAction(GeneratorArguments arguments)
        {
            throw new NotImplementedException();
        }

        public bool RollbackAction(GeneratorArguments arguments)
        {
            throw new NotImplementedException();
        }
    }
}