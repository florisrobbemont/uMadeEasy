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

        public void BuildFields(IEnumerable<IGeneratorAction> actions,
                                IEnumerable<Type> controls,
                                TemplateInformation template)
        {
            Controls.Clear();

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

                Controls.Add(BuildEditControl(generatorAction, generatorControl, template));
            }
        }

        private static Control BuildEditControl(IGeneratorAction action, Type control, TemplateInformation template)
        {
            var groupBox = new GroupBox
                               {
                                   Padding = new Padding(5),
                                   Text = action.ActionName,
                                   Name = string.Format("inputField_{0}", action.ActionName),
                                   AutoSize = true
                               };

            groupBox.Controls.Add(ReflectionHelpers.CreateTypeInstance<Control>(control));

            return groupBox;
        }
    }
}