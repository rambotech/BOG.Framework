using BOG.Framework;
using NUnit.Framework;
using System.IO;
using System.Security.Cryptography;

namespace BOG.Framework_NUnit
{
    [TestFixture]
	public class SerializableJson_Test
	{
		[Test]
		public void SerializableJson_ObjectToContainerToObject_ImplicitAlgorithm()
		{
			Support.MyDataSet original = MakeMyDataSet();
			int setCount = original.coll.Count;
			string password = "Uncomplicated";
			string salt = "JustAsEasy";

			string rawContent = ObjectJsonSerializer<Support.MyDataSet>.CreateDocumentFormat(original);
			int rawContentLength = rawContent.Length;

			string transitContent = ObjectJsonSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt);
			int transitContentLength = transitContent.Length;

			Support.MyDataSet result = ObjectJsonSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt);

			Assert.That(result.s1, Is.EqualTo(original.s1), "s1 not same");
			Assert.That(result.i16, Is.EqualTo(original.i16), "i16 not same");
			Assert.That(result.i32, Is.EqualTo(original.i32), "i32 not same");
			Assert.That(result.i64, Is.EqualTo(original.i64), "i64 not same");
			Assert.That(result.Timestamp, Is.EqualTo(original.Timestamp), "Timestamp not same");
			Assert.That(result.coll.Count, Is.EqualTo(setCount), "coll.Count not " + setCount.ToString());
			Assert.That(result.coll.Count, Is.EqualTo(original.coll.Count), "coll.Count not same");
			for (int index = 0; index < setCount; index++)
			{
				Assert.That(result.coll[index], Is.EqualTo(original.coll[index]), "coll[] not same at index " + index.ToString());
			}
		}

        [Test]
        public void SerializableJson_ObjectToContainerToObject_ImplicitAlgorithm_Indented()
        {
            Support.MyDataSet original = MakeMyDataSet();
            int setCount = original.coll.Count;
            string password = "Uncomplicated";
            string salt = "JustAsEasy";

            string rawContent = ObjectJsonSerializer<Support.MyDataSet>.CreateDocumentFormat(original, true);
            int rawContentLength = rawContent.Length;

            string transitContent = ObjectJsonSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt, true);
            int transitContentLength = transitContent.Length;

            Support.MyDataSet result = ObjectJsonSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt);

            Assert.That(result.s1, Is.EqualTo(original.s1), "s1 not same");
            Assert.That(result.i16, Is.EqualTo(original.i16), "i16 not same");
            Assert.That(result.i32, Is.EqualTo(original.i32), "i32 not same");
            Assert.That(result.i64, Is.EqualTo(original.i64), "i64 not same");
            Assert.That(result.Timestamp, Is.EqualTo(original.Timestamp), "Timestamp not same");
            Assert.That(result.coll.Count, Is.EqualTo(setCount), "coll.Count not " + setCount.ToString());
            Assert.That(result.coll.Count, Is.EqualTo(original.coll.Count), "coll.Count not same");
            for (int index = 0; index < setCount; index++)
            {
                Assert.That(result.coll[index], Is.EqualTo(original.coll[index]), "coll[] not same at index " + index.ToString());
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

			string transitContent = ObjectJsonSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt, algorithm);

			Support.MyDataSet result = ObjectJsonSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt, algorithm);

			Assert.That(result.s1, Is.EqualTo(original.s1), "s1 not same");
			Assert.That(result.i16, Is.EqualTo(original.i16), "i16 not same");
			Assert.That(result.i32, Is.EqualTo(original.i32), "i32 not same");
			Assert.That(result.i64, Is.EqualTo(original.i64), "i64 not same");
			Assert.That(result.Timestamp, Is.EqualTo(original.Timestamp), "Timestamp not same");
			Assert.That(result.coll.Count, Is.EqualTo(setCount), "coll.Count not " + setCount.ToString());
			Assert.That(result.coll.Count, Is.EqualTo(original.coll.Count), "coll.Count not same");
			for (int index = 0; index < setCount; index++)
			{
				Assert.That(result.coll[index], Is.EqualTo(original.coll[index]), "coll[] not same at index " + index.ToString());
			}
		}

        [Test]
        public void SerializableJson_ObjectToContainerToObject_ExplicitAlgorithm_Indented()
        {
            Support.MyDataSet original = MakeMyDataSet();
            int setCount = original.coll.Count;
            string password = "Uncomplicated";
            string salt = "JustAsEasy";

            SymmetricAlgorithm algorithm = new DESCryptoServiceProvider();

            string transitContent = ObjectJsonSerializer<Support.MyDataSet>.CreateTransitContainerForObject(original, password, salt, algorithm, true);

            Support.MyDataSet result = ObjectJsonSerializer<Support.MyDataSet>.CreateObjectFromTransitContainer(transitContent, password, salt, algorithm);

            Assert.That(result.s1, Is.EqualTo(original.s1), "s1 not same");
            Assert.That(result.i16, Is.EqualTo(original.i16), "i16 not same");
            Assert.That(result.i32, Is.EqualTo(original.i32), "i32 not same");
            Assert.That(result.i64, Is.EqualTo(original.i64), "i64 not same");
            Assert.That(result.Timestamp, Is.EqualTo(original.Timestamp), "Timestamp not same");
            Assert.That(result.coll.Count, Is.EqualTo(setCount), "coll.Count not " + setCount.ToString());
            Assert.That(result.coll.Count, Is.EqualTo(original.coll.Count), "coll.Count not same");
            for (int index = 0; index < setCount; index++)
            {
                Assert.That(result.coll[index], Is.EqualTo(original.coll[index]), "coll[] not same at index " + index.ToString());
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
