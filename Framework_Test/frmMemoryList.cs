using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmMemoryList : Form
	{
		public frmMemoryList()
		{
			InitializeComponent();
			foreach (string m in Enum.GetNames(typeof(MemoryList<>.MemoryListRetrieveSequence)))
			{
				this.cbxRetrievalMethod.Items.Add(m);
			}
			this.cbxRetrievalMethod.SelectedIndex = 0;

			this.lbxSource.Items.Add("Chicken");
			this.lbxSource.Items.Add("moose");
			this.lbxSource.Items.Add("moose");
			this.lbxSource.Items.Add("chicken");
			this.lbxSource.Items.Add("Gopher");
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			MemoryList<string> MasterList = new MemoryList<string>(
				"MyList", this.chkUnique.Checked, this.chkIgnoreCase.Checked,
				(MemoryList<string>.MemoryListRetrieveSequence) Enum.Parse(
					typeof(MemoryList<>.MemoryListRetrieveSequence),
					(string) this.cbxRetrievalMethod.Items[this.cbxRetrievalMethod.SelectedIndex]));
			this.lbxFiltered.Items.Clear();
			foreach (string item in this.lbxSource.Items)
			{
				MasterList.StoreValue(item);
			}
			while (MasterList.HasValues())
				this.lbxFiltered.Items.Add(MasterList.RecallValue());
		}
	}
}
