namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    partial class CreateDestinationField
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDestinationField));
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.SitePathBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectFolderButton.Image")));
            this.SelectFolderButton.Location = new System.Drawing.Point(335, 6);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(28, 25);
            this.SelectFolderButton.TabIndex = 10;
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderButtonClick);
            // 
            // SitePathBox
            // 
            this.SitePathBox.Location = new System.Drawing.Point(110, 9);
            this.SitePathBox.Name = "SitePathBox";
            this.SitePathBox.Size = new System.Drawing.Size(217, 20);
            this.SitePathBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Location:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Selecteer Source control pad";
            // 
            // CreateDestinationField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.SelectFolderButton);
            this.Controls.Add(this.SitePathBox);
            this.Controls.Add(this.label3);
            this.Name = "CreateDestinationField";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectFolderButton;
        private System.Windows.Forms.TextBox SitePathBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
