namespace BOG.Framework_Test
{
	partial class frmFormatting
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lbxKZdatatype = new System.Windows.Forms.ListBox();
			this.txtKZresult = new System.Windows.Forms.TextBox();
			this.btnTestKiloToZeta = new System.Windows.Forms.Button();
			this.txtKZsource = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtWCMresult = new System.Windows.Forms.TextBox();
			this.btnWCMtest = new System.Windows.Forms.Button();
			this.txtWCMsource = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(399, 180);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lbxKZdatatype);
			this.tabPage1.Controls.Add(this.txtKZresult);
			this.tabPage1.Controls.Add(this.btnTestKiloToZeta);
			this.tabPage1.Controls.Add(this.txtKZsource);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(391, 154);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "KiloToZotta()";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lbxKZdatatype
			// 
			this.lbxKZdatatype.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lbxKZdatatype.FormattingEnabled = true;
			this.lbxKZdatatype.Items.AddRange(new object[] {
			"double",
			"long"});
			this.lbxKZdatatype.Location = new System.Drawing.Point(8, 33);
			this.lbxKZdatatype.Name = "lbxKZdatatype";
			this.lbxKZdatatype.Size = new System.Drawing.Size(375, 56);
			this.lbxKZdatatype.TabIndex = 5;
			// 
			// txtKZresult
			// 
			this.txtKZresult.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtKZresult.Location = new System.Drawing.Point(8, 124);
			this.txtKZresult.Name = "txtKZresult";
			this.txtKZresult.Size = new System.Drawing.Size(375, 20);
			this.txtKZresult.TabIndex = 7;
			// 
			// btnTestKiloToZeta
			// 
			this.btnTestKiloToZeta.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTestKiloToZeta.Location = new System.Drawing.Point(8, 95);
			this.btnTestKiloToZeta.Name = "btnTestKiloToZeta";
			this.btnTestKiloToZeta.Size = new System.Drawing.Size(375, 23);
			this.btnTestKiloToZeta.TabIndex = 6;
			this.btnTestKiloToZeta.Text = "Test";
			this.btnTestKiloToZeta.UseVisualStyleBackColor = true;
			this.btnTestKiloToZeta.Click += new System.EventHandler(this.btnTestKiloToZeta_Click);
			// 
			// txtKZsource
			// 
			this.txtKZsource.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtKZsource.Location = new System.Drawing.Point(8, 6);
			this.txtKZsource.Name = "txtKZsource";
			this.txtKZsource.Size = new System.Drawing.Size(375, 20);
			this.txtKZsource.TabIndex = 4;
			this.txtKZsource.Text = "1234567890123456789012345678.0";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.txtWCMresult);
			this.tabPage2.Controls.Add(this.btnWCMtest);
			this.tabPage2.Controls.Add(this.txtWCMsource);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(391, 154);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "CurrencyWrittenAmount()";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// txtWCMresult
			// 
			this.txtWCMresult.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtWCMresult.Location = new System.Drawing.Point(8, 126);
			this.txtWCMresult.Name = "txtWCMresult";
			this.txtWCMresult.Size = new System.Drawing.Size(375, 20);
			this.txtWCMresult.TabIndex = 10;
			// 
			// btnWCMtest
			// 
			this.btnWCMtest.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnWCMtest.Location = new System.Drawing.Point(8, 97);
			this.btnWCMtest.Name = "btnWCMtest";
			this.btnWCMtest.Size = new System.Drawing.Size(375, 23);
			this.btnWCMtest.TabIndex = 9;
			this.btnWCMtest.Text = "Test";
			this.btnWCMtest.UseVisualStyleBackColor = true;
			this.btnWCMtest.Click += new System.EventHandler(this.btnWCMtest_Click);
			// 
			// txtWCMsource
			// 
			this.txtWCMsource.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtWCMsource.Location = new System.Drawing.Point(8, 8);
			this.txtWCMsource.Name = "txtWCMsource";
			this.txtWCMsource.Size = new System.Drawing.Size(375, 20);
			this.txtWCMsource.TabIndex = 8;
			this.txtWCMsource.Text = "2,111,043,645,556,237.1";
			// 
			// frmFormatting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 180);
			this.Controls.Add(this.tabControl1);
			this.MaximumSize = new System.Drawing.Size(1024, 219);
			this.MinimumSize = new System.Drawing.Size(415, 219);
			this.Name = "frmFormatting";
			this.Text = "Formatting";
			this.Load += new System.EventHandler(this.frmFormatting_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ListBox lbxKZdatatype;
		private System.Windows.Forms.TextBox txtKZresult;
		private System.Windows.Forms.Button btnTestKiloToZeta;
		private System.Windows.Forms.TextBox txtKZsource;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtWCMresult;
		private System.Windows.Forms.Button btnWCMtest;
		private System.Windows.Forms.TextBox txtWCMsource;
	}
}