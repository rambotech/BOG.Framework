﻿namespace BOG.Framework_Test
{
    partial class frmSerializableDictionary
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
            this.txtSerializedXML = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSerializedXML
            // 
            this.txtSerializedXML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSerializedXML.Location = new System.Drawing.Point(0, 0);
            this.txtSerializedXML.Multiline = true;
            this.txtSerializedXML.Name = "txtSerializedXML";
            this.txtSerializedXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSerializedXML.Size = new System.Drawing.Size(682, 424);
            this.txtSerializedXML.TabIndex = 0;
            this.txtSerializedXML.WordWrap = false;
            // 
            // frmSerializableDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 424);
            this.Controls.Add(this.txtSerializedXML);
            this.Name = "frmSerializableDictionary";
            this.Text = "frmSerializableDictionary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSerializedXML;
    }
}