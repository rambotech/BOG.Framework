namespace BOG.Framework_Test
{
	partial class frmLogger
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLogFilePath = new System.Windows.Forms.TextBox();
			this.txtLogFileNamePattern = new System.Windows.Forms.TextBox();
			this.lbxLoggedContents = new System.Windows.Forms.ListBox();
			this.btnLog = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Log File Path";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Log File Name Pattern";
			// 
			// txtLogFilePath
			// 
			this.txtLogFilePath.Location = new System.Drawing.Point(208, 6);
			this.txtLogFilePath.Name = "txtLogFilePath";
			this.txtLogFilePath.Size = new System.Drawing.Size(659, 22);
			this.txtLogFilePath.TabIndex = 2;
			// 
			// txtLogFileNamePattern
			// 
			this.txtLogFileNamePattern.Location = new System.Drawing.Point(208, 37);
			this.txtLogFileNamePattern.Name = "txtLogFileNamePattern";
			this.txtLogFileNamePattern.Size = new System.Drawing.Size(659, 22);
			this.txtLogFileNamePattern.TabIndex = 3;
			// 
			// lbxLoggedContents
			// 
			this.lbxLoggedContents.FormattingEnabled = true;
			this.lbxLoggedContents.ItemHeight = 16;
			this.lbxLoggedContents.Location = new System.Drawing.Point(15, 73);
			this.lbxLoggedContents.Name = "lbxLoggedContents";
			this.lbxLoggedContents.Size = new System.Drawing.Size(852, 308);
			this.lbxLoggedContents.TabIndex = 4;
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point(408, 383);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(122, 31);
			this.btnLog.TabIndex = 5;
			this.btnLog.Text = "&Start";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmLogger
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(879, 418);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.lbxLoggedContents);
			this.Controls.Add(this.txtLogFileNamePattern);
			this.Controls.Add(this.txtLogFilePath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmLogger";
			this.Text = "Logger";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLogFilePath;
		private System.Windows.Forms.TextBox txtLogFileNamePattern;
		private System.Windows.Forms.ListBox lbxLoggedContents;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.Timer timer1;
	}
}