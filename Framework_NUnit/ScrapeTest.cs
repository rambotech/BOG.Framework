using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BOG.Framework
{
	[TestFixture]
	public class ScrapeTest
	{
		[Test, Description("Check for 3 items, in any order")]
		public void MemoryList_RandomNonUniqueIgnoreCase()
		{
			MemoryList<string> t = new MemoryList<string>("testlist", false, true, MemoryList<string>.MemoryListRetrieveSequence.Random);

			Assert.That(t.CountAll() == 0, "(1) Count() == 0");
			Assert.That(!t.HasValues(), "t.HasValues() == false");

			t.StoreValue("Robert");
			t.StoreValue("robert");
			t.StoreValue("Fred");

			Assert.That(t.CountAll() == 3, "Count() == 3");
			Assert.That(t.ConsumedCount() == 0, "t.ConsumedCount() == 0");
			Assert.That(t.UnconsumedCount() == 3, "t.UnconsumedCount() == 3");
		}
	}
}
