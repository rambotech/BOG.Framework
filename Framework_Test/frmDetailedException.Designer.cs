namespace BOG.Framework_Test
{
	partial class frmDetailedException
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
			this.btnTestIt = new System.Windows.Forms.Button();
			this.txtResultError = new System.Windows.Forms.TextBox();
			this.txtErrorMessage = new System.Windows.Forms.TextBox();
			this.lblErrorMessage = new System.Windows.Forms.Label();
			this.cbxDetailLevel = new System.Windows.Forms.ComboBox();
			this.lblDetailLevel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHeader = new System.Windows.Forms.TextBox();
			this.txtFooter = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnTestIt
			// 
			this.btnTestIt.Location = new System.Drawing.Point(290, 99);
			this.btnTestIt.Name = "btnTestIt";
			this.btnTestIt.Size = new System.Drawing.Size(474, 23);
			this.btnTestIt.TabIndex = 7;
			this.btnTestIt.Text = "Test It";
			this.btnTestIt.UseVisualStyleBackColor = true;
			this.btnTestIt.Click += new System.EventHandler(this.btnTestIt_Click);
			// 
			// txtResultError
			// 
			this.txtResultError.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.txtResultError.Location = new System.Drawing.Point(12, 154);
			this.txtResultError.Multiline = true;
			this.txtResultError.Name = "txtResultError";
			this.txtResultError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResultError.Size = new System.Drawing.Size(757, 233);
			this.txtResultError.TabIndex = 6;
			// 
			// txtErrorMessage
			// 
			this.txtErrorMessage.Location = new System.Drawing.Point(12, 22);
			this.txtErrorMessage.Multiline = true;
			this.txtErrorMessage.Name = "txtErrorMessage";
			this.txtErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtErrorMessage.Size = new System.Drawing.Size(757, 70);
			this.txtErrorMessage.TabIndex = 5;
			this.txtErrorMessage.Text = "Some code you wrote made the system sad";
			// 
			// lblErrorMessage
			// 
			this.lblErrorMessage.AutoSize = true;
			this.lblErrorMessage.Location = new System.Drawing.Point(9, 5);
			this.lblErrorMessage.Name = "lblErrorMessage";
			this.lblErrorMessage.Size = new System.Drawing.Size(88, 15);
			this.lblErrorMessage.TabIndex = 4;
			this.lblErrorMessage.Text = "Error Message";
			// 
			// cbxDetailLevel
			// 
			this.cbxDetailLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDetailLevel.FormattingEnabled = true;
			this.cbxDetailLevel.Items.AddRange(new object[] {
			"WithUserContent",
			"WithMachineContent",
			"WithEnterpriseContent"});
			this.cbxDetailLevel.Location = new System.Drawing.Point(90, 101);
			this.cbxDetailLevel.Name = "cbxDetailLevel";
			this.cbxDetailLevel.Size = new System.Drawing.Size(181, 21);
			this.cbxDetailLevel.TabIndex = 8;
			// 
			// lblDetailLevel
			// 
			this.lblDetailLevel.AutoSize = true;
			this.lblDetailLevel.Location = new System.Drawing.Point(18, 104);
			this.lblDetailLevel.Name = "lblDetailLevel";
			this.lblDetailLevel.Size = new System.Drawing.Size(74, 15);
			this.lblDetailLevel.TabIndex = 9;
			this.lblDetailLevel.Text = "Detail Level:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 135);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 15);
			this.label1.TabIndex = 10;
			this.label1.Text = "Header (optional):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(394, 135);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 11;
			this.label2.Text = "Footer (optional):";
			// 
			// txtHeader
			// 
			this.txtHeader.Location = new System.Drawing.Point(118, 132);
			this.txtHeader.Name = "txtHeader";
			this.txtHeader.Size = new System.Drawing.Size(247, 20);
			this.txtHeader.TabIndex = 12;
			this.txtHeader.Text = "Start of my error";
			// 
			// txtFooter
			// 
			this.txtFooter.Location = new System.Drawing.Point(486, 132);
			this.txtFooter.Name = "txtFooter";
			this.txtFooter.Size = new System.Drawing.Size(247, 20);
			this.txtFooter.TabIndex = 13;
			this.txtFooter.Text = "Footnotes to my error";
			// 
			// frmDetailedException
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(776, 395);
			this.Controls.Add(this.txtFooter);
			this.Controls.Add(this.txtHeader);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblDetailLevel);
			this.Controls.Add(this.cbxDetailLevel);
			this.Controls.Add(this.btnTestIt);
			this.Controls.Add(this.txtResultError);
			this.Controls.Add(this.txtErrorMessage);
			this.Controls.Add(this.lblErrorMessage);
			this.Name = "frmDetailedException";
			this.Text = "frmDetailedException";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnTestIt;
		private System.Windows.Forms.TextBox txtResultError;
		private System.Windows.Forms.TextBox txtErrorMessage;
		private System.Windows.Forms.Label lblErrorMessage;
		private System.Windows.Forms.ComboBox cbxDetailLevel;
		private System.Windows.Forms.Label lblDetailLevel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtHeader;
		private System.Windows.Forms.TextBox txtFooter;
	}
}