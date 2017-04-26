namespace BOG.Framework_Test
{
	partial class frmCipherUtility
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
			this.lblEncryptionMethod = new System.Windows.Forms.Label();
			this.cbxEncryptionMethod = new System.Windows.Forms.ComboBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.lblSalt = new System.Windows.Forms.Label();
			this.lblSource = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnRndPassword = new System.Windows.Forms.Button();
			this.txtSalt = new System.Windows.Forms.TextBox();
			this.btnRndSalt = new System.Windows.Forms.Button();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.txtResult = new System.Windows.Forms.TextBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnSwitchSourceAndResult = new System.Windows.Forms.Button();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.btnDecrypt = new System.Windows.Forms.Button();
			this.rbString = new System.Windows.Forms.RadioButton();
			this.rbByteArray = new System.Windows.Forms.RadioButton();
			this.chkBase64LineBreaks = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lblEncryptionMethod
			// 
			this.lblEncryptionMethod.AutoSize = true;
			this.lblEncryptionMethod.Location = new System.Drawing.Point(18, 15);
			this.lblEncryptionMethod.Name = "lblEncryptionMethod";
			this.lblEncryptionMethod.Size = new System.Drawing.Size(99, 13);
			this.lblEncryptionMethod.TabIndex = 0;
			this.lblEncryptionMethod.Text = "Encryption Method:";
			// 
			// cbxEncryptionMethod
			// 
			this.cbxEncryptionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxEncryptionMethod.FormattingEnabled = true;
			this.cbxEncryptionMethod.Location = new System.Drawing.Point(123, 12);
			this.cbxEncryptionMethod.Name = "cbxEncryptionMethod";
			this.cbxEncryptionMethod.Size = new System.Drawing.Size(531, 21);
			this.cbxEncryptionMethod.TabIndex = 1;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(36, 42);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(82, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Password (key):";
			// 
			// lblSalt
			// 
			this.lblSalt.AutoSize = true;
			this.lblSalt.Location = new System.Drawing.Point(89, 68);
			this.lblSalt.Name = "lblSalt";
			this.lblSalt.Size = new System.Drawing.Size(28, 13);
			this.lblSalt.TabIndex = 3;
			this.lblSalt.Text = "Salt:";
			// 
			// lblSource
			// 
			this.lblSource.AutoSize = true;
			this.lblSource.Location = new System.Drawing.Point(17, 97);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(41, 13);
			this.lblSource.TabIndex = 4;
			this.lblSource.Text = "Source";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(123, 39);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(450, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// btnRndPassword
			// 
			this.btnRndPassword.Location = new System.Drawing.Point(533, 37);
			this.btnRndPassword.Name = "btnRndPassword";
			this.btnRndPassword.Size = new System.Drawing.Size(121, 23);
			this.btnRndPassword.TabIndex = 6;
			this.btnRndPassword.Text = "Generate";
			this.btnRndPassword.UseVisualStyleBackColor = true;
			this.btnRndPassword.Click += new System.EventHandler(this.btnRndPassword_Click);
			// 
			// txtSalt
			// 
			this.txtSalt.Location = new System.Drawing.Point(123, 65);
			this.txtSalt.Name = "txtSalt";
			this.txtSalt.Size = new System.Drawing.Size(450, 20);
			this.txtSalt.TabIndex = 7;
			// 
			// btnRndSalt
			// 
			this.btnRndSalt.Location = new System.Drawing.Point(533, 63);
			this.btnRndSalt.Name = "btnRndSalt";
			this.btnRndSalt.Size = new System.Drawing.Size(121, 23);
			this.btnRndSalt.TabIndex = 8;
			this.btnRndSalt.Text = "Generate";
			this.btnRndSalt.UseVisualStyleBackColor = true;
			this.btnRndSalt.Click += new System.EventHandler(this.btnRndSalt_Click);
			// 
			// txtSource
			// 
			this.txtSource.Location = new System.Drawing.Point(92, 91);
			this.txtSource.Multiline = true;
			this.txtSource.Name = "txtSource";
			this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtSource.Size = new System.Drawing.Size(562, 106);
			this.txtSource.TabIndex = 9;
			this.txtSource.Text = "The quick brown fox jumped over the lazy dog\'s back.\r\n\r\n";
			// 
			// txtResult
			// 
			this.txtResult.Location = new System.Drawing.Point(92, 232);
			this.txtResult.Multiline = true;
			this.txtResult.Name = "txtResult";
			this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtResult.Size = new System.Drawing.Size(562, 108);
			this.txtResult.TabIndex = 11;
			// 
			// lblResult
			// 
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(17, 238);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(37, 13);
			this.lblResult.TabIndex = 10;
			this.lblResult.Text = "Result";
			// 
			// btnSwitchSourceAndResult
			// 
			this.btnSwitchSourceAndResult.Location = new System.Drawing.Point(92, 203);
			this.btnSwitchSourceAndResult.Name = "btnSwitchSourceAndResult";
			this.btnSwitchSourceAndResult.Size = new System.Drawing.Size(96, 23);
			this.btnSwitchSourceAndResult.TabIndex = 12;
			this.btnSwitchSourceAndResult.Text = "Switch";
			this.btnSwitchSourceAndResult.UseVisualStyleBackColor = true;
			this.btnSwitchSourceAndResult.Click += new System.EventHandler(this.btnSwitchSourceAndResult_Click);
			// 
			// btnEncrypt
			// 
			this.btnEncrypt.Location = new System.Drawing.Point(456, 203);
			this.btnEncrypt.Name = "btnEncrypt";
			this.btnEncrypt.Size = new System.Drawing.Size(96, 23);
			this.btnEncrypt.TabIndex = 13;
			this.btnEncrypt.Text = "Encrypt";
			this.btnEncrypt.UseVisualStyleBackColor = true;
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			// 
			// btnDecrypt
			// 
			this.btnDecrypt.Location = new System.Drawing.Point(558, 203);
			this.btnDecrypt.Name = "btnDecrypt";
			this.btnDecrypt.Size = new System.Drawing.Size(96, 23);
			this.btnDecrypt.TabIndex = 14;
			this.btnDecrypt.Text = "Decrypt";
			this.btnDecrypt.UseVisualStyleBackColor = true;
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			// 
			// rbString
			// 
			this.rbString.AutoSize = true;
			this.rbString.Checked = true;
			this.rbString.Location = new System.Drawing.Point(12, 290);
			this.rbString.Name = "rbString";
			this.rbString.Size = new System.Drawing.Size(52, 17);
			this.rbString.TabIndex = 17;
			this.rbString.TabStop = true;
			this.rbString.Text = "String";
			this.rbString.UseVisualStyleBackColor = true;
			this.rbString.CheckedChanged += new System.EventHandler(this.rbString_CheckedChanged);
			// 
			// rbByteArray
			// 
			this.rbByteArray.AutoSize = true;
			this.rbByteArray.Location = new System.Drawing.Point(13, 267);
			this.rbByteArray.Name = "rbByteArray";
			this.rbByteArray.Size = new System.Drawing.Size(51, 17);
			this.rbByteArray.TabIndex = 18;
			this.rbByteArray.TabStop = true;
			this.rbByteArray.Text = "byte[]";
			this.rbByteArray.UseVisualStyleBackColor = true;
			this.rbByteArray.CheckedChanged += new System.EventHandler(this.rbByteArray_CheckedChanged);
			// 
			// chkBase64LineBreaks
			// 
			this.chkBase64LineBreaks.AutoSize = true;
			this.chkBase64LineBreaks.Location = new System.Drawing.Point(12, 313);
			this.chkBase64LineBreaks.Name = "chkBase64LineBreaks";
			this.chkBase64LineBreaks.Size = new System.Drawing.Size(77, 17);
			this.chkBase64LineBreaks.TabIndex = 19;
			this.chkBase64LineBreaks.Text = "line breaks";
			this.chkBase64LineBreaks.UseVisualStyleBackColor = true;
			// 
			// frmCipherUtility
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(666, 350);
			this.Controls.Add(this.chkBase64LineBreaks);
			this.Controls.Add(this.rbByteArray);
			this.Controls.Add(this.rbString);
			this.Controls.Add(this.btnDecrypt);
			this.Controls.Add(this.btnEncrypt);
			this.Controls.Add(this.btnSwitchSourceAndResult);
			this.Controls.Add(this.txtResult);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.txtSource);
			this.Controls.Add(this.btnRndSalt);
			this.Controls.Add(this.txtSalt);
			this.Controls.Add(this.btnRndPassword);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.lblSource);
			this.Controls.Add(this.lblSalt);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.cbxEncryptionMethod);
			this.Controls.Add(this.lblEncryptionMethod);
			this.Name = "frmCipherUtility";
			this.Text = "CipherUtility";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEncryptionMethod;
		private System.Windows.Forms.ComboBox cbxEncryptionMethod;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.Label lblSalt;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Button btnRndPassword;
		private System.Windows.Forms.TextBox txtSalt;
		private System.Windows.Forms.Button btnRndSalt;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.Label lblResult;
		private System.Windows.Forms.Button btnSwitchSourceAndResult;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.Button btnDecrypt;
		private System.Windows.Forms.RadioButton rbString;
		private System.Windows.Forms.RadioButton rbByteArray;
		private System.Windows.Forms.CheckBox chkBase64LineBreaks;
	}
}