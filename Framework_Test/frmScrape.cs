using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace BOG.Framework_Test
{
    public partial class frmScrape : Form
    {
        public frmScrape()
        {
            InitializeComponent();
            this.cbxYear.SelectedIndex = 0;
            this.dgvFullExample.Columns.Add("Date", "Drawing Date");
            this.dgvFullExample.Columns.Add("Numbers", "Numbers");
            this.dgvFullExample.Columns.Add("Payout", "Payout Information");
            this.dgvFullExample.ColumnHeadersVisible = true;
            this.dgvFullExample.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); 
        }

        private void btnTestHttpCaptureText_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnTestHttpCaptureText.Enabled = false;
            this.toolStripStatusLabel1.Text = "Loading URL ...";
            this.groupBox1.Text = string.Empty;
            this.txtCaptureRURL.Text = string.Empty;
            this.txtSourceTextREC.Text = string.Empty;
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
                this.tabControl1.TabPages["tabRegExChunk"].Focus();
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
                if (this.lstMatchResultsREC.Items.Count > 0)
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
                this.txtCaptureTextRF.Text = this.txtMatchTextREC.Text;
            }
        }

        private void btnRegExTestRF_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnRegExFindRF.Enabled = false;
            this.lstRegExFindRF.Items.Clear();
            this.lstRegExFindRF.Enabled = false;
            this.txtRegExFindResultsRF.Text = string.Empty;
            this.chkIgnoreCaseRF.Enabled = false;
            this.nudIterationRF.Enabled = false;
            this.Refresh();

            try
            {
                StringCollection results = s.RegExFind(this.txtCaptureTextRF.Text,
                    this.txtRegExFindRF.Text, this.chkIgnoreCaseRF.Checked, int.Parse(this.nudIterationRF.Value.ToString()));
                foreach (string str in results)
                {
                    this.lstRegExFindRF.Items.Add(str);
                }
                this.lstRegExFindRF.Text = string.Format("{0} matches", this.lstRegExFindRF.Items.Count);
                if (this.lstRegExFindRF.Items.Count > 0)
                {
                    this.lstRegExFindRF.SelectedIndex = 0;
                }
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

        private void btnFullExample_Click(object sender, EventArgs e)
        {
            string I_AM_CHROME = "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36";
            Scrape s = new Scrape();
            StringBuilder result = new StringBuilder();

            result.AppendLine("Date\tNumbers\tPayoutInfo");

            this.btnFullExample.Enabled = false;
            this.txtFullExampleResult.Text = string.Empty;
            this.lstFullExampleActivity.Items.Clear();
            this.dgvFullExample.Rows.Clear();
            this.tabControl4.TabPages["tabActivity"].Focus();
            this.Refresh();
            bool Continue = true;
            string Captured = string.Empty;

            try
            {
                string SourceURL = string.Format(
                        "http://www.palottery.state.pa.us/Games/Print-Past-Winning-Numbers.aspx?id=12&year={0}&print=1",
                        (string)this.cbxYear.Items[this.cbxYear.SelectedIndex]);

                this.lstFullExampleActivity.Items.Add("Loading content from URL ...");
                this.lstFullExampleActivity.Items.Add(SourceURL);
                WebScrapeResponse r = s.HttpCapture(SourceURL, string.Empty, I_AM_CHROME, null);
                this.groupBox1.Text = string.Format("Done: ({0}) {1}", r.StatusCode, r.StatusText);
                if (!string.IsNullOrWhiteSpace(r.ErrorMessage)) throw new Exception("Unexpected error message from HttpCapture: " + r.ErrorMessage);
                if (r.StatusCode != "200") throw new Exception("Status code value was not 200.  Can not continue");
                this.lstFullExampleActivity.Items.Add("Loading complete");
                Captured = r.Content;
            }
            catch (Exception err)
            {
                this.lstFullExampleActivity.Items.Add("Failed to retrieve URL: see result for error text");
                this.txtFullExampleResult.Text = DetailedException.WithUserContent(ref err);
                Continue = false;
            }

            if (Continue)
            {
                this.lstFullExampleActivity.Items.Add("Extract informational rows...");
                try
                {
                    StringCollection infoRows = s.RegExChunk(Captured, @"<tr>\s+<td>\d\d/\d\d/\d\d\d\d</td><td>\s+\d[\d]?\s+&nbsp;", true, 0, "</tr>", true, 1, 0);
                    if (infoRows.Count == 0)
                    {
                        throw new Exception("No informational rows encountered.");
                    }
                    int rowIndex = 0;
                    foreach (string infoRow in infoRows)
                    {
                        StringCollection infoDraws = s.RegExChunk(infoRow, @"<td[>|\s]", true, 0, "</td>", true, 1, 0);
                        if (infoDraws.Count != 3)
                        {
                            this.lstFullExampleActivity.Items.Add(string.Format("Can not read malformed row({0}): {1}", rowIndex, infoRow));
                            continue;
                        }

                        string[] values = new string[3];
                        for (int cellIndex = 0; cellIndex < 3; cellIndex++)
                        {
                            switch (cellIndex)
                            {
                                case 0: // date
                                    values[0] = s.RegExFind(infoDraws[cellIndex], @"([\d]?[\d]/){2}[\d]{4}", true, 0)[0];
                                    result.Append(values[0]);
                                    break;

                                case 1: // numbers
                                    // just get the digits and the semi-colons
                                    string numberRaw = Regex.Replace(infoDraws[cellIndex], @"[^0-9;]", string.Empty);
                                    string[] n = numberRaw.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (n.Length != 7)
                                    {
                                        this.lstFullExampleActivity.Items.Add(string.Format("Expected 7 numbers, but got {0} in \"{1}\"", n.Length, n));
                                        continue;
                                    }
                                    values[1] = string.Format("\t{0}-{1}-{2}-{3}-{4} [{5}] x{6}", n[0], n[1], n[2], n[3], n[4], n[5], n[6]);
                                    result.Append("\t" + values[1]);
                                    break;

                                case 2: // link for payout stats
                                    values[2] = "http://www.palottery.state.pa.us/Games" + s.RegExFind(infoDraws[cellIndex], "/Payouts.aspx[^\"]+", true, 0)[0];
                                    result.AppendLine("\t" + values[2]);
                                    break;
                            }
                        }
                        this.dgvFullExample.Rows.Add(values);
                    }
                    this.txtFullExampleResult.Text = result.ToString();
                    this.lstFullExampleActivity.Items.Add("Extraction successfully completed.  See result tab");
                }
                catch (Exception err)
                {
                    this.lstFullExampleActivity.Items.Add("Failed to retrieve URL: see result for error text");
                    this.txtFullExampleResult.Text = DetailedException.WithUserContent(ref err);
                    Continue = false;
                }
            }
            
            this.btnFullExample.Enabled = true;
            this.tabControl4.TabPages[Continue ? "tabResult" : "tabActivity"].Focus();
            this.dgvFullExample.Visible = Continue;

        }
    }
}
