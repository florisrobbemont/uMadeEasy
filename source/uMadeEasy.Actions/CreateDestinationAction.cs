using Lucrasoft.uMadeEasy.Core.Generator;
using Lucrasoft.uMadeEasy.Core.InputFields;
using Lucrasoft.uMadeEasy.Core.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lucrasoft.uMadeEasy.Actions
{
    public class CreateDestinationAction : IGeneratorAction
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

        public bool ExecuteAction(GeneratorArguments arguments, ActionInputValues values)
        {
            throw new NotImplementedException();
        }

        public bool RollbackAction(GeneratorArguments arguments, ActionInputValues values)
        {
            throw new NotImplementedException();
        }

        public Type InputControl
        {
            get { return typeof(InputFields.CreateDestinationField); }
        }
    }
}