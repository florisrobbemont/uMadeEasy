// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core.InputFields;

namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    public partial class RegisterIisField : InputFieldControl
    {
        public RegisterIisField()
        {
            InitializeComponent();
        }

        public override ActionInputValues GetInputValues()
        {
            return new ActionInputValues
                       {
                           { "RegisterIis", RegisterIisBox.Checked }
                       };
        }
    }
}