using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BOG.Framework;
using NUnit.Framework;
using System.Collections;
using NUnit.Framework.Interfaces;

namespace BOG.Framework_NUnit
{
	public class TestData : IEnumerable
	{
		private Queue<StringDictionary> TestPropertySets = new Queue<StringDictionary>();

		public TestData()
		{
		}

		public IEnumerator GetEnumerator()
		{
			DataTable dt = DataTable.New.ReadCsv(Path.Combine(Path.GetDirectoryName(AssemblyInfo.FilePath), @"UrlTestData.tsv"));
			foreach (Row r in dt.Rows)
			{
				StringDictionary items = new StringDictionary();
				foreach (string colName in dt.ColumnNames)
				{
					items.Add(colName, CleanProperty(r[colName]));
				}
				yield return items;
			}
		}

		#region Internal Helpers
		private string CleanProperty(string source)
		{
			string result = string.Empty;
			if (string.Compare("{empty}", source, true) == 0)
			{
				result = string.Empty;
			}
			else
			{
				result = source.Trim();
			}
			return result;
		}
		#endregion
	}

	[TestFixture]
	public class UrlTest
	{
		[TestCaseSource(typeof(TestData)), Description("Iterative: url parsing")]
		public void UrlTests_Iterative(StringDictionary parameters)
		{
			Int16 DataRow = Convert.ToInt16(parameters["DataRow"]);
			string OriginalUrl = parameters["OriginalUrl"];
			string ThrowsException = parameters["ThrowsException"];
			string ExceptionContains = parameters["ExceptionContains"];
			string Scheme = parameters["Scheme"];
			string User = parameters["User"];
			string Password = parameters["Password"];
			string Host = parameters["Host"];
			string Port = parameters["Port"];
			string Path = parameters["Path"];
			string Query = parameters["Query"];
			string Fragment = parameters["Fragment"];
			string UrlDecodedScheme = parameters["UrlDecodedScheme"];
			string UrlDecodedUser = parameters["UrlDecodedUser"];
			string UrlDecodedPassword = parameters["UrlDecodedPassword"];
			string UrlDecodedHost = parameters["UrlDecodedHost"];
			string UrlDecodedPath = parameters["UrlDecodedPath"];
			string UrlDecodedPort = parameters["UrlDecodedPort"];
			string UrlDecodedQuery = parameters["UrlDecodedQuery"];
			string UrlDecodedFragment = parameters["UrlDecodedFragment"];
			string ToString = parameters["ToString()"];
			string Note = parameters["Note"];

			/* uncomment the lines below to debug a specific line in an iterative test from a CSV source */

			//if (DataRow == 2)
			//{
			//	string ignored = "break point here";  // set breakpoint here to debug a particular row.
			//}

			BOG.Framework.Url testObj = null;

			if (!string.IsNullOrWhiteSpace(ThrowsException))
			{
				try
				{
					testObj = new Url(OriginalUrl);
				}
				catch (Exception err1)
				{
					string[] err = err1.GetType().ToString().Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
					Assert.Multiple(() =>
					{
						Assert.AreEqual(ThrowsException, err[err.Length - 1], "Exception expected, but caught a different exception (Row {0}).", DataRow);
						if (!string.IsNullOrWhiteSpace(ExceptionContains))
						{
							Assert.IsTrue(err1.Message.ToUpper().Contains(ExceptionContains.ToUpper()), "Exception message does not contain expected text \"" + ExceptionContains + "\"\r\nMessage: \"" + err1.Message + "\"  (Row {0}).", DataRow);
						}
					});
					return;
				}
				Assert.IsTrue(false, "Expected Exception " + ThrowsException + ", but no exception was thrown. (Row {0}).", DataRow);
			}
			else
			{
				testObj = new Url(OriginalUrl);

				Assert.Multiple(() =>
				{
					Assert.AreEqual(UrlDecodedScheme, testObj.Scheme, "UrlDecoded Scheme mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedUser, testObj.User, "UrlDecoded User mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedPassword, testObj.Password, "UrlDecoded Password mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedHost, testObj.Host, "UrlDecoded Host mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedPath, testObj.Path, "UrlDecoded Path mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedPort, testObj.PortExplicit, "UrlDecoded Port mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedQuery, testObj.Query, "UrlDecoded Query mismatch (Row {0}).", DataRow);
					Assert.AreEqual(UrlDecodedFragment, testObj.Fragment, "UrlDecoded Fragment mismatch (Row {0}).", DataRow);

					Assert.AreEqual(User, testObj.GetRaw(Url.UrlPart.User), "non-UrlDecoded User mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Password, testObj.GetRaw(Url.UrlPart.Password), "non-UrlDecoded Password mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Host, testObj.GetRaw(Url.UrlPart.Host), "non-UrlDecoded Host mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Port, testObj.GetRaw(Url.UrlPart.Port), "non-UrlDecoded Port mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Path, testObj.GetRaw(Url.UrlPart.Path), "non-UrlDecoded Path mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Query, testObj.GetRaw(Url.UrlPart.Query), "non-UrlDecoded Query mismatch (Row {0}).", DataRow);
					Assert.AreEqual(Fragment, testObj.GetRaw(Url.UrlPart.Fragment), "non-UrlDecoded Fragment mismatch (Row {0}).", DataRow);

					Assert.AreEqual(ToString, testObj.ToString(), "original Url reconstruction (Row {0}).", DataRow);
				});
			}
		}
	}
}
