using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework_Test
{
	public class DemoSet1 : IDemo
	{
		public string PerformFunction()
		{
			return "This came from DemoSet1";
		}
	}

	public class DemoSet2 : IDemo
	{
		public string PerformFunction()
		{
			return "This came from DemoSet2";
		}
	}

	public class DemoSetX: IDemo
	{
		public string PerformFunction()
		{
			return "This will never be enumerated or exectued, since it does not implement IDemo";
		}
	}
}
