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
	public partial class frmAssemblyInfo : Form
	{
		public frmAssemblyInfo()
		{
			InitializeComponent();
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
}
