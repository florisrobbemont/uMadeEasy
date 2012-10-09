namespace Lucrasoft.uMadeEasy.ProjectGenerator.Dialogs
{
    partial class GeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.generatorBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.CloseCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 65);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(513, 201);
            this.LogBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Progress:";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 25);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(513, 34);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 4;
            // 
            // generatorBackgroundWorker
            // 
            this.generatorBackgroundWorker.WorkerReportsProgress = true;
            this.generatorBackgroundWorker.WorkerSupportsCancellation = true;
            this.generatorBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GeneratorBackgroundWorkerDoWork);
            this.generatorBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.GeneratorBackgroundWorkerRunWorkerCompleted);
            // 
            // CloseCancelButton
            // 
            this.CloseCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseCancelButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.CloseCancelButton.Location = new System.Drawing.Point(12, 276);
            this.CloseCancelButton.Name = "CloseCancelButton";
            this.CloseCancelButton.Size = new System.Drawing.Size(513, 46);
            this.CloseCancelButton.TabIndex = 8;
            this.CloseCancelButton.Text = "Cancel";
            this.CloseCancelButton.UseVisualStyleBackColor = true;
            this.CloseCancelButton.Click += new System.EventHandler(this.CloseCancelButtonClick);
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 334);
            this.ControlBox = false;
            this.Controls.Add(this.CloseCancelButton);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GeneratorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "uMadeEasy - Generate new project";
            this.Load += new System.EventHandler(this.GeneratorFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.ComponentModel.BackgroundWorker generatorBackgroundWorker;
        private System.Windows.Forms.Button CloseCancelButton;
    }
}