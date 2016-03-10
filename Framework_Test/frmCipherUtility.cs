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
        private string ValidCharacters =
            "0123456789ABCDEFGHIJKLMNOPQURSTUVWXYZabcdefghijklmnopqurstuvwxyz" +
            "\"':;<,>./?{[}]=+-_\\!@#$%^&*()";

        public frmCipherUtility()
        {
            InitializeComponent();
            this.cbxEncryptionMethod.Items.Add("AesManaged");
            this.cbxEncryptionMethod.Items.Add("TripleDESCryptoServiceProvider");
            this.cbxEncryptionMethod.Items.Add("RijndaelManaged");
            this.cbxEncryptionMethod.SelectedIndex = 0;
        }

        private string RandomString()
        {
            StringBuilder result = new StringBuilder();
            DateTime now = DateTime.Now;
            Random r = new Random(
                now.Millisecond + now.Second * 1000 + now.Minute * 60000 + now.Hour * 3600000
                + (now.DayOfYear % 25) * 86400000);
            int length = r.Next(33) + 18;
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
            switch (this.cbxEncryptionMethod.SelectedIndex)
            {
                case 0:
                    this.txtResult.Text = CipherUtility.Encrypt<AesManaged>(
                        this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
                    break;
                case 1:
                    this.txtResult.Text = CipherUtility.Encrypt<TripleDESCryptoServiceProvider>(
                        this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
                    break;
                case 2:
                    this.txtResult.Text = CipherUtility.Encrypt<RijndaelManaged>(
                        this.txtSource.Text, this.txtPassword.Text, this.txtSalt.Text);
                    break;
                default:
                    MessageBox.Show("Unsupported encryption type in selection list.");
                    break;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
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

        private void AutoCrypt(bool asEncrypted)
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

        private void btnAutoToDecrypted_Click(object sender, EventArgs e)
        {
            AutoCrypt(false);
        }

        private void btnAutoToEncrypted_Click(object sender, EventArgs e)
        {
            AutoCrypt(true);
        }
    }
}
