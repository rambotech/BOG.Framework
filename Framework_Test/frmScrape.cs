using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;
using System.Collections.Specialized;

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
                this.txtSourceTextREC.Text = this.txtCaptureRURL.Text;
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

        private void txtSourceTextREC_DoubleClick(object sender, EventArgs e)
        {
            this.txtSourceTextREC.Text = this.txtCaptureRURL.Text;
        }

        private void btnRegExChunkTest_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnRegExChunkTest.Enabled = false;
            this.txtRegExStart.Enabled = false;
            this.chkStartIgnoreCase.Enabled = false;
            this.nudStartIteration.Enabled = false;
            this.txtRegExEnd.Enabled = false;
            this.chkEndIgnoreCase.Enabled = false;
            this.nudEndIteration.Enabled = false;
            this.lstMatchResultsREC.Enabled = false;
            this.txtMatchTextREC.Text = string.Empty;
            this.txtMatchTextREC.Enabled = false;
            this.lstMatchResultsREC.Items.Clear();
            this.lstMatchResultsREC.Enabled = false;
            this.Refresh();

            try
            {
                StringCollection results = s.RegExChunk(
                    this.txtCaptureRURL.Text,
                    this.txtRegExStart.Text,
                    this.chkStartIgnoreCase.Checked,
                    int.Parse(this.nudStartIteration.Value.ToString()),
                    this.txtRegExEnd.Text,
                    this.chkEndIgnoreCase.Checked,
                    int.Parse(this.nudEndIteration.Value.ToString()),
                    int.Parse(this.nudMaxChunkLength.Value.ToString()));
                this.lstMatchResultsREC.Items.Clear();
                foreach (string str in results)
                {
                    this.lstMatchResultsREC.Items.Add(str);
                }
                if (this.lstMatchResultsREC.Items.Count >0)
                {
                    this.lstMatchResultsREC.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                this.txtMatchTextREC.Text = "FAIL";
                this.lstMatchResultsREC.Items.Clear();
                this.lstMatchResultsREC.Items.Add(DetailedException.WithEnterpriseContent(ref ex));
            }

            this.btnRegExChunkTest.Enabled = true;
            this.txtRegExStart.Enabled = true;
            this.chkStartIgnoreCase.Enabled = true;
            this.nudStartIteration.Enabled = true;
            this.txtRegExEnd.Enabled = true;
            this.chkEndIgnoreCase.Enabled = true;
            this.nudEndIteration.Enabled = true;
            this.lstMatchResultsREC.Enabled = true;
            this.txtMatchTextREC.Enabled = true;
            this.lstMatchResultsREC.Enabled = true;
        }

        private void lstMatchResultsREC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMatchResultsREC.SelectedIndex >= 0)
            {
                this.txtMatchTextREC.Text = lstMatchResultsREC.Items[lstMatchResultsREC.SelectedIndex].ToString();
            }
        }

        private void btnRegExTestRF_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnRegExFindRF.Enabled = false;
            this.lstRegExFindRF.Items.Clear();
            this.lstRegExFindRF.Enabled = false;
            this.txtRegExFindRF.Text = string.Empty;
            this.chkIgnoreCaseRF.Enabled = false;
            this.nudIterationRF.Enabled = false;
            this.Refresh();

            try
            {
                StringCollection results = s.RegExFind(
                    this.txtRegExFindRF.Text,
                    this.txtRegExFindRF.Text, this.chkIgnoreCaseRF.Checked, int.Parse(this.nudIterationRF.Value.ToString()));
                foreach (string str in results)
                {
                    this.lstRegExFindRF.Items.Add(str);
                }
                this.lstRegExFindRF.Text = string.Format("{0} matches", this.lstRegExFindRF.Items.Count);
            }
            catch (Exception ex)
            {
                this.lstRegExFindRF.Items.Clear();
                this.lstRegExFindRF.Items.Add(DetailedException.WithEnterpriseContent(ref ex));
            }
            this.btnRegExFindRF.Enabled = true;
            this.lstRegExFindRF.Enabled = true;
            this.chkIgnoreCaseRF.Enabled = true;
            this.nudIterationRF.Enabled = true;
        }

        private void lstRegExFindRF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstRegExFindRF.SelectedIndex >= 0)
            {
                this.txtRegExFindResultsRF.Text = this.lstRegExFindRF.Items[this.lstRegExFindRF.SelectedIndex].ToString();
            }
        }
    }
}
