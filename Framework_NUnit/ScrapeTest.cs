using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BOG.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class ScrapeTest
	{
		[Test, Description("Check for 3 items, in any order")]
		public void ScrapeTest_RegexChunk()
		{
            string source = "<td>05/30/17</td><td>3</td><td>X2</td><td>05/31/17</td><td>2</td><td c=34>X4</td>";
            string startExpr = @">\d\d/\d\d/\d\d<";
            string endExpr = @">X\d<";

            var scrape = new Scrape();
            var results = scrape.RegExChunk(source, startExpr, true, 0, endExpr, true, 1, 0, 1000);

			Assert.That(results.Count == 2, string.Format("Count == {0}", results.Count));
            Assert.That(results.Count == 2, string.Format("Count == {0}", results.Count));
        }
    }
}
