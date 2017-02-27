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
		public void MemoryList_isEmpty()
		{
			MemoryList<string> l = new MemoryList<string>();
			Assert.False(l.HasValues());
		}

		[Test, Description("HasValues() on non-empty list")]
		public void MemoryList_isNotEmpty()
		{
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("V");
			Assert.True(l.HasValues());
		}

		[Test, Description("HasValues() on non-empty list with items recalled")]
		public void MemoryList_isEmptyAfterItemRecall()
		{
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("V");
			string v = l.RecallValue();
			Assert.False(l.HasValues());
		}

		[Test, Description("Unique, Case-insensitive, Count check")]
		public void MemoryList_has1ItemAfter2AddsCaseInsensitve()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", true, true);
			l.StoreValue("Giraffe");
			l.StoreValue("giraffe");
			Assert.True(l.UnconsumedCount() == 1);
		}

		[Test, Description("NonUnique, Case-sensitive, Count check")]
		public void MemoryList_has2ItemsAfter2AddsCaseSensitve()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, false);
			l.StoreValue("Giraffe");
			l.StoreValue("giraffe");
			Assert.That(l.UnconsumedCount() == 2);
		}

		[Test, Description("NonUnique, Case-insensitive, Count check after store/recall/store")]
		public void MemoryList_has1ItemAfterStoreRecallStoreCaseInsensitve()
		{
			// this test uses the default settings for the class: unique = false,ignoreCase = true
			MemoryList<string> l = new MemoryList<string>();
			l.StoreValue("Giraffe");
			l.RecallValue();
			l.StoreValue("giraffe");
			Assert.That(l.UnconsumedCount() == 1);
		}

		[Test, Description("NonUnique, Case Insensitive, FIFO")]
		public void MemoryList_isFIFO()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, true, MemoryList<string>.MemoryListRetrieveSequence.FIFO);
			l.StoreValue("Dog");
			l.StoreValue("Cat");
			string v = l.RecallValue();
			Assert.That(v == "Dog");
		}

		[Test, Description("NonUnique, Case Insensitive, LIFO")]
		public void MemoryList_isLIFO()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, true, MemoryList<string>.MemoryListRetrieveSequence.LIFO);
			l.StoreValue("Dog");
			l.StoreValue("Cat");
			string v = l.RecallValue();
			Assert.That(v == "Cat");
		}

		[Test, Description("NonUnique, Case Insensitive, Queue")]
		public void MemoryList_isQueue()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, true, MemoryList<string>.MemoryListRetrieveSequence.Queue);
			l.StoreValue("Dog");
			l.StoreValue("Cat");
			string v = l.RecallValue();
			Assert.That(v == "Dog");
		}

		[Test, Description("NonUnique, Case Insensitive, Stack")]
		public void MemoryList_isStack()
		{
			MemoryList<string> l = new MemoryList<string>("MyListName", false, true, MemoryList<string>.MemoryListRetrieveSequence.Stack);
			l.StoreValue("Dog");
			l.StoreValue("Cat");
			string v = l.RecallValue();
			Assert.That(v == "Cat");
		}
	}
}
