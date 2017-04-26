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
using System.Reflection;

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
			HydrateSymmetricAlgorithmClasses();
			if (this.cbxEncryptionMethod.Items.Count > 0)
			{
				this.cbxEncryptionMethod.SelectedIndex = 0;
			}
		}

		private void HydrateSymmetricAlgorithmClasses()
		{
			var type = typeof(SymmetricAlgorithm);
			foreach (Type thisType in AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p)).Where(t => type.IsClass))
			{
				if (!thisType.IsAbstract && thisType.IsAnsiClass)
				{
					if (thisType.Name.Contains("Managed") || thisType.Name.Contains("Provider"))
					{
						this.cbxEncryptionMethod.Items.Add(thisType.ToString());
					}
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
				var type = Type.GetType((string) this.cbxEncryptionMethod.Items[this.cbxEncryptionMethod.SelectedIndex]);
				var cipher = new CipherUtility((System.Security.Cryptography.SymmetricAlgorithm) Activator.CreateInstance(type));
				if (this.rbString.Checked)
				{
					this.txtResult.Text = cipher.Encrypt(
						this.txtSource.Text,
						this.txtPassword.Text,
						this.txtSalt.Text,
						this.chkBase64LineBreaks.Checked ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);

				}
				else
				{
					this.txtResult.Text = cipher.EncryptByteArray(
						Encoding.UTF8.GetBytes(this.txtSource.Text),
						this.txtPassword.Text,
						this.txtSalt.Text,
						this.chkBase64LineBreaks.Checked ? Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);
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
				var type = Type.GetType((string) this.cbxEncryptionMethod.Items[this.cbxEncryptionMethod.SelectedIndex]);
				var cipher = new CipherUtility((System.Security.Cryptography.SymmetricAlgorithm) Activator.CreateInstance(type));
				if (this.rbString.Checked)
				{
					this.txtResult.Text = cipher.Decrypt(this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
				}
				else
				{
					this.txtResult.Text = Encoding.UTF8.GetString(
						cipher.DecryptByteArray(
							this.txtSource.Text,
							this.txtPassword.Text,
							this.txtSalt.Text));
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(BOG.Framework.DetailedException.WithUserContent(ref err), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void rbString_CheckedChanged(object sender, EventArgs e)
		{
			this.chkBase64LineBreaks.Enabled = true;
		}

		private void rbByteArray_CheckedChanged(object sender, EventArgs e)
		{
			this.chkBase64LineBreaks.Enabled = false;
		}
	}
}
