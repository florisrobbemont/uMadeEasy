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