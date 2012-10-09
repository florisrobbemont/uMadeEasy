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

namespace Lucrasoft.uMadeEasy.ProjectGenerator.Dialogs
{
    public partial class GeneratorForm : Form
    {
        private const string CancelText = "Cancel";
        private const string CloseText = "Close";

        private readonly GeneratorArguments generatorArguments;

        public GeneratorForm(GeneratorArguments arguments)
        {
            generatorArguments = arguments;

            InitializeComponent();
        }

        private void GeneratorFormLoad(object sender, EventArgs e)
        {
            if (generatorArguments == null)
                Close();

            generatorBackgroundWorker.RunWorkerAsync();
        }

        private void CloseCancelButtonClick(object sender, EventArgs e)
        {
            if (generatorBackgroundWorker.IsBusy)
                generatorBackgroundWorker.CancelAsync();
            else
                Close();
        }

        #region "Generator"

        /// <summary>
        /// Report the progress from the BackgroundWorker.
        /// </summary>
        private void ReportProgress(int percentage, string message)
        {
            Invoke((MethodInvoker)(() =>
            {
                if (percentage >= 0 && percentage <= 100) ProgressBar.Value = percentage;
                if (message.Length > 0) LogBox.AppendText(message + "\n");
                LogBox.ScrollToCaret();
            }));
        }

        /// <summary>
        /// Displays a box with the question to rollback or not.
        /// </summary>
        private void ReportRollback(string rollbackName, string rollbackMessage, out bool rollbackAllowed)
        {
            var messageBoxResult = MessageBox.Show(rollbackMessage,
                                                   string.Concat("Rollback: ", rollbackName),
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Exclamation);

            rollbackAllowed = (messageBoxResult == DialogResult.Yes);
        }

        private void GeneratorBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var generator = new Core.Generator.ProjectGenerator();

            e.Result = generator.Generate(generatorArguments, ReportProgress, ReportRollback, () => !((BackgroundWorker)sender).CancellationPending);
        }

        private void GeneratorBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Close();
                return;
            }

            CloseCancelButton.Text = CloseText;

            if (e.Error != null)
            {
                MessageBox.Show("Process completed with error: " + e.Error.Message, "Generator message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = e.Result as GeneratorResult;

            if (result != null && result.OperationSuccesfull)
                ReportProgress(-1, "Project succesfully generated!");
            else if (result != null)
            {
                MessageBox.Show("Process completed with error or was canceled and was rolled back from action: " + result.LastAction.ActionName, "Generator message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion "Generator"
    }
}