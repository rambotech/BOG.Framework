using System;
using System.Collections.Generic;
using System.Text;
using BOG.Framework;
using NUnit.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class MemoryListTest
	{
		[Test, Description("HasValues() on empty list")]
		public void Test01()
		{
			MemoryList<string> l = new MemoryList<string>();
			Assert.False(l.HasValues());
		}

		[Test, Description("HasValues() on non-empty list")]
		public void Test02()
		{
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("V");
			Assert.True(l.HasValues());
		}

		[Test, Description("HasValues() on non-empty list with items recalled")]
		public void Test03()
		{
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("V");
			string v = l.RecallValue();
			Assert.False(l.HasValues());
		}

		[Test, Description("Unique, Case-insensitive, Count check")]
		public void Test04()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", true, true);
			l.StoreValue("Giraffe");
			l.StoreValue("giraffe");
			Assert.True(l.UnconsumedCount() == 1);
		}

		[Test, Description("NonUnique, Case-sensitive, Count check")]
		public void Test05()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, false);
			l.StoreValue("Giraffe");
			l.StoreValue("giraffe");
			Assert.That(l.UnconsumedCount() == 2);
		}

		[Test, Description("NonUnique, Case-insensitive, Count check after store/recall/store")]
		public void Test06()
		{
			// this test uses the default settings for the class: unique = false,ignoreCase = true
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("Giraffe");
			l.RecallValue();
			l.StoreValue("giraffe");
			Assert.That(l.UnconsumedCount() == 1);
		}

		//[Test, Description("NonUnique, Case Insensitive, FIFO")]
		//public void TestXX()
		//{
		//	MemoryList<string> ItemList = new MemoryList<string>();
		//	ItemList
		//	Assert.That(answer == "0", "0.0 == 0");
		//}
	}
}
