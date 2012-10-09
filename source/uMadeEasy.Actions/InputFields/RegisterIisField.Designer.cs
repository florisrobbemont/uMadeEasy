namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    partial class RegisterIisField
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
            this.label3 = new System.Windows.Forms.Label();
            this.RegisterIisBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Register site in IIS:";
            // 
            // RegisterIisBox
            // 
            this.RegisterIisBox.AutoSize = true;
            this.RegisterIisBox.Location = new System.Drawing.Point(309, 10);
            this.RegisterIisBox.Name = "RegisterIisBox";
            this.RegisterIisBox.Size = new System.Drawing.Size(15, 14);
            this.RegisterIisBox.TabIndex = 13;
            this.RegisterIisBox.UseVisualStyleBackColor = true;
            // 
            // RegisterIisField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RegisterIisBox);
            this.Controls.Add(this.label3);
            this.Name = "RegisterIisField";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox RegisterIisBox;

    }
}
