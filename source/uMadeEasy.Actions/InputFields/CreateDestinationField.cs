// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

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

            // When the environment variable REPOPATH is set use this as a prefix
            try
            {
                var repoPath = Environment.GetEnvironmentVariable("REPOPATH", EnvironmentVariableTarget.User);

                if (!string.IsNullOrEmpty(repoPath))
                {
                    if (!repoPath.EndsWith(@"\"))
                    {
                        repoPath = repoPath + @"\";
                    }

                    SitePathBox.Text = repoPath.ToLower();
                    folderBrowserDialog1.SelectedPath = repoPath;
                }
            }
            catch
            {
            }
        }

        private void SelectFolderButtonClick(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                SitePathBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        public override ActionInputValues GetInputValues()
        {
            return new ActionInputValues()
                       {
                           { "DestinationFolder", SitePathBox.Text }
                       };
        }

        public override ActionInputValidationArguments ValidateInputValues()
        {
            var validateArgument = new ActionInputValidationArguments();

            if (string.IsNullOrEmpty(SitePathBox.Text))
                validateArgument.ValidationMessage = "Folder cannot be empty";

            validateArgument.IsValid = string.IsNullOrEmpty(validateArgument.ValidationMessage);

            return validateArgument;
        }
    }
}