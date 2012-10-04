using Lucrasoft.uMadeEasy.Core;
using Lucrasoft.uMadeEasy.Core.Generator;
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
            var actions = Program.Injector.GetExportedValues<IGeneratorAction>().ToList();

            inputFieldRepeater1.BuildFields(actions, actions.Select(x => x.InputControl), TestClass.GetTemplate());
        }

        private void cbTemplateSelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}