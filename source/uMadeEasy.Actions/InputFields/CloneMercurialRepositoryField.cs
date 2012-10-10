// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.InputFields;

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