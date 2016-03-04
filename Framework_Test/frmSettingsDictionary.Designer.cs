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
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.dgvSettingsDictionary.Name = "dgvSettingsDictionary";
            this.dgvSettingsDictionary.Size = new System.Drawing.Size(514, 179);
            this.dgvSettingsDictionary.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(299, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // frmSettingsDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 478);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dgvSettingsDictionary);
            this.Name = "frmSettingsDictionary";
            this.Text = "frmSettingsDictionary";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSettingsDictionary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSettingsDictionary;
        private System.Windows.Forms.TextBox textBox1;
    }
}