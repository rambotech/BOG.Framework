namespace BOG.Framework_Test
{
    partial class frmStringEx
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStringToString = new System.Windows.Forms.TabPage();
            this.txtOutputStrStr = new System.Windows.Forms.TextBox();
            this.btnTestIt = new System.Windows.Forms.Button();
            this.cbxMethodStrStr = new System.Windows.Forms.ComboBox();
            this.txtInputStrStr = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabStringToString.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStringToString);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 566);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStringToString
            // 
            this.tabStringToString.Controls.Add(this.txtOutputStrStr);
            this.tabStringToString.Controls.Add(this.btnTestIt);
            this.tabStringToString.Controls.Add(this.cbxMethodStrStr);
            this.tabStringToString.Controls.Add(this.txtInputStrStr);
            this.tabStringToString.Location = new System.Drawing.Point(4, 25);
            this.tabStringToString.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStringToString.Name = "tabStringToString";
            this.tabStringToString.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabStringToString.Size = new System.Drawing.Size(948, 537);
            this.tabStringToString.TabIndex = 0;
            this.tabStringToString.Text = "StringIn-StringOut";
            this.tabStringToString.UseVisualStyleBackColor = true;
            // 
            // txtOutputStrStr
            // 
            this.txtOutputStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputStrStr.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputStrStr.Location = new System.Drawing.Point(8, 289);
            this.txtOutputStrStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputStrStr.Multiline = true;
            this.txtOutputStrStr.Name = "txtOutputStrStr";
            this.txtOutputStrStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputStrStr.Size = new System.Drawing.Size(923, 234);
            this.txtOutputStrStr.TabIndex = 4;
            // 
            // btnTestIt
            // 
            this.btnTestIt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestIt.Location = new System.Drawing.Point(11, 254);
            this.btnTestIt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestIt.Name = "btnTestIt";
            this.btnTestIt.Size = new System.Drawing.Size(921, 28);
            this.btnTestIt.TabIndex = 3;
            this.btnTestIt.Text = "Test It";
            this.btnTestIt.UseVisualStyleBackColor = true;
            this.btnTestIt.Click += new System.EventHandler(this.btnTestIt_Click);
            // 
            // cbxMethodStrStr
            // 
            this.cbxMethodStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMethodStrStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethodStrStr.FormattingEnabled = true;
            this.cbxMethodStrStr.Location = new System.Drawing.Point(11, 7);
            this.cbxMethodStrStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxMethodStrStr.Name = "cbxMethodStrStr";
            this.cbxMethodStrStr.Size = new System.Drawing.Size(923, 24);
            this.cbxMethodStrStr.TabIndex = 2;
            this.cbxMethodStrStr.SelectedIndexChanged += new System.EventHandler(this.cbxMethodStrStr_SelectedIndexChanged);
            // 
            // txtInputStrStr
            // 
            this.txtInputStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputStrStr.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputStrStr.Location = new System.Drawing.Point(11, 41);
            this.txtInputStrStr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInputStrStr.Multiline = true;
            this.txtInputStrStr.Name = "txtInputStrStr";
            this.txtInputStrStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputStrStr.Size = new System.Drawing.Size(923, 205);
            this.txtInputStrStr.TabIndex = 0;
            // 
            // frmStringEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 566);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmStringEx";
            this.Text = "frmStringEx";
            this.tabControl1.ResumeLayout(false);
            this.tabStringToString.ResumeLayout(false);
            this.tabStringToString.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStringToString;
        private System.Windows.Forms.TextBox txtInputStrStr;
        private System.Windows.Forms.ComboBox cbxMethodStrStr;
        private System.Windows.Forms.Button btnTestIt;
        private System.Windows.Forms.TextBox txtOutputStrStr;
    }
}