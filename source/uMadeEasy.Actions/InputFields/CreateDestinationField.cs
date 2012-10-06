using Lucrasoft.uMadeEasy.Core.InputFields;
using System;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    public partial class CreateDestinationField : InputFieldControl
    {
        public CreateDestinationField()
        {
            InitializeComponent();
        }

        private void SelectFolderButtonClick(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbSitePath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public override ActionInputValues GetInputValues()
        {
            return new ActionInputValues()
                       {
                           { "DestinationFolder", tbSitePath.Text }
                       };
        }

        public override ActionInputValidationArguments ValidateInputValues()
        {
            var validateArgument = new ActionInputValidationArguments();

            if (string.IsNullOrEmpty(tbSitePath.Text))
                validateArgument.ValidationMessage = "Folder cannot be empty";

            validateArgument.IsValid = string.IsNullOrEmpty(validateArgument.ValidationMessage);

            return validateArgument;
        }
    }
}