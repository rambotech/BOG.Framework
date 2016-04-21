namespace BOG.Framework_Test
{
    partial class frmSerializer
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
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnBuild3Gb = new System.Windows.Forms.Button();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.btnLoadDocument = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(104, 148);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(339, 17);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "C:\\Users\\jschultz\\AppData\\Local\\Temp\\tmpD47C.tmp";
            // 
            // btnBuild3Gb
            // 
            this.btnBuild3Gb.Location = new System.Drawing.Point(107, 26);
            this.btnBuild3Gb.Name = "btnBuild3Gb";
            this.btnBuild3Gb.Size = new System.Drawing.Size(154, 44);
            this.btnBuild3Gb.TabIndex = 1;
            this.btnBuild3Gb.Text = "Build 3Gb";
            this.btnBuild3Gb.UseVisualStyleBackColor = true;
            this.btnBuild3Gb.Click += new System.EventHandler(this.btnBuild3Gb_Click);
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(104, 228);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(75, 17);
            this.lblFileSize.TabIndex = 2;
            this.lblFileSize.Text = "(size TBD)";
            // 
            // btnLoadDocument
            // 
            this.btnLoadDocument.Location = new System.Drawing.Point(313, 26);
            this.btnLoadDocument.Name = "btnLoadDocument";
            this.btnLoadDocument.Size = new System.Drawing.Size(154, 44);
            this.btnLoadDocument.TabIndex = 3;
            this.btnLoadDocument.Text = "Load It";
            this.btnLoadDocument.UseVisualStyleBackColor = true;
            this.btnLoadDocument.Click += new System.EventHandler(this.btnLoadDocument_Click);
            // 
            // frmSerializer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 341);
            this.Controls.Add(this.btnLoadDocument);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.btnBuild3Gb);
            this.Controls.Add(this.lblFileName);
            this.Name = "frmSerializer";
            this.Text = "Serializer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnBuild3Gb;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Button btnLoadDocument;
    }
}