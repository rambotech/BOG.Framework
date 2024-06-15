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
                        Assert.That(string.Compare(ThrowsException, err[err.Length - 1], false) == 0, $"Exception expected, but caught a different exception (Row {DataRow}).");
                        if (!string.IsNullOrWhiteSpace(ExceptionContains))
                        {
                            Assert.That(
                                err1.Message.ToUpper().Contains(ExceptionContains.ToUpper()), 
                                $"Exception message does not contain expected text \"{ExceptionContains}\"\r\nMessage: \"{err1.Message}\"  (Row {DataRow}).");
                        }
                    });
                    return;
                }
                Assert.That(false, $"Expected Exception {ThrowsException} but no exception was thrown. (Row {DataRow}).");
            }
            else
            {
                testObj = new Url(OriginalUrl);

                Assert.Multiple(() =>
                {
                    Assert.That(string.Compare(UrlDecodedScheme, testObj.Scheme, false) ==0, $"UrlDecoded Scheme mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedUser, testObj.User, false) == 0, $"UrlDecoded User mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedPassword, testObj.Password, false) == 0, $"UrlDecoded Password mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedHost, testObj.Host, false) == 0, $"UrlDecoded Host mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedPath, testObj.Path, false) == 0, $"UrlDecoded Path mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedPort, testObj.PortExplicit, false) == 0, $"UrlDecoded Port mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedQuery, testObj.Query, false) == 0, $"UrlDecoded Query mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(UrlDecodedFragment, testObj.Fragment, false) == 0, $"UrlDecoded Fragment mismatch (Row {DataRow}).");

                    Assert.That(string.Compare(User, testObj.GetRaw(Url.UrlPart.User), false) == 0, $"non-UrlDecoded User mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Password, testObj.GetRaw(Url.UrlPart.Password), false) == 0, $"non-UrlDecoded Password mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Host, testObj.GetRaw(Url.UrlPart.Host), false) == 0, $"non-UrlDecoded Host mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Port, testObj.GetRaw(Url.UrlPart.Port), false) == 0, $"non-UrlDecoded Port mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Path, testObj.GetRaw(Url.UrlPart.Path), false) == 0, $"non-UrlDecoded Path mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Query, testObj.GetRaw(Url.UrlPart.Query), false) == 0, $"non-UrlDecoded Query mismatch (Row {DataRow}).");
                    Assert.That(string.Compare(Fragment, testObj.GetRaw(Url.UrlPart.Fragment), false) == 0, $"non-UrlDecoded Fragment mismatch (Row {DataRow}).");

                    Assert.That(string.Compare(ToString, testObj.ToString().ToLowerInvariant(), false) ==0, $"original Url reconstruction (Row {DataRow}).");
                });
            }
        }
    }
}
