using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOG.Framework;
using BOG.Framework.Extensions;
using NUnit.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class StringExTest
	{
		[Test, Description("QuotedTrim_UnquotedEmptyString(): check for a quoted empty string")]
		public void QuotedTrim_UnquotedEmptyString()
		{
			string Test = string.Empty;
			string Result = Test.QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedEmptyString(): check for a quoted empty string")]
		public void QuotedTrim_QuotedEmptyString()
		{
			string Result = "\"\"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedSingleSpace(): check for a quoted string of single space")]
		public void QuotedTrim_QuotedSingleSpace()
		{
			string Result = "\" \"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedMultipleSpaces(): check for a quoted string of multiple spaces")]
		public void QuotedTrim_QuotedMultipleSpaces()
		{
			string Result = "\"      \"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedRJString(): check for a quoted string of right justified values")]
		public void QuotedTrim_QuotedRJString()
		{
			string Result = "\"     X\"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare("X", Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedLJString(): check for a quoted string of left justified values")]
		public void QuotedTrim_QuotedLJString()
		{
			string Result = "\"X     \"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare("X", Result) == 0);
		}

		[Test, Description("QuotedTrim_QuotedCJString(): check for a quoted string of center justified values")]
		public void QuotedTrim_QuotedCJString()
		{
			string Result = "\"  X  \"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare("X", Result) == 0);
		}

		[Test, Description("QuotedTrim_EmbeddedQuotedString(): check for a quoted string embedded in quotes")]
		public void QuotedTrim_EmbeddedQuotedString()
		{
			string Result = "\" \"  X  \" \"".QuotedTrim(new char[] { ' ', '\t' }, '\"');
			Assert.IsTrue(string.Compare("\"  X  \"", Result) == 0);
		}

		[Test, Description("Filter(): case-insensitive")]
		public void Filter_CaseInsensitive()
		{
			string Filter = "0123456789.c";
			string Result = "76.34F.25.41C".Filter(Filter, true);
			Assert.IsTrue(string.Compare("76.34.25.41C", Result) == 0);
		}

		[Test, Description("Filter(): case-sensitive")]
		public void Filter_CaseSensitive()
		{
			string Filter = "0123456789.c";
			string Result = "76.34F.25.41C".Filter( Filter, false);
			Assert.IsTrue(string.Compare("76.34.25.41", Result) == 0);
		}

		[Test, Description("FilterOut(): case-insensitive")]
		public void FilterOut_CaseInsensitive()
		{
			string Filter = "0123456789.c";
			string Result = "76.34F.25.41C".FilterOut(Filter, true);
			Assert.IsTrue(string.Compare("F", Result) == 0);
		}

		[Test, Description("FilterOut(): case-sensitive")]
		public void FilterOut_CaseSensitive()
		{
			string Filter = "0123456789.c";
			string Result = "76.34F.25.41C".FilterOut(Filter, false);
			Assert.IsTrue(string.Compare("FC", Result) == 0);
		}
	}
}
