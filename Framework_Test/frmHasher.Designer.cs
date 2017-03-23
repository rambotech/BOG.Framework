namespace BOG.Framework_Test
{
	partial class frmHasher
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
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.btnRunTest = new System.Windows.Forms.Button();
			this.lblHashMethod = new System.Windows.Forms.Label();
			this.cbxHashMethod = new System.Windows.Forms.ComboBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.chkFromFile = new System.Windows.Forms.CheckBox();
			this.lblEncoding = new System.Windows.Forms.Label();
			this.cbxEncoding = new System.Windows.Forms.ComboBox();
			this.gbxSourceText = new System.Windows.Forms.GroupBox();
			this.txtSourceText = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize) (this.scMain)).BeginInit();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.gbxSourceText.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scMain.Location = new System.Drawing.Point(0, 0);
			this.scMain.Name = "scMain";
			this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.cbxEncoding);
			this.scMain.Panel1.Controls.Add(this.lblEncoding);
			this.scMain.Panel1.Controls.Add(this.chkFromFile);
			this.scMain.Panel1.Controls.Add(this.txtResult);
			this.scMain.Panel1.Controls.Add(this.lblResult);
			this.scMain.Panel1.Controls.Add(this.cbxHashMethod);
			this.scMain.Panel1.Controls.Add(this.lblHashMethod);
			this.scMain.Panel1.Controls.Add(this.btnRunTest);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.gbxSourceText);
			this.scMain.Size = new System.Drawing.Size(743, 487);
			this.scMain.SplitterDistance = 104;
			this.scMain.TabIndex = 0;
			// 
			// btnRunTest
			// 
			this.btnRunTest.Location = new System.Drawing.Point(9, 8);
			this.btnRunTest.Name = "btnRunTest";
			this.btnRunTest.Size = new System.Drawing.Size(63, 44);
			this.btnRunTest.TabIndex = 0;
			this.btnRunTest.Text = "&Run Test";
			this.btnRunTest.UseVisualStyleBackColor = true;
			this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
			// 
			// lblHashMethod
			// 
			this.lblHashMethod.AutoSize = true;
			this.lblHashMethod.Location = new System.Drawing.Point(91, 9);
			this.lblHashMethod.Name = "lblHashMethod";
			this.lblHashMethod.Size = new System.Drawing.Size(71, 13);
			this.lblHashMethod.TabIndex = 1;
			this.lblHashMethod.Text = "Hash Method";
			// 
			// cbxHashMethod
			// 
			this.cbxHashMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxHashMethod.FormattingEnabled = true;
			this.cbxHashMethod.Location = new System.Drawing.Point(176, 6);
			this.cbxHashMethod.Name = "cbxHashMethod";
			this.cbxHashMethod.Size = new System.Drawing.Size(148, 21);
			this.cbxHashMethod.TabIndex = 2;
			// 
			// lblResult
			// 
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(47, 79);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(37, 13);
			this.lblResult.TabIndex = 3;
			this.lblResult.Text = "Result";
			// 
			// txtResult
			// 
			this.txtResult.BackColor = System.Drawing.SystemColors.Window;
			this.txtResult.Location = new System.Drawing.Point(93, 29);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ReadOnly = true;
			this.txtResult.Size = new System.Drawing.Size(639, 63);
			this.txtResult.TabIndex = 4;
			// 
			// chkFromFile
			// 
			this.chkFromFile.AutoSize = true;
			this.chkFromFile.Location = new System.Drawing.Point(572, 9);
			this.chkFromFile.Name = "chkFromFile";
			this.chkFromFile.Size = new System.Drawing.Size(68, 17);
			this.chkFromFile.TabIndex = 5;
			this.chkFromFile.Text = "From File";
			this.chkFromFile.UseVisualStyleBackColor = true;
			// 
			// lblEncoding
			// 
			this.lblEncoding.AutoSize = true;
			this.lblEncoding.Location = new System.Drawing.Point(338, 9);
			this.lblEncoding.Name = "lblEncoding";
			this.lblEncoding.Size = new System.Drawing.Size(52, 13);
			this.lblEncoding.TabIndex = 6;
			this.lblEncoding.Text = "Encoding";
			// 
			// cbxEncoding
			// 
			this.cbxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxEncoding.FormattingEnabled = true;
			this.cbxEncoding.Location = new System.Drawing.Point(398, 6);
			this.cbxEncoding.Name = "cbxEncoding";
			this.cbxEncoding.Size = new System.Drawing.Size(148, 21);
			this.cbxEncoding.TabIndex = 7;
			// 
			// gbxSourceText
			// 
			this.gbxSourceText.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbxSourceText.Controls.Add(this.txtSourceText);
			this.gbxSourceText.Location = new System.Drawing.Point(6, 7);
			this.gbxSourceText.Name = "gbxSourceText";
			this.gbxSourceText.Size = new System.Drawing.Size(732, 368);
			this.gbxSourceText.TabIndex = 1;
			this.gbxSourceText.TabStop = false;
			this.gbxSourceText.Text = "Source Text";
			// 
			// txtSourceText
			// 
			this.txtSourceText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSourceText.Location = new System.Drawing.Point(3, 16);
			this.txtSourceText.Multiline = true;
			this.txtSourceText.Name = "txtSourceText";
			this.txtSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSourceText.Size = new System.Drawing.Size(726, 349);
			this.txtSourceText.TabIndex = 1;
			// 
			// frmHasher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(743, 487);
			this.Controls.Add(this.scMain);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(759, 526);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(759, 526);
			this.Name = "frmHasher";
			this.Text = "frmHasher";
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel1.PerformLayout();
			this.scMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this.scMain)).EndInit();
			this.scMain.ResumeLayout(false);
			this.gbxSourceText.ResumeLayout(false);
			this.gbxSourceText.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer scMain;
		private System.Windows.Forms.Button btnRunTest;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.ComboBox cbxHashMethod;
		private System.Windows.Forms.Label lblHashMethod;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.CheckBox chkFromFile;
		private System.Windows.Forms.ComboBox cbxEncoding;
		private System.Windows.Forms.Label lblEncoding;
		private System.Windows.Forms.GroupBox gbxSourceText;
		private System.Windows.Forms.TextBox txtSourceText;
	}
}