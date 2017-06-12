using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BOG.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class DetailedExceptionTest
	{
		[Test, TestCaseSource("GetTestData")]
		public void DetailedException_StripCredentials_Iterative_Test(string descriptor, string original, string expectedOutput)
		{
			string methodOutput = StripCredentials(original);

			Assert.That(
				methodOutput.Contains(expectedOutput),
				string.Format(
					"StripCredentialsTest failed for {0}:\r\nOriginal: {1}\r\nexpectedOutput: {2}\r\nmethodOutput: {3}", 
					descriptor, 
					original, 
					expectedOutput,
					methodOutput));
		}

		private string StripCredentials(string original)
		{
			string result = string.Empty;
			try
			{
				throw new Exception(original);
			}
			catch (Exception e)
			{
				result = DetailedException.WithEnterpriseContent(ref e);
			}
			return result;
		}

		#region Helpers
		private static IEnumerable<string[]> GetTestData()
		{
			Dictionary<string, string[]> TestIterations = new Dictionary<string, string[]>()
			{
				{ "ConnectionString", new string[] {
					"uid=somevalue;user id=somevalue;userid=somevalue;user=somevalue;username=somevalue;user name=somevalue;pwd=somevalue;pass=somevalue;password=somevalue;pwd=somevalue;",
					"uid=[contents hidden];user id=[contents hidden];userid=[contents hidden];user=[contents hidden];username=[contents hidden];user name=[contents hidden];pwd=[contents hidden];pass=[contents hidden];password=[contents hidden];pwd=[contents hidden]" }
				},
				{ "UriNoCredentials", new string[] {
					"http://server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"http://[contents:hidden]@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
				{ "UriNoCredentialsWithAtSign", new string[] {
					"http://@server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"http://[contents:hidden]@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
				{ "UriNoCredentialsAtSignAndColon", new string[] {
					"http://:@server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"http://[contents:hidden]@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
				{ "UriUserNameOnly", new string[] {
					"http://someuser@server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"http://[contents:hidden]@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
				{ "UriUserNameAndPassword", new string[] {
					"anythingunderthesun://someuser:somep%3Aass@server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"anythingunderthesun://[contents:hidden]@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
				{ "NoUriPatternMatch", new string[] {
					"anythingunderthesun:/someuser:somep%3Aass@server/path/file.asp?arg1=1&arg2=2#f1%3af2",
					"anythingunderthesun:/someuser:somep%3Aass@server/path/file.asp?arg1=1&arg2=2#f1%3af2" }
				},
			};

			foreach (string key in TestIterations.Keys)
			{
				string descriptor = key;
				string original = TestIterations[key][0];
				string expected = TestIterations[key][1];
				yield return new[] { descriptor, original, expected };
			}
		}
		#endregion
	}
}
