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
			this.tabsMain = new System.Windows.Forms.TabControl();
			this.tabCompiler = new System.Windows.Forms.TabPage();
			this.scCompilerMain = new System.Windows.Forms.SplitContainer();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tabLoadAndExecute = new System.Windows.Forms.TabPage();
			this.tabsMain.SuspendLayout();
			this.tabCompiler.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scCompilerMain)).BeginInit();
			this.scCompilerMain.Panel1.SuspendLayout();
			this.scCompilerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabsMain
			// 
			this.tabsMain.Controls.Add(this.tabCompiler);
			this.tabsMain.Controls.Add(this.tabLoadAndExecute);
			this.tabsMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabsMain.Location = new System.Drawing.Point(0, 0);
			this.tabsMain.Name = "tabsMain";
			this.tabsMain.SelectedIndex = 0;
			this.tabsMain.Size = new System.Drawing.Size(624, 357);
			this.tabsMain.TabIndex = 0;
			// 
			// tabCompiler
			// 
			this.tabCompiler.Controls.Add(this.scCompilerMain);
			this.tabCompiler.Location = new System.Drawing.Point(4, 22);
			this.tabCompiler.Name = "tabCompiler";
			this.tabCompiler.Padding = new System.Windows.Forms.Padding(3);
			this.tabCompiler.Size = new System.Drawing.Size(616, 331);
			this.tabCompiler.TabIndex = 0;
			this.tabCompiler.Text = "Compiler";
			this.tabCompiler.UseVisualStyleBackColor = true;
			// 
			// scCompilerMain
			// 
			this.scCompilerMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scCompilerMain.Location = new System.Drawing.Point(3, 3);
			this.scCompilerMain.Name = "scCompilerMain";
			this.scCompilerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scCompilerMain.Panel1
			// 
			this.scCompilerMain.Panel1.Controls.Add(this.textBox1);
			this.scCompilerMain.Size = new System.Drawing.Size(610, 325);
			this.scCompilerMain.SplitterDistance = 284;
			this.scCompilerMain.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(610, 284);
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "using System;\r\n\r\npublic class DemoSet3\r\n{\r\n  string Process\r\n\r\n}";
			this.textBox1.WordWrap = false;
			// 
			// tabLoadAndExecute
			// 
			this.tabLoadAndExecute.Location = new System.Drawing.Point(4, 22);
			this.tabLoadAndExecute.Name = "tabLoadAndExecute";
			this.tabLoadAndExecute.Padding = new System.Windows.Forms.Padding(3);
			this.tabLoadAndExecute.Size = new System.Drawing.Size(616, 331);
			this.tabLoadAndExecute.TabIndex = 1;
			this.tabLoadAndExecute.Text = "Load and Execute";
			this.tabLoadAndExecute.UseVisualStyleBackColor = true;
			// 
			// frmDynamicScripting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 357);
			this.Controls.Add(this.tabsMain);
			this.Name = "frmDynamicScripting";
			this.Text = "frmDynamicScripting";
			this.tabsMain.ResumeLayout(false);
			this.tabCompiler.ResumeLayout(false);
			this.scCompilerMain.Panel1.ResumeLayout(false);
			this.scCompilerMain.Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scCompilerMain)).EndInit();
			this.scCompilerMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabsMain;
		private System.Windows.Forms.TabPage tabCompiler;
		private System.Windows.Forms.TabPage tabLoadAndExecute;
		private System.Windows.Forms.SplitContainer scCompilerMain;
		private System.Windows.Forms.TextBox textBox1;
	}
}