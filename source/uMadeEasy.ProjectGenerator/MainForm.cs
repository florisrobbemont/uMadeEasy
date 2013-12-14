// Copyright (c) Lucrasoft ICT Group. All rights reserved. See License.txt in the project root for license information.

using Lucrasoft.uMadeEasy.Core;
using Lucrasoft.uMadeEasy.Core.Generator;
using Lucrasoft.uMadeEasy.Core.Template;
using Lucrasoft.uMadeEasy.ProjectGenerator.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.ProjectGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            BuildTemplates();
        }

        private void LogoBoxClick(object sender, EventArgs e)
        {
            Process.Start("http://www.lucrasoft.nl");
        }

        #region "Templates"

        private TemplateInformation SelectedTemplate
        {
            get { return selectedTemplate; }
            set
            {
                selectedTemplate = value;
                BuildInputFields();
            }
        }

        private TemplateInformation selectedTemplate = null;

        private void BuildTemplates()
        {
            TemplateComboBox.DataSource = TemplateReader.ReadTemplates(IoHelpers.GetTemplatePath()).ToList();
        }

        private void BuildInputFields()
        {
            var actions = Program.Injector.GetExportedValues<IGeneratorAction>().ToList();

            inputFieldRepeater1.BuildFields(actions, actions.Select(x => x.InputControl), SelectedTemplate);
        }

        private void TemplateComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedTemplate != null)
            {
                if (MessageBox.Show(this,
                                    "You've already selected a template. If you switch all input will be lost. Do you want to continue?",
                                    "Switch template", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            SelectedTemplate = TemplateComboBox.SelectedValue as TemplateInformation;
        }

        private void ProjectNameBoxTextChanged(object sender, EventArgs e)
        {
            inputFieldRepeater1.OnProjectNameChanged(ProjectNameBox.Text);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        #endregion "Templates"

        #region "Generator"

        private void GenerateButtonClick(object sender, EventArgs e)
        {
            if (!(ValidateSiteNameBox()) || (!inputFieldRepeater1.ValidateAllControl()))
                return;

            selectedTemplate.Prepare(ProjectNameBox.Text);

            var generatorArguments = new GeneratorArguments
                                         {
                                             Name = ProjectNameBox.Text,
                                             TemplateInformation = selectedTemplate,
                                             InputValues = inputFieldRepeater1.GetInputValues()
                                         };

            var generatorForm = new GeneratorForm(generatorArguments);
            generatorForm.ShowDialog();
        }

        private bool ValidateSiteNameBox()
        {
            if (string.IsNullOrEmpty(ProjectNameBox.Text))
            {
                MessageBox.Show(this, "The name of the site is required.", "Validation error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return false;
            }

            var invalidCharList = new List<char>();
            invalidCharList.AddRange(System.IO.Path.GetInvalidFileNameChars());
            invalidCharList.AddRange(System.IO.Path.GetInvalidPathChars());

            invalidCharList.Add('-');

            if (ProjectNameBox.Text.ToCharArray().Count(invalidCharList.Contains) > 0)
            {
                MessageBox.Show(this, "The following chars are not allowed in the project name box: " + String.Join(", ", ProjectNameBox.Text.ToCharArray().Where(invalidCharList.Contains).Distinct()),
                                "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (!Char.IsUpper(ProjectNameBox.Text[0]))
            {
                MessageBox.Show(this, "The name of the site should start with a UpperCase char.", "Validation error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        #endregion "Generator"
    }
}