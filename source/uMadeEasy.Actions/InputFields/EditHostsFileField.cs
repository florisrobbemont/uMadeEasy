// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.InputFields;

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