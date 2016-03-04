using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
    public partial class frmStringEx : Form
    {
        public frmStringEx()
        {
            InitializeComponent();
            this.cbxMethodStrStr.Items.Add("Base64Encode");
            this.cbxMethodStrStr.Items.Add("Base64Decode");
            this.cbxMethodStrStr.Items.Add("ShowStringAsHex");
            this.cbxMethodStrStr.Items.Add("TextAsInnerText");
            this.cbxMethodStrStr.SelectedIndex = 0;
        }

        private void btnTestIt_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.cbxMethodStrStr.SelectedIndex)
                {
                    case 0:
                        this.txtOutputStrStr.Text = StringEx.Base64EncodeString(this.txtInputStrStr.Text);
                        break;

                    case 1:
                        this.txtOutputStrStr.Text = StringEx.Base64DecodeString(this.txtInputStrStr.Text);
                        break;

                    case 2:
                        this.txtOutputStrStr.Text = StringEx.ShowStringAsHex(this.txtInputStrStr.Text);
                        break;

                    case 3:
                        this.txtOutputStrStr.Text = StringEx.TextAsInnerText(this.txtInputStrStr.Text);
                        break;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(DetailedException.WithUserContent(ref err));
            }
        }

        private void cbxMethodStrStr_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbxMethodStrStr.SelectedIndex)
            {
                case 0:
                    this.txtInputStrStr.Text = "The quick brown fox jumped over the lazy dog's back: so there !!";
                    break;

                case 1:
                    this.txtInputStrStr.Text = "VGhhbmtzLi4uIG5vdyBJIGFtIGV4cG9zZWQgdG8gdGhlIHdvcmxkIQ==";
                    break;

                case 2:
                    this.txtInputStrStr.Text = "ABCDEFGHIJKLMNOP\r\nQRSTUVWXYZ\t0123456789";
                    break;

                case 3:
                    this.txtInputStrStr.Text = "&#x24;43,&#55;56.42  which is $43,756.42   .. defeats web sites which try to stop scrapers with encoded characters.";
                    break;
            }
        }
    }
}
