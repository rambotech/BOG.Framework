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
            this.txtInputStrStr = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbxMethodStrStr = new System.Windows.Forms.ComboBox();
            this.btnTestIt = new System.Windows.Forms.Button();
            this.txtOutputStrStr = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabStringToString.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStringToString);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(717, 460);
            this.tabControl1.TabIndex = 0;
            // 
            // tabStringToString
            // 
            this.tabStringToString.Controls.Add(this.txtOutputStrStr);
            this.tabStringToString.Controls.Add(this.btnTestIt);
            this.tabStringToString.Controls.Add(this.cbxMethodStrStr);
            this.tabStringToString.Controls.Add(this.txtInputStrStr);
            this.tabStringToString.Location = new System.Drawing.Point(4, 22);
            this.tabStringToString.Name = "tabStringToString";
            this.tabStringToString.Padding = new System.Windows.Forms.Padding(3);
            this.tabStringToString.Size = new System.Drawing.Size(709, 434);
            this.tabStringToString.TabIndex = 0;
            this.tabStringToString.Text = "StringIn-StringOut";
            this.tabStringToString.UseVisualStyleBackColor = true;
            // 
            // txtInputStrStr
            // 
            this.txtInputStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputStrStr.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputStrStr.Location = new System.Drawing.Point(8, 33);
            this.txtInputStrStr.Multiline = true;
            this.txtInputStrStr.Name = "txtInputStrStr";
            this.txtInputStrStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputStrStr.Size = new System.Drawing.Size(693, 167);
            this.txtInputStrStr.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(709, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbxMethodStrStr
            // 
            this.cbxMethodStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxMethodStrStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMethodStrStr.FormattingEnabled = true;
            this.cbxMethodStrStr.Location = new System.Drawing.Point(8, 6);
            this.cbxMethodStrStr.Name = "cbxMethodStrStr";
            this.cbxMethodStrStr.Size = new System.Drawing.Size(693, 21);
            this.cbxMethodStrStr.TabIndex = 2;
            this.cbxMethodStrStr.SelectedIndexChanged += new System.EventHandler(this.cbxMethodStrStr_SelectedIndexChanged);
            // 
            // btnTestIt
            // 
            this.btnTestIt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestIt.Location = new System.Drawing.Point(8, 206);
            this.btnTestIt.Name = "btnTestIt";
            this.btnTestIt.Size = new System.Drawing.Size(691, 23);
            this.btnTestIt.TabIndex = 3;
            this.btnTestIt.Text = "Test It";
            this.btnTestIt.UseVisualStyleBackColor = true;
            this.btnTestIt.Click += new System.EventHandler(this.btnTestIt_Click);
            // 
            // txtOutputStrStr
            // 
            this.txtOutputStrStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputStrStr.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputStrStr.Location = new System.Drawing.Point(6, 235);
            this.txtOutputStrStr.Multiline = true;
            this.txtOutputStrStr.Name = "txtOutputStrStr";
            this.txtOutputStrStr.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutputStrStr.Size = new System.Drawing.Size(693, 191);
            this.txtOutputStrStr.TabIndex = 4;
            // 
            // frmStringEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 460);
            this.Controls.Add(this.tabControl1);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtInputStrStr;
        private System.Windows.Forms.ComboBox cbxMethodStrStr;
        private System.Windows.Forms.Button btnTestIt;
        private System.Windows.Forms.TextBox txtOutputStrStr;
    }
}