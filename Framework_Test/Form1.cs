using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BOG.Framework;

namespace Framework_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestHttpCaptureText_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnTestHttpCaptureText.Enabled = false;
            this.lblCaptureStatus.Text = "Working...";
            this.txtURL.Enabled = false;
            this.txtCapture.Enabled = false;
            this.txtPostData.Enabled = false;
            this.txtWorkText.Enabled = false;
            this.Refresh();

            string capture = string.Empty;
            try
            {
                WebScrapeResponse r = s.HttpCapture(this.txtURL.Text, this.txtPostData.Text, string.Empty, null);
                lblCaptureStatus.Text = r.StatusCode;
                this.txtCapture.Text = (r.ErrorMessage == string.Empty ? r.Content : r.ErrorMessage);
            }
            catch (Exception ex)
            {
                lblCaptureStatus.Text = "FAIL";
                this.txtCapture.Text = DetailedException.WithEnterpriseContent(ref ex);
            }
            this.btnTestHttpCaptureText.Enabled = true;
            this.txtURL.Enabled = true;
            this.txtCapture.Enabled = true;
            this.txtPostData.Enabled = true;
            this.txtWorkText.Enabled = true;
        }

        private void btnRegExChunkTest_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.btnRegExChunkTest.Enabled = false;
            this.lblRegExChunkCount.Text = "Working...";
            this.txtRegExStart.Enabled = false;
            this.chkStartIgnoreCase.Enabled = false;
            this.nudStartIteration.Enabled = false;
            this.txtRegExEnd.Enabled = false;
            this.chkEndIgnoreCase.Enabled = false;
            this.nudEndIteration.Enabled = false;
            this.lstMatchResults.Enabled = false;
            this.txtMatchText.Text = string.Empty;
            this.txtMatchText.Enabled = false;
            this.lstMatchResults.Items.Clear();
            this.lstMatchResults.Enabled = false;
            this.Refresh();

            try
            {
                StringCollection results = s.RegExChunk(
                    this.txtCapture.Text,
                    this.txtRegExStart.Text,
                    this.chkStartIgnoreCase.Checked,
                    int.Parse(this.nudStartIteration.Value.ToString()),
                    this.txtRegExEnd.Text,
                    this.chkEndIgnoreCase.Checked,
                    int.Parse(this.nudEndIteration.Value.ToString()),
                    int.Parse(this.nudMaxChunkLength.Value.ToString()));
                foreach (string str in results)
                {
                    this.lstMatchResults.Items.Add(str);
                }
                this.lblRegExChunkCount.Text = string.Format("{0} matches", this.lstMatchResults.Items.Count.ToString());
            }
            catch (Exception ex)
            {
                this.lblRegExChunkCount.Text = "FAIL";
                this.lstMatchResults.Items.Clear();
                this.lstMatchResults.Items.Add(DetailedException.WithEnterpriseContent(ref ex));
            }

            this.btnRegExChunkTest.Enabled = true;
            this.txtRegExStart.Enabled = true;
            this.chkStartIgnoreCase.Enabled = true;
            this.nudStartIteration.Enabled = true;
            this.txtRegExEnd.Enabled = true;
            this.chkEndIgnoreCase.Enabled = true;
            this.nudEndIteration.Enabled = true;
            this.lstMatchResults.Enabled = true;
            this.txtMatchText.Text = string.Empty;
            this.txtMatchText.Enabled = true;
            this.lstMatchResults.Enabled = true;
        }

        private void lstMatchResults_Click(object sender, EventArgs e)
        {
            if (lstMatchResults.SelectedIndex >= 0)
            {
                this.txtMatchText.Text = lstMatchResults.Items[lstMatchResults.SelectedIndex].ToString();
            }
        }

        private void lstMatchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMatchResults.SelectedIndex >= 0)
            {
                this.txtMatchText.Text = lstMatchResults.Items[lstMatchResults.SelectedIndex].ToString();
            }
        }

        private void btnRegExTest_Click(object sender, EventArgs e)
        {
            Scrape s = new Scrape();

            this.lblRegExFindCount.Text = "Working...";
            this.btnRegExTest.Enabled = false;
            this.lstRegExResults.Items.Clear();
            this.lstRegExResults.Enabled = false;
            this.txtRegExResults.Text = string.Empty;
            this.chkIgnoreCase.Enabled = false;
            this.nudIteration.Enabled = false;
            this.Refresh();

            try
            {
                StringCollection results = s.RegExFind(
                    this.txtCapture.Text,
                    this.txtRegEx.Text, this.chkIgnoreCase.Checked, int.Parse(this.nudIteration.Value.ToString()));
                foreach (string str in results)
                {
                    this.lstRegExResults.Items.Add(str);
                }
                this.lblRegExFindCount.Text = string.Format("{0} matches", this.lstRegExResults.Items.Count);
            }
            catch (Exception ex)
            {
                this.lstRegExResults.Items.Clear();
                this.lstRegExResults.Items.Add(DetailedException.WithEnterpriseContent(ref ex));
                this.lblRegExFindCount.Text = "FAIL";
            }
            this.btnRegExTest.Enabled = true;
            this.lstRegExResults.Enabled = true;
            this.chkIgnoreCase.Enabled = true;
            this.nudIteration.Enabled = true;
        }

        private void lstRegExResults_Click(object sender, EventArgs e)
        {
            if (lstRegExResults.SelectedIndex >= 0)
            {
                this.txtRegExResults.Text = lstRegExResults.Items[lstRegExResults.SelectedIndex].ToString();
            }
        }

        private void lstRegExResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRegExResults.SelectedIndex >= 0)
            {
                this.txtRegExResults.Text = lstRegExResults.Items[lstRegExResults.SelectedIndex].ToString();
            }
        }

        private void txtCapture_DoubleClick(object sender, EventArgs e)
        {
            txtWorkText.Text = txtCapture.Text;
        }

        private void txtMatchText_DoubleClick(object sender, EventArgs e)
        {
            txtWorkText.Text = txtMatchText.Text;
        }

        private void txtCapture_TextChanged(object sender, EventArgs e)
        {
            txtWorkText.Text = txtCapture.Text;
        }

        private void txtRegExResults_DoubleClick(object sender, EventArgs e)
        {
            txtWorkText.Text = txtRegExResults.Text;
        }

        private void btnTestIt_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception(this.txtErrorMessage.Text);
            }
            catch (Exception err)
            {
                this.txtResultError.Text = DetailedException.WithEnterpriseContent(ref err, "Start of my error", "Footnotes to my error");
            }
        }

        private void btnBase64Encode_Click(object sender, EventArgs e)
        {
            if (this.txtBase64Decoded.Tag != null && ((string)this.txtBase64Decoded.Tag).Length > 0)
            {
                this.txtBase64Decoded.Text = (string)this.txtBase64Decoded.Tag;
            }
            this.txtBase64Encoded.Text = StringEx.Base64EncodeString(this.txtBase64Decoded.Text);
            this.txtBase64Decoded.Tag = "";
            this.txtBase64Encoded.Tag = "";
        }

        private void btnBase64Decode_Click(object sender, EventArgs e)
        {
            if (this.txtBase64Encoded.Tag != null && ((string)this.txtBase64Encoded.Tag).Length > 0)
            {
                this.txtBase64Encoded.Text = (string)this.txtBase64Encoded.Tag;
            }
            this.txtBase64Decoded.Text = StringEx.Base64DecodeString(this.txtBase64Encoded.Text);
            this.txtBase64Decoded.Tag = "";
            this.txtBase64Encoded.Tag = "";
        }

        private void txtBase64Decoded_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtBase64Decoded.Tag != null && ((string)this.txtBase64Decoded.Tag).Length > 0)
            {
                this.txtBase64Decoded.Text = (string)this.txtBase64Decoded.Tag;
                this.txtBase64Decoded.Tag = "";
            }
            else
            {
                this.txtBase64Decoded.Tag = this.txtBase64Decoded.Text;
                this.txtBase64Decoded.Text = StringEx.ShowStringAsHex(this.txtBase64Decoded.Text);
            }
        }

        private void txtBase64Encoded_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtBase64Encoded.Tag != null && ((string)this.txtBase64Encoded.Tag).Length > 0)
            {
                this.txtBase64Encoded.Text = (string)this.txtBase64Encoded.Tag;
                this.txtBase64Encoded.Tag = "";
            }
            else
            {
                this.txtBase64Encoded.Tag = this.txtBase64Encoded.Text;
                this.txtBase64Encoded.Text = StringEx.ShowStringAsHex(this.txtBase64Encoded.Text);
            }
        }

        private void btnAddAccess_Click(object sender, EventArgs e)
        {
            NTGroup g1 = new NTGroup();
            g1.AddDirectorySecurity(this.txtFileSystemObject.Text, this.txtDomain.Text + @"\" + this.txtUserName.Text,
                    System.Security.AccessControl.FileSystemRights.ListDirectory |
                    System.Security.AccessControl.FileSystemRights.Traverse |
                    System.Security.AccessControl.FileSystemRights.Delete |
                    System.Security.AccessControl.FileSystemRights.DeleteSubdirectoriesAndFiles,
                    System.Security.AccessControl.InheritanceFlags.ContainerInherit |
                    System.Security.AccessControl.InheritanceFlags.ObjectInherit,
                    System.Security.AccessControl.PropagationFlags.InheritOnly,
                    System.Security.AccessControl.AccessControlType.Allow);
        }

        private void btnRemoveAccess_Click(object sender, EventArgs e)
        {
            NTGroup g1 = new NTGroup();
            g1.RemoveDirectorySecurity(this.txtFileSystemObject.Text, this.txtDomain.Text + @"\" + this.txtUserName.Text,
                    System.Security.AccessControl.FileSystemRights.ListDirectory |
                    System.Security.AccessControl.FileSystemRights.Traverse |
                    System.Security.AccessControl.FileSystemRights.Delete |
                    System.Security.AccessControl.FileSystemRights.DeleteSubdirectoriesAndFiles,
                    System.Security.AccessControl.InheritanceFlags.ContainerInherit |
                    System.Security.AccessControl.InheritanceFlags.ObjectInherit,
                    System.Security.AccessControl.PropagationFlags.InheritOnly,
                    System.Security.AccessControl.AccessControlType.Allow);
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            Scrape o = new Scrape();
            try
            {
                this.txtResultForExtract.Text = o.ExtractText(this.txtSourceForExtract.Text, this.txtXPathExpr.Text, this.chkCleanup.Checked);
            }
            catch (Exception err)
            {
                this.txtResultForExtract.Text = DetailedException.WithMachineContent(ref err);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scrape o = new Scrape();
            try
            {
                this.txtResultForExtract.Text = o.StripHTML(this.txtSourceForExtract.Text);
            }
            catch (Exception err)
            {
                this.txtResultForExtract.Text = DetailedException.WithMachineContent(ref err);
            }
        }

        private void dgvAssemblyInfo_Click(object sender, EventArgs e)
        {
            if (dgvAssemblyInfo.Columns.Count == 0)
            {
                dgvAssemblyInfo.Columns.Add("Property", "Property");
                dgvAssemblyInfo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvAssemblyInfo.Columns.Add("Value", "Value");
                dgvAssemblyInfo.Rows.Add(new object[] { "AssemblyVersion", AssemblyInfo.AssemblyVersion });
                dgvAssemblyInfo.Rows.Add(new object[] { "Company", AssemblyInfo.Company });
                dgvAssemblyInfo.Rows.Add(new object[] { "Copyright", AssemblyInfo.Copyright });
                dgvAssemblyInfo.Rows.Add(new object[] { "Description", AssemblyInfo.Description });
                dgvAssemblyInfo.Rows.Add(new object[] { "FileName", AssemblyInfo.FileName });
                dgvAssemblyInfo.Rows.Add(new object[] { "FilePath", AssemblyInfo.FilePath });
                dgvAssemblyInfo.Rows.Add(new object[] { "FileVersion", AssemblyInfo.FileVersion });
                dgvAssemblyInfo.Rows.Add(new object[] { "Guid", AssemblyInfo.Guid });
                dgvAssemblyInfo.Rows.Add(new object[] { "Product", AssemblyInfo.Product });
                dgvAssemblyInfo.Rows.Add(new object[] { "Title", AssemblyInfo.Title });
                dgvAssemblyInfo.Rows.Add(new object[] { "Trademark", AssemblyInfo.Trademark });
            }
        }

        private void btnResolve_Click(object sender, EventArgs e)
        {
            //StringDictionary settings = new ConfigSettingsResolver().ResolveAllAppSettingValues();
        }
    }
}