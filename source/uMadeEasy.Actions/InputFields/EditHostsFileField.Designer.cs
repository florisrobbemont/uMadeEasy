﻿namespace Lucrasoft.uMadeEasy.Actions.InputFields
{
    partial class EditHostsFileField
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
            this.EditHostsFIleBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HostNameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Edit hosts file:";
            // 
            // EditHostsFIleBox
            // 
            this.EditHostsFIleBox.AutoSize = true;
            this.EditHostsFIleBox.Location = new System.Drawing.Point(350, 10);
            this.EditHostsFIleBox.Name = "EditHostsFIleBox";
            this.EditHostsFIleBox.Size = new System.Drawing.Size(15, 14);
            this.EditHostsFIleBox.TabIndex = 13;
            this.EditHostsFIleBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Hostname:";
            // 
            // HostNameBox
            // 
            this.HostNameBox.Location = new System.Drawing.Point(107, 36);
            this.HostNameBox.Name = "HostNameBox";
            this.HostNameBox.Size = new System.Drawing.Size(258, 20);
            this.HostNameBox.TabIndex = 15;
            // 
            // EditHostsFileField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HostNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditHostsFIleBox);
            this.Controls.Add(this.label3);
            this.Name = "EditHostsFileField";
            this.Size = new System.Drawing.Size(380, 63);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox EditHostsFIleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HostNameBox;

    }
}
