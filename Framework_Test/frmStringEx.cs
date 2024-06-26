﻿using BOG.Framework;
using BOG.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BOG.Framework_Test
{
    public partial class frmStringEx : Form
	{
		Dictionary<string, string[]> FilterTestSet = new Dictionary<string, string[]>();
		public frmStringEx()
		{
			InitializeComponent();
			this.cbxMethodStr.Items.Add("Base64Encode");
			this.cbxMethodStr.Items.Add("Base64Decode");
			this.cbxMethodStr.Items.Add("ShowStringAsHex");
			this.cbxMethodStr.Items.Add("TextAsInnerText");
			this.cbxMethodStr.Items.Add("ResolvePathPlaceholders");
			this.cbxMethodStr.Items.Add("ResolvePlaceHolders");
			this.cbxMethodStr.Items.Add("ToHex()");
			this.cbxMethodStr.Items.Add("FromHex()");
			this.cbxMethodStr.Items.Add("FromHex() - Invalid");
			this.cbxMethodStr.Items.Add("ToHex() - From byte[]");
			this.cbxMethodStr.Items.Add("FromHexToByteArray()");
			this.cbxMethodStr.Items.Add("BeautifyJSON()");
			this.cbxMethodStr.SelectedIndex = 0;
			this.cbxFilterMethod.Items.Clear();
			this.cbxFilterMethod.Items.Add("Filter-case insensitive");
			this.cbxFilterMethod.Items.Add("Filter-case sensitive");
			this.cbxFilterMethod.Items.Add("FilterOut-case insensitive");
			this.cbxFilterMethod.Items.Add("FilterOut-case sensitive");
			FilterTestSet.Add("Filter-case insensitive", new string[] {
				"72.45.123.76xxxy", "0123456789.X"
			});
			FilterTestSet.Add("Filter-case sensitive", new string[] {
				"72.45.123.76xxxy", "0123456789.X"
			});
			FilterTestSet.Add("FilterOut-case insensitive", new string[] {
				"72.45.123.76xxxy", "0123456789.X"
			});
			FilterTestSet.Add("FilterOut-case sensitive", new string[] {
				"72.45.123.76xxxy", "0123456789.X"
			});
			this.cbxFilterMethod.SelectedIndex = 0;
		}

		private void btnTestIt_Click(object sender, EventArgs e)
		{
			try
			{
				switch (this.cbxMethodStr.SelectedIndex)
				{
					case 0:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.Base64EncodeString();
						break;

					case 1:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.Base64DecodeString();
						break;

					case 2:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.ShowStringAsHex();
						break;

					case 3:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.TextAsInnerText();
						break;
					case 4:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.ResolvePathPlaceholders();
						break;
					case 5:
						Dictionary<string, string> lookup = new Dictionary<string, string>();
						lookup.Add("Explicative", "shove it");
						string startDelim = @"\/";
						string endDelim = @"\/";
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.ResolvePlaceHolders(lookup, startDelim, endDelim);
						break;
					case 6:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.ToHex(false, string.Empty, 80);
						break;
					case 7:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.FromHex();
						break;
					case 8:
						this.txtOutputStrStr.Text = this.txtInputStrStr.Text.FromHex();
						break;
					case 9:
						this.txtOutputStrStr.Text = Encoding.ASCII.GetBytes(this.txtInputStrStr.Text).ToHex(false, string.Empty, 80);
						break;
					case 10:
						this.txtOutputStrStr.Text = Encoding.ASCII.GetString(this.txtInputStrStr.Text.FromHexToByteArray());
						break;
				}
			}
			catch (Exception err)
			{
				MessageBox.Show(DetailedException.WithUserContent(ref err));
			}
		}

		private void cbxMethodStr_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.cbxMethodStr.SelectedIndex)
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

				case 4:
					this.txtInputStrStr.Text = @"[cOMMONaPPLICATIONdATA]\[Unresolved]\%UseRnAMe%\%Unresolved%\MyApplication\MySubfolder";
					break;

				case 5:
					this.txtInputStrStr.Text = @"Take this job and \/EXPLICATIVE\/ !!  \/SoThere\/";
					break;

				case 6:
				case 9:
					this.txtInputStrStr.Text = "The quick brown \"fox\" jumped over the lazy dog";
					break;

				case 7:
				case 10:
					this.txtInputStrStr.Text = "5 46=86+52071}  7  5g69636b2062726f776e2022666f7822206a756d706564206f76657220746865206c617a7920646f67";
					break;

				case 8:
					this.txtInputStrStr.Text = "54-68==6*97,320g6";
					break;
			}
		}

		private void btnTestFilter_Click(object sender, EventArgs e)
		{
			if ((string) this.cbxFilterMethod.SelectedItem == "Filter-case insensitive")
			{
				this.txtFiltered.Text = this.txtOriginal.Text.Filter(this.txtFilterSet.Text, true);
			}
			if ((string) this.cbxFilterMethod.SelectedItem == "Filter-case sensitive")
			{
				this.txtFiltered.Text = this.txtOriginal.Text.Filter(this.txtFilterSet.Text, false);
			}
			if ((string) this.cbxFilterMethod.SelectedItem == "FilterOut-case insensitive")
			{
				this.txtFiltered.Text = this.txtOriginal.Text.FilterOut(this.txtFilterSet.Text, true);
			}
			if ((string) this.cbxFilterMethod.SelectedItem == "FilterOut-case sensitive")
			{
				this.txtFiltered.Text = this.txtOriginal.Text.FilterOut(this.txtFilterSet.Text, false);
			}
		}

		private void cbxFilterMethod_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txtFiltered.Text = string.Empty;
			this.txtOriginal.Text = FilterTestSet[(string) this.cbxFilterMethod.SelectedItem][0];
			this.txtFilterSet.Text = FilterTestSet[(string) this.cbxFilterMethod.SelectedItem][1];
		}
	}
}
