using Lucrasoft.uMadeEasy.Core;
using Lucrasoft.uMadeEasy.Core.Generator;
using Lucrasoft.uMadeEasy.Core.Template;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lucrasoft.uMadeEasy.ProjectGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            BuildTemplates();
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
                if (
                    MessageBox.Show(this,
                                    "You've already selected a template. If you switch all input will be lost. Do you want to continue?",
                                    "Switch template", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            SelectedTemplate = TemplateComboBox.SelectedValue as TemplateInformation;
        }

        #endregion "Templates"

        #region "Generator"

        private void GenerateButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SiteNameBox.Text))
            {
                MessageBox.Show(this, "The name of the site is required.", "Validation error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                return;
            }

            if (inputFieldRepeater1.AllControlsValid())
            {
                var generator = new Core.Generator.ProjectGenerator();

                selectedTemplate.Prepare(SiteNameBox.Text);

                generator.Generate(new GeneratorArguments
                                       {
                                           Name = SiteNameBox.Text,
                                           TemplateInformation = selectedTemplate
                                       },
                                   inputFieldRepeater1.GetInputValues());
            }
        }

        #endregion "Generator"
    }
}