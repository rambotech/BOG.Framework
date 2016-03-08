namespace BOG.Framework_Test
{
    partial class frmSettingsDictionary
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
            this.dgvSettingsDictionary = new System.Windows.Forms.DataGridView();
            this.txtXMLview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingsDictionary)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSettingsDictionary
            // 
            this.dgvSettingsDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSettingsDictionary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSettingsDictionary.Location = new System.Drawing.Point(0, 0);
            this.dgvSettingsDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvSettingsDictionary.Name = "dgvSettingsDictionary";
            this.dgvSettingsDictionary.Size = new System.Drawing.Size(679, 220);
            this.dgvSettingsDictionary.TabIndex = 0;
            this.dgvSettingsDictionary.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSettingsDictionary_RowEnter);
            // 
            // txtXMLview
            // 
            this.txtXMLview.Location = new System.Drawing.Point(16, 254);
            this.txtXMLview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXMLview.Multiline = true;
            this.txtXMLview.Name = "txtXMLview";
            this.txtXMLview.ReadOnly = true;
            this.txtXMLview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXMLview.Size = new System.Drawing.Size(661, 332);
            this.txtXMLview.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "SaveSettings() method creates this file content.";
            // 
            // frmSettingsDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 588);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtXMLview);
            this.Controls.Add(this.dgvSettingsDictionary);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSettingsDictionary";
            this.Text = "frmSettingsDictionary";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingsDictionary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSettingsDictionary;
        private System.Windows.Forms.TextBox txtXMLview;
        private System.Windows.Forms.Label label1;
    }
}