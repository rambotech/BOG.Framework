using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmCipherUtility : Form
	{
		const string ValidCharacters =
			"0123456789ABCDEFGHIJKLMNOPQURSTUVWXYZabcdefghijklmnopqurstuvwxyz" +
			"\"':;<,>./?{[}]=+-_\\!@#$%^&*()";

		public frmCipherUtility()
		{
			InitializeComponent();
			//HydrateSymmetricAlgorithmClasses();

			this.cbxEncryptionMethod.Items.Add("AesManaged");
			this.cbxEncryptionMethod.Items.Add("TripleDESCryptoServiceProvider");
			this.cbxEncryptionMethod.Items.Add("RijndaelManaged");
			this.cbxEncryptionMethod.SelectedIndex = 0;
		}

		private void HydrateSymmetricAlgorithmClasses()
		{
			var type = typeof(SymmetricAlgorithm);
			foreach (Type thisType in AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p)))
			{
				foreach (Type usableType in AppDomain.CurrentDomain.GetAssemblies()
					.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(thisType)).Where(t => type.IsAbstract == false))
				{
					this.cbxEncryptionMethod.Items.Add(usableType.ToString());
				}
			}
		}

		private string RandomString()
		{
			StringBuilder result = new StringBuilder();
			DateTime now = DateTime.Now;
			Random r = new Random(
				now.Millisecond + now.Second * 1000 + now.Minute * 60000 + now.Hour * 3600000
				+ (now.DayOfYear % 25) * 86400000);
			int length = r.Next(18, 50);
			for (int index = 0; index < length; index++)
				result.Append(ValidCharacters.Substring(r.Next(ValidCharacters.Length), 1));
			return result.ToString();
		}

		private void btnRndPassword_Click(object sender, EventArgs e)
		{
			this.txtPassword.Text = RandomString();
		}

		private void btnRndSalt_Click(object sender, EventArgs e)
		{
			this.txtSalt.Text = RandomString();
		}

		private void btnSwitchSourceAndResult_Click(object sender, EventArgs e)
		{
			string temp = this.txtSource.Text;
			this.txtSource.Text = this.txtResult.Text;
			this.txtResult.Text = temp;
		}

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.rbString.Checked)
				{
					switch (this.cbxEncryptionMethod.SelectedIndex)
					{
						case 0:
							this.txtResult.Text = CipherUtility.Encrypt<AesManaged>(
								this.txtSource.Text,
								this.txtPassword.Text,
								this.txtSalt.Text,
								this.chkBase64LineBreaks.Checked ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);
							break;
						case 1:
							this.txtResult.Text = CipherUtility.Encrypt<TripleDESCryptoServiceProvider>(
								this.txtSource.Text,
								this.txtPassword.Text,
								this.txtSalt.Text,
								this.chkBase64LineBreaks.Checked ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);
							break;
						case 2:
							this.txtResult.Text = CipherUtility.Encrypt<RijndaelManaged>(
								this.txtSource.Text,
								this.txtPassword.Text,
								this.txtSalt.Text,
								this.chkBase64LineBreaks.Checked ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);
							break;
						default:
							MessageBox.Show("Unsupported encryption type in selection list.");
							break;
					}
				}
				else
				{
					switch (this.cbxEncryptionMethod.SelectedIndex)
					{
						case 0:
							this.txtResult.Text = CipherUtility.EncryptByteArray<AesManaged>(
								Encoding.UTF8.GetBytes(this.txtSource.Text), this.txtPassword.Text, this.txtSalt.Text);
							break;
						case 1:
							this.txtResult.Text = CipherUtility.EncryptByteArray<TripleDESCryptoServiceProvider>(
								Encoding.UTF8.GetBytes(this.txtSource.Text), this.txtPassword.Text, this.txtSalt.Text);
							break;
						case 2:
							this.txtResult.Text = CipherUtility.EncryptByteArray<RijndaelManaged>(
								Encoding.UTF8.GetBytes(this.txtSource.Text), this.txtPassword.Text, this.txtSalt.Text);
							break;
						default:
							MessageBox.Show("Unsupported encryption type in selection list.");
							break;
					}
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(BOG.Framework.DetailedException.WithUserContent(ref err), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.rbString.Checked)
				{
					switch (this.cbxEncryptionMethod.SelectedIndex)
					{
						case 0:
							this.txtResult.Text = CipherUtility.Decrypt<AesManaged>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
							break;
						case 1:
							this.txtResult.Text = CipherUtility.Decrypt<TripleDESCryptoServiceProvider>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
							break;
						case 2:
							this.txtResult.Text = CipherUtility.Decrypt<RijndaelManaged>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
							break;
						default:
							MessageBox.Show("Unsupported encryption type in selection list.");
							break;
					}
				}
				else
				{
					switch (this.cbxEncryptionMethod.SelectedIndex)
					{
						case 0:
							this.txtResult.Text = Encoding.UTF8.GetString(CipherUtility.DecryptByteArray<AesManaged>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text));
							break;
						case 1:
							this.txtResult.Text = Encoding.UTF8.GetString(CipherUtility.DecryptByteArray<TripleDESCryptoServiceProvider>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text));
							break;
						case 2:
							this.txtResult.Text = Encoding.UTF8.GetString(CipherUtility.DecryptByteArray<RijndaelManaged>(
								this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text));
							break;
						default:
							MessageBox.Show("Unsupported encryption type in selection list.");
							break;
					}
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(BOG.Framework.DetailedException.WithUserContent(ref err), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void AutoCrypt(bool asEncrypted)
		{
			try
			{
				CipherUtility.ValueState target = asEncrypted
					? CipherUtility.ValueState.Encrypted : CipherUtility.ValueState.Decrypted;
				switch (this.cbxEncryptionMethod.SelectedIndex)
				{
					case 0:
						this.txtResult.Text = CipherUtility.AutoCrypt<AesManaged>(
							this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text, target);
						break;
					case 1:
						this.txtResult.Text = CipherUtility.AutoCrypt<TripleDESCryptoServiceProvider>(
							this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text, target);
						break;
					case 2:
						this.txtResult.Text = CipherUtility.AutoCrypt<RijndaelManaged>(
							this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text, target);
						break;
					default:
						MessageBox.Show("Unsupported encryption type in selection list.");
						break;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(BOG.Framework.DetailedException.WithUserContent(ref err), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnAutoToDecrypted_Click(object sender, EventArgs e)
		{
			AutoCrypt(false);
		}

		private void btnAutoToEncrypted_Click(object sender, EventArgs e)
		{
			AutoCrypt(true);
		}

		private void rbString_CheckedChanged(object sender, EventArgs e)
		{
			this.btnAutoToDecrypted.Enabled = true;
			this.btnAutoToEncrypted.Enabled = true;
			this.chkBase64LineBreaks.Enabled = true;
		}

		private void rbByteArray_CheckedChanged(object sender, EventArgs e)
		{
			this.btnAutoToDecrypted.Enabled = false;
			this.btnAutoToEncrypted.Enabled = false;
			this.chkBase64LineBreaks.Enabled = false;
		}

		private void chkBase64LineBreaks_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
