using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOG.Framework;

namespace BOG.Framework_Test
{
	public partial class frmDynamicScripting : Form
	{
		public string SimpleCode =
			"using BOG.Framework_Test;" + "\r\n" +
			"public class DoesSomething : IMyContract " + "\r\n" +
			"{ " + "\r\n" +
			"	public string ChangeValue(string original) " + "\r\n" +
			"	{ " + "\r\n" +
			"		return original.ToUpper(); " + "\r\n" +
			"	} " + "\r\n" +
			"} " + "\r\n";

		public frmDynamicScripting()
		{
			InitializeComponent();
			IMyContract assemblyObject;

			this.txtResults.Text = "---- <code>  -----\r\n" + SimpleCode + "---- </code> -----\r\n";
			CompilerResults r = DynamicScripting.CompileScript(
				SimpleCode, 
				new string[] {
					System.Reflection.Assembly.GetExecutingAssembly().Location,
					"System.dll"
					},
				DynamicScripting.Languages.CSharp, 
				true);
			if (r.Errors.Count == 0)
			{
				assemblyObject = (BOG.Framework_Test.IMyContract) DynamicScripting.FindInterface(r.CompiledAssembly, "IMyContract");
				this.txtResults.Text += string.Format(
					"the brown fox jumped ... becomes ... {0}\r\n",
					assemblyObject.ChangeValue("the brown fox jumped"));
			}
			else
			{
				this.txtResults.Text += string.Format("{0} ERROR(S):\r\n", r.Errors.Count);
				foreach (CompilerError err in r.Errors)
				{
					this.txtResults.Text += string.Format("Line {0}: {1}\r\n", err.Line, err.ErrorText);
				}
			}
		}
	}
}
