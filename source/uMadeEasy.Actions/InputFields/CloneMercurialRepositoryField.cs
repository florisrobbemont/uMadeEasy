using Lucrasoft.uMadeEasy.Core.InputFields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    public partial class CloneMercurialRepositoryField : InputFieldControl
    {
        public CloneMercurialRepositoryField()
        {
            InitializeComponent();
        }

        public override ActionInputValues GetInputValues()
        {
            return new ActionInputValues()
                       {
                           { "MercurialCloneUrl", CloneUrlBox.Text }
                       };
        }

        public override ActionInputValidationArguments ValidateInputValues()
        {
            var validateArgument = new ActionInputValidationArguments();

            if (string.IsNullOrEmpty(CloneUrlBox.Text))
                validateArgument.ValidationMessage = "Clone URL cannot be empty";

            validateArgument.IsValid = string.IsNullOrEmpty(validateArgument.ValidationMessage);

            return validateArgument;
        }
    }
}