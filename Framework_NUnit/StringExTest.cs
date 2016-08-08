using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOG.Framework;
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
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedEmptyString(): check for a quoted empty string")]
        public void QuotedTrim_QuotedEmptyString()
        {
            string Test = "\"\"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedSingleSpace(): check for a quoted string of single space")]
        public void QuotedTrim_QuotedSingleSpace()
        {
            string Test = "\" \"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedMultipleSpaces(): check for a quoted string of multiple spaces")]
        public void QuotedTrim_QuotedMultipleSpaces()
        {
            string Test = "\"      \"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare(string.Empty, Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedRJString(): check for a quoted string of right justified values")]
        public void QuotedTrim_QuotedRJString()
        {
            string Test = "\"     X\"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare("X", Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedLJString(): check for a quoted string of left justified values")]
        public void QuotedTrim_QuotedLJString()
        {
            string Test = "\"X     \"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare("X", Result) == 0);
        }

        [Test, Description("QuotedTrim_QuotedCJString(): check for a quoted string of center justified values")]
        public void QuotedTrim_QuotedCJString()
        {
            string Test = "\"  X  \"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare("X", Result) == 0);
        }

        [Test, Description("QuotedTrim_EmbeddedQuotedString(): check for a quoted string embedded in quotes")]
        public void QuotedTrim_EmbeddedQuotedString()
        {
            string Test = "\" \"  X  \" \"";
            string Result = StringEx.QuotedTrim(Test, new char[] { ' ', '\t' }, '\"');
            Assert.IsTrue(string.Compare("\"  X  \"", Result) == 0);
        }

		[Test, Description("Filter(): case-insensitive")]
		public void Filter_CaseInsensitive()
		{
			string Test = "76.34F.25.41C";
			string Filter = "0123456789.c";
			string Result = StringEx.Filter(Test, Filter, true);
			Assert.IsTrue(string.Compare("76.34.25.41C", Result) == 0);
		}

		[Test, Description("Filter(): case-sensitive")]
		public void Filter_CaseSensitive()
		{
			string Test = "76.34F.25.41C";
			string Filter = "0123456789.c";
			string Result = StringEx.Filter(Test, Filter, false);
			Assert.IsTrue(string.Compare("76.34.25.41", Result) == 0);
		}

		[Test, Description("FilterOut(): case-insensitive")]
		public void FilterOut_CaseInsensitive()
		{
			string Test = "76.34F.25.41C";
			string Filter = "0123456789.c";
			string Result = StringEx.FilterOut(Test, Filter, true);
			Assert.IsTrue(string.Compare("F", Result) == 0);
		}

		[Test, Description("FilterOut(): case-sensitive")]
		public void FilterOut_CaseSensitive()
		{
			string Test = "76.34F.25.41C";
			string Filter = "0123456789.c";
			string Result = StringEx.FilterOut(Test, Filter, false);
			Assert.IsTrue(string.Compare("FC", Result) == 0);
		}
	}
}
