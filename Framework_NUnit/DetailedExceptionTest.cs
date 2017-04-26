using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BOG.Framework
{
	[TestFixture]
	public class DetailedExceptionTest
	{
		[Test, Description("Long String, hide uid")]
		public void DetailedException_LongSimpleUser()
		{
			string s = string.Empty;
			try
			{
				throw new Exception("uid=someuser;pass=somepass");
			}
			catch (Exception e)
			{
				s = DetailedException.WithEnterpriseContent(ref e);
			}
			Assert.That(s.IndexOf("someuser") < 0, s);
		}

		[Test, Description("Long String, hide pass")]
		public void DetailedException_LongSimplePassword()
		{
			string s = string.Empty;
			try
			{
				throw new Exception("uid=someuser;pass=somepass");
			}
			catch (Exception e)
			{
				s = DetailedException.WithEnterpriseContent(ref e);
			}
			Assert.That(s.IndexOf("somepass") <= 0);
		}

		[Test, Description("Uri String, hide user")]
		public void DetailedException_UriSimpleUser()
		{
			string s = string.Empty;
			try
			{
				throw new Exception("http://someuser:somepass@server/path/file.asp?arg=1");
			}
			catch (Exception e)
			{
				s = DetailedException.WithEnterpriseContent(ref e);
			}
			Assert.That(s.IndexOf("someuser") < 0, s);
		}

		[Test, Description("Uri String, hide pass")]
		public void DetailedException_UriSimplePassword()
		{
			string s = string.Empty;
			try
			{
				throw new Exception("http://someuser:somepass@server/path/file.asp?arg=1");
			}
			catch (Exception e)
			{
				s = DetailedException.WithEnterpriseContent(ref e);
			}

			Assert.That(s.IndexOf("somepass") <= 0);
		}
	}
}
