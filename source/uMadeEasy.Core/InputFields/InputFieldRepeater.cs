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

namespace Lucrasoft.uMadeEasy.Core.InputFields
{
    public partial class InputFieldRepeater : UserControl
    {
        public InputFieldRepeater()
        {
            InitializeComponent();
        }

        #region "Fields"

        public void BuildFields(IEnumerable<IGeneratorAction> actions,
                                IEnumerable<Type> controls,
                                TemplateInformation template)
        {
            ediControlsPanel.Controls.Clear();

            BuildFieldsInternal(actions, controls, template);
        }

        private void BuildFieldsInternal(IEnumerable<IGeneratorAction> actions,
                                         IEnumerable<Type> controls,
                                         TemplateInformation template)
        {
            var generatorActions = actions as IGeneratorAction[] ?? actions.ToArray();
            var generatorControls = controls as Type[] ?? controls.ToArray();

            foreach (var action in template.Actions)
            {
                var generatorAction = generatorActions.FirstOrDefault(x => x.GetType().AssemblyQualifiedName == action.ActionType);

                if (generatorAction == null)
                    throw new InvalidOperationException(string.Format("Could not find action ('{0}') in injected action list. Are you missing an assembly in the Actions folder?",
                                                                      action.ActionType));

                if (generatorAction.InputControl == null)
                    break;

                var generatorControl = generatorControls.FirstOrDefault(x => x == generatorAction.InputControl);

                if (generatorControl == null)
                    throw new InvalidOperationException(string.Format("Could not find control ('{0}') in injected action list. Are you missing an assembly in the Actions folder?",
                                                                      generatorAction.InputControl.AssemblyQualifiedName));

                ediControlsPanel.Controls.Add(BuildEditControl(generatorAction, generatorControl, template));
            }
        }

        private Control BuildEditControl(IGeneratorAction action, Type control, TemplateInformation template)
        {
            var editControl = ReflectionHelpers.CreateTypeInstance<InputFieldControl>(control);

            if (editControl == null)
                throw new InvalidOperationException("Could not create instance of edit control");

            var groupBox = new GroupBox()
            {
                Margin = new Padding(0, 0, 5, 5),
                Padding = new Padding(5),
                Name = string.Format("inputField_{0}", action.GetType().Name),
                Width = editControl.Width + 10,
                Height = editControl.Height + 25,
                Text = action.ActionName,
            };

            editControl.Dock = DockStyle.Top;

            groupBox.Controls.Add(editControl);

            return groupBox;
        }

        #endregion "Fields"

        #region "Validation"

        /// <summary>
        /// Performs validation on all child controls
        /// </summary>
        public void ExecuteValidation()
        {
            foreach (var validationResult in (from Control control in ediControlsPanel.Controls.Cast<object>().Where(control => control is GroupBox)
                                              from editControl in control.Controls.Cast<object>().Where(editControl => editControl is InputFieldControl)
                                              select (InputFieldControl)editControl).Select(control => control.ValidateInputValues()).Where(validationResult => !validationResult.IsValid))
            {
                MessageBox.Show(this, validationResult.ValidationMessage, "Validation error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        #endregion "Validation"
    }
}