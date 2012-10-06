namespace Lucrasoft.uMadeEasy.Core.InputFields
{
    partial class InputFieldRepeater
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ediControlsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // ediControlsPanel
            // 
            this.ediControlsPanel.AutoScroll = true;
            this.ediControlsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ediControlsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ediControlsPanel.Location = new System.Drawing.Point(0, 0);
            this.ediControlsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ediControlsPanel.Name = "ediControlsPanel";
            this.ediControlsPanel.Size = new System.Drawing.Size(542, 221);
            this.ediControlsPanel.TabIndex = 0;
            // 
            // InputFieldRepeater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ediControlsPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "InputFieldRepeater";
            this.Size = new System.Drawing.Size(542, 221);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel ediControlsPanel;
    }
}
