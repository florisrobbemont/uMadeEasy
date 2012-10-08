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
    public partial class EditHostsFileField : InputFieldControl
    {
        public EditHostsFileField()
        {
            InitializeComponent();
        }

        public override ActionInputValues GetInputValues()
        {
            return new ActionInputValues()
                       {
                           { "EditHostsFile", EditHostsFIleBox.Checked },
                           { "HostName", HostNameBox.Text }
                       };
        }

        public override ActionInputValidationArguments ValidateInputValues()
        {
            var validateArgument = new ActionInputValidationArguments();

            if (string.IsNullOrEmpty(HostNameBox.Text))
                validateArgument.ValidationMessage = "Hostname cannot be empty";

            validateArgument.IsValid = string.IsNullOrEmpty(validateArgument.ValidationMessage);

            return validateArgument;
        }
    }
}