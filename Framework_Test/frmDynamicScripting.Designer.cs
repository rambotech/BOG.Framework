namespace BOG.Framework_Test
{
	partial class frmDynamicScripting
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
			this.txtResults = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtResults
			// 
			this.txtResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtResults.Location = new System.Drawing.Point(0, 0);
			this.txtResults.Multiline = true;
			this.txtResults.Name = "txtResults";
			this.txtResults.ReadOnly = true;
			this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtResults.Size = new System.Drawing.Size(624, 357);
			this.txtResults.TabIndex = 1;
			this.txtResults.Text = "using System;\r\n\r\npublic class DemoSet3\r\n{\r\n  string Process\r\n\r\n}";
			this.txtResults.WordWrap = false;
			// 
			// frmDynamicScripting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 357);
			this.Controls.Add(this.txtResults);
			this.Name = "frmDynamicScripting";
			this.Text = "frmDynamicScripting";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtResults;
	}
}