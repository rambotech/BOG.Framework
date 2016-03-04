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
    public partial class frmScrape : Form
    {
        public frmScrape()
        {
            InitializeComponent();
        }

        private void btnTestHttpCaptureText_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnTestHttpCaptureText.Enabled = false;
            this.toolStripStatusLabel1.Text = "Loading URL ...";
            this.groupBox1.Text = string.Empty;
            this.txtURL.Enabled = false;
            this.txtCaptureRURL.Enabled = false;
            this.Refresh();

            string capture = string.Empty;
            try
            {
                WebScrapeResponse r = s.HttpCapture(this.txtURL.Text, string.Empty, string.Empty, null);
                this.groupBox1.Text = string.Format("Done: ({0}) {1}", r.StatusCode, r.StatusText);
                this.toolStripStatusLabel1.Text = "Loading complete";
                this.txtCaptureRURL.Text = (r.ErrorMessage == string.Empty ? r.Content : r.ErrorMessage);
            }
            catch (Exception ex)
            {
                this.groupBox1.Text = "Failed to retrieve URL";
                this.toolStripStatusLabel1.Text = "Loading failed";
                this.txtCaptureRURL.Text = DetailedException.WithUserContent(ref ex);
            }
            this.btnTestHttpCaptureText.Enabled = true;
            this.txtURL.Enabled = true;
            this.txtCaptureRURL.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void nudMaxChunkLength_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRegExChunkTest_Click(object sender, EventArgs e)
        {

        }

        private void txtMatchText_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSourceTextREC_DoubleClick(object sender, EventArgs e)
        {
            this.txtSourceTextREC.Text = this.txtCaptureRURL.Text;
        }
    }
}
