using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Lucrasoft.uMadeEasy.Actions;
using Lucrasoft.uMadeEasy.Core.Actions;
using Lucrasoft.uMadeEasy.Core.Template;

namespace Lucrasoft.uMadeEasy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1Load(object sender, EventArgs e)
        {
            var templateReader = TemplateReader.ReadTemplate(@"C:\Development\Github\uMadeEasy\documentation\Template.xml");

        }
    }
}
