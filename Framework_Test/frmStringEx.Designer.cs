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
			this.cbxMethodStr = new System.Windows.Forms.ComboBox();
			this.txtInputStrStr = new System.Windows.Forms.TextBox();
			this.tabFilter = new System.Windows.Forms.TabPage();
			this.txtFilterSet = new System.Windows.Forms.TextBox();
			this.txtFiltered = new System.Windows.Forms.TextBox();
			this.btnTestFilter = new System.Windows.Forms.Button();
			this.cbxFilterMethod = new System.Windows.Forms.ComboBox();
			this.txtOriginal = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.tabStringToString.SuspendLayout();
			this.tabFilter.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabStringToString);
			this.tabControl1.Controls.Add(this.tabFilter);
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
			this.tabStringToString.Controls.Add(this.cbxMethodStr);
			this.tabStringToString.Controls.Add(this.txtInputStrStr);
			this.tabStringToString.Location = new System.Drawing.Point(4, 22);
			this.tabStringToString.Name = "tabStringToString";
			this.tabStringToString.Padding = new System.Windows.Forms.Padding(3);
			this.tabStringToString.Size = new System.Drawing.Size(709, 434);
			this.tabStringToString.TabIndex = 0;
			this.tabStringToString.Text = "StringIn-StringOut";
			this.tabStringToString.UseVisualStyleBackColor = true;
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
			// cbxMethodStr
			// 
			this.cbxMethodStr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxMethodStr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMethodStr.FormattingEnabled = true;
			this.cbxMethodStr.Location = new System.Drawing.Point(8, 6);
			this.cbxMethodStr.Name = "cbxMethodStr";
			this.cbxMethodStr.Size = new System.Drawing.Size(693, 21);
			this.cbxMethodStr.TabIndex = 2;
			this.cbxMethodStr.SelectedIndexChanged += new System.EventHandler(this.cbxMethodStr_SelectedIndexChanged);
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
			// tabFilter
			// 
			this.tabFilter.Controls.Add(this.label4);
			this.tabFilter.Controls.Add(this.label3);
			this.tabFilter.Controls.Add(this.label2);
			this.tabFilter.Controls.Add(this.label1);
			this.tabFilter.Controls.Add(this.txtFilterSet);
			this.tabFilter.Controls.Add(this.txtFiltered);
			this.tabFilter.Controls.Add(this.btnTestFilter);
			this.tabFilter.Controls.Add(this.cbxFilterMethod);
			this.tabFilter.Controls.Add(this.txtOriginal);
			this.tabFilter.Location = new System.Drawing.Point(4, 22);
			this.tabFilter.Name = "tabFilter";
			this.tabFilter.Size = new System.Drawing.Size(709, 434);
			this.tabFilter.TabIndex = 1;
			this.tabFilter.Text = "Filter";
			this.tabFilter.UseVisualStyleBackColor = true;
			// 
			// txtFilterSet
			// 
			this.txtFilterSet.Location = new System.Drawing.Point(100, 134);
			this.txtFilterSet.Name = "txtFilterSet";
			this.txtFilterSet.Size = new System.Drawing.Size(335, 20);
			this.txtFilterSet.TabIndex = 7;
			// 
			// txtFiltered
			// 
			this.txtFiltered.Location = new System.Drawing.Point(100, 174);
			this.txtFiltered.Multiline = true;
			this.txtFiltered.Name = "txtFiltered";
			this.txtFiltered.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtFiltered.Size = new System.Drawing.Size(336, 105);
			this.txtFiltered.TabIndex = 4;
			// 
			// btnTestFilter
			// 
			this.btnTestFilter.Location = new System.Drawing.Point(459, 201);
			this.btnTestFilter.Name = "btnTestFilter";
			this.btnTestFilter.Size = new System.Drawing.Size(148, 53);
			this.btnTestFilter.TabIndex = 3;
			this.btnTestFilter.Text = "Filter";
			this.btnTestFilter.UseVisualStyleBackColor = true;
			this.btnTestFilter.Click += new System.EventHandler(this.btnTestFilter_Click);
			// 
			// cbxFilterMethod
			// 
			this.cbxFilterMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxFilterMethod.FormattingEnabled = true;
			this.cbxFilterMethod.Location = new System.Drawing.Point(527, 133);
			this.cbxFilterMethod.Name = "cbxFilterMethod";
			this.cbxFilterMethod.Size = new System.Drawing.Size(148, 21);
			this.cbxFilterMethod.TabIndex = 2;
			this.cbxFilterMethod.SelectedIndexChanged += new System.EventHandler(this.cbxFilterMethod_SelectedIndexChanged);
			// 
			// txtOriginal
			// 
			this.txtOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOriginal.Location = new System.Drawing.Point(98, 8);
			this.txtOriginal.Multiline = true;
			this.txtOriginal.Name = "txtOriginal";
			this.txtOriginal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOriginal.Size = new System.Drawing.Size(602, 105);
			this.txtOriginal.TabIndex = 0;
			this.txtOriginal.Text = "72.41.115x.74";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Original";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 138);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Filter set";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(37, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Result";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(465, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Method";
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
			this.tabFilter.ResumeLayout(false);
			this.tabFilter.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStringToString;
        private System.Windows.Forms.TextBox txtInputStrStr;
        private System.Windows.Forms.ComboBox cbxMethodStr;
        private System.Windows.Forms.Button btnTestIt;
        private System.Windows.Forms.TextBox txtOutputStrStr;
		private System.Windows.Forms.TabPage tabFilter;
		private System.Windows.Forms.Button btnTestFilter;
		private System.Windows.Forms.ComboBox cbxFilterMethod;
		private System.Windows.Forms.TextBox txtOriginal;
		private System.Windows.Forms.TextBox txtFiltered;
		private System.Windows.Forms.TextBox txtFilterSet;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}