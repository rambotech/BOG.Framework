using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BOG.Framework;
using System.IO;
using System.Security.Cryptography;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class SerializableXml_Test
	{
		[Test]
		public void SerializableJson_ObjectToContainerToObject_ImplicitAlgorithm()
		{
			Support.MyDataSet original = MakeMyDataSet();
			int setCount = original.coll.Count;
			string password = "Uncomplicated";
			string salt = "JustAsEasy";

			string rawContent = ObjectXMLSerializer<Support.MyDataSet>.CreateDocumentFormat(original);
			//int rawContentLength = rawContent.Length;

			string transitContent = ObjectXMLSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt);
			//int transitContentLength = transitContent.Length;

			Support.MyDataSet result = ObjectXMLSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt);

			Assert.AreEqual(result.s1, original.s1, "s1 not same");
			Assert.AreEqual(result.i16, original.i16, "i16 not same");
			Assert.AreEqual(result.i32, original.i32, "i32 not same");
			Assert.AreEqual(result.i64, original.i64, "i64 not same");
			Assert.AreEqual(result.Timestamp, original.Timestamp, "Timestamp not same");
			Assert.AreEqual(result.coll.Count, setCount, "coll.Count not " + setCount.ToString());
			Assert.AreEqual(result.coll.Count, original.coll.Count, "coll.Count not same");
			for (int index = 0; index < setCount; index++)
			{
				Assert.AreEqual(result.coll[index], original.coll[index], "coll[] not same at index " + index.ToString());
			}
		}

		[Test]
		public void SerializableJson_ObjectToContainerToObject_ExplicitAlgorithm()
		{
			Support.MyDataSet original = MakeMyDataSet();
			int setCount = original.coll.Count;
			string password = "Uncomplicated";
			string salt = "JustAsEasy";

			SymmetricAlgorithm algorithm = new DESCryptoServiceProvider();

			string transitContent = ObjectXMLSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt, algorithm);

			Support.MyDataSet result = ObjectXMLSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt, algorithm);

			Assert.AreEqual(result.s1, original.s1, "s1 not same");
			Assert.AreEqual(result.i16, original.i16, "i16 not same");
			Assert.AreEqual(result.i32, original.i32, "i32 not same");
			Assert.AreEqual(result.i64, original.i64, "i64 not same");
			Assert.AreEqual(result.Timestamp, original.Timestamp, "Timestamp not same");
			Assert.AreEqual(result.coll.Count, setCount, "coll.Count not " + setCount.ToString());
			Assert.AreEqual(result.coll.Count, original.coll.Count, "coll.Count not same");
			for (int index = 0; index < setCount; index++)
			{
				Assert.AreEqual(result.coll[index], original.coll[index], "coll[] not same at index " + index.ToString());
			}
		}

		private Support.MyDataSet MakeMyDataSet()
		{
			var result = new Support.MyDataSet();
			result.s1 = "A large set of strings in the list";
			using (var sr = new StreamReader(Path.Combine(Path.GetDirectoryName(AssemblyInfo.FilePath), @"UrlTestData.tsv")))
			{
				while (!sr.EndOfStream)
				{
					result.coll.Add(sr.ReadLine());
				}
			}
			return result;
		}
	}
}
