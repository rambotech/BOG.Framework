using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace BOG.Framework
{
    /// <summary>
    /// Provides enhanced string functionality
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// ReplaceNoCase: Allows a string Replace without a sensivitiy to case
        /// Same as the string replace() function, but allows optional case insensitivity when
        /// comparing the pattern.
        /// E.g. ReplaceNoCase ("DON'T GO BAREFOOT like Bigfoot goes barefoot", "barefoot", "shoeless", false)
        ///   ... returns DON'T GO BAREFOOT like Bigfoot goes shoeless
        /// E.g. ReplaceNoCase ("DON'T GO BAREFOOT like Bigfoot goes barefoot", "barefoot", "shoeless", true)
        ///   ... returns DON'T GO shoeless like Bigfoot goes shoeless
        /// </summary>
        /// <param name="original">the string to search</param>
        /// <param name="pattern">the string to find</param>
        /// <param name="substitute">The string to replace what was found</param>
        /// <param name="ignoreCase">true to ignore case.  false here has the same behavior as .Replace()</param>
        /// <returns></returns>
        public static string ReplaceNoCase(string original, string pattern, string substitute, bool ignoreCase)
        {
            int Index = 0;
            int BaseIndex = 0;
            int Offset = 0;
            bool IsMatch;
            StringBuilder s = new StringBuilder();

            while (Index < original.Length && pattern.Length > 0)
            {
                if (ignoreCase)
                {
                    IsMatch = (char.ToLower(original[Index]) == char.ToLower(pattern[0]));
                }
                else
                {
                    IsMatch = (original[Index] == pattern[0]);
                }
                if (IsMatch)
                {
                    while (++Offset < pattern.Length && Index + Offset < original.Length)
                        if (ignoreCase ? char.ToLower(original[Index + Offset]) != char.ToLower(pattern[Offset]) : original[Index + Offset] != pattern[Offset])
                            break;  // disproved
                    if (Offset == pattern.Length) // matched
                    {
                        if (BaseIndex < Index)
                            s.Append(original.Substring(BaseIndex, Index - BaseIndex));
                        s.Append(substitute);
                        Index += Offset;
                        BaseIndex = Index;
                        Offset = 0;
                        continue;
                    }
                    Offset = 0;
                }
                Index++;
            }
            if (BaseIndex < Index)
                s.Append(original.Substring(BaseIndex, Index - BaseIndex));

            return s.ToString();
        }


		/// <summary>
		/// Extends RegEx.Replace method.  Instead of replacing all matches with a static value,
		/// replaces the text of the individual matches, then replaces the original match in
		/// the content string.  E.g.
		/// RegExMatchReplace (&quot;&lt;x72&gt; &lt;y44&gt; &lt;D333&gt; &lt;d2&gt; &lt;d33&gt;&quot;, &quot;&lt;[a-z](\d){2-3}&gt;&quot;, &quot;&lt;d&quot;, &quot;&lt;f&quot;, true)
		/// ... returns &quot;&lt;x72&gt; &lt;y44&gt; &lt;f333&gt; &lt;d2&gt; &lt;f33&gt;&quot;
		/// </summary>
		/// <param name="content"></param>
		/// <param name="pattern"></param>
		/// <param name="locate"></param>
		/// <param name="substitute"></param>
		/// <param name="ignoreCase"></param>
		/// <returns></returns>
		public static string RegExMatchReplace(string content, string pattern, string locate, string substitute, bool ignoreCase)
        {
            Regex r = new Regex(pattern, ignoreCase ? System.Text.RegularExpressions.RegexOptions.IgnoreCase : 0);
            MatchCollection mc = r.Matches(content);

            foreach (Match m in mc)
            {
                string s = m.ToString().Replace(locate, substitute);
                content = content.Replace(m.ToString(), s);
            }
            return content;
        }

        /// <summary>
        /// Equivalent to string.IndexOfAny(), but the search is for strings not for character.
        /// </summary>
        /// <param name="search">the string to search</param>
        /// <param name="keywords">the array of strings to look for</param>
        /// <param name="ignoreCase">case insensitive matching when true.</param>
        /// <param name="lastMatch">When true, returns the index of the last match instead of the first.</param>
        /// <returns>-1 if not found, or the index of the first character in the search parameter.</returns>
        public static int IndexOfAnyString(string search, string[] keywords, bool ignoreCase, bool lastMatch)
        {
            int startIndex = -1;
            foreach (string s in keywords)
            {
                if (ignoreCase)
                {
                    startIndex = search.ToLower().IndexOf(s.ToLower());
                }
                else
                {
                    startIndex = search.IndexOf(s);
                }
                if (startIndex >= 0 && !lastMatch) break;
            }
            return startIndex;
        }

		/// <summary>
		/// Searches a string for a match, but allows question marks to act like a wildcard and match any character.
		/// </summary>
		/// <param name="core"></param>
		/// <param name="search"></param>
		/// <param name="startAt"></param>
		/// <param name="ignoreCase"></param>
		/// <param name="wildcard"></param>
		/// <returns></returns>
		public static int WildcardIndexOfAnyString(string core, string search, int startAt, bool ignoreCase, char wildcard)
        {
            int Result = -1;
            if (search.Length <= core.Length)
            {
                int outerIndex = 0;
                int innerIndex = 0;
                for (outerIndex = startAt; outerIndex <= core.Length - search.Length; outerIndex++)
                {
                    bool Found = true;
                    for (innerIndex = 0; innerIndex < search.Length; innerIndex++)
                    {
                        if (search[innerIndex] == wildcard)
                        {
                            continue;
                        }
                        if (ignoreCase == true && char.ToLower(core[outerIndex + innerIndex]) == char.ToLower(search[innerIndex]))
                        {
                            continue;
                        }
                        if (core[outerIndex + innerIndex] == search[innerIndex])
                        {
                            continue;
                        }
                        Found = false;
                        break;
                    }
                    if (Found)
                    {
                        Result = outerIndex;
                        break;
                    }
                }
            }
            return Result;
        }

        /// <summary>
        /// Trims a string which is enclosed by quotes.  The quotes and the left-side and right-side whitespace 
        /// from the enclosed string is removed.
        /// E.g.  " \" ex \" " becomes "ex"
        /// </summary>
        /// <param name="search">The string to be trimed</param>
        /// <param name="whitespace">array of characters defining whitespace characters</param>
        /// <param name="quote">The character to treat as a quotation.</param>
        /// <returns></returns>
        public static string QuotedTrim(string search, char[] whitespace, char quote)
        {
            string s = string.Empty;

            if (search.Length > 0)
            {
                int start = 0;
                int end = search.Length;

                while (search[start].ToString().IndexOfAny(whitespace) == 0 && start < search.Length - 1)
                    start++;

                while (search[end - 1].ToString().IndexOfAny(whitespace) == 0 && end > 1)
                    end--;

                if (start < end)
                {
                    s = search.Substring(start, end - start);
                }

                if (quote != 0 && s.Length > 1 && s[0] == quote && s[s.Length - 1] == quote)
                {
                    s = s.Substring(1, s.Length - 2);
                    if (s.Length > 0)
                    {
                        start = 0;
                        end = s.Length;
                        while (s[start].ToString().IndexOfAny(whitespace) == 0 && start < s.Length - 1)
                            start++;

                        while (end >= 1 && s[end - 1].ToString().IndexOfAny(whitespace) == 0 && end >= start)
                            end--;

                        if (start >= end)
                        {
                            s = string.Empty;
                        }
                        else
                        {
                            s = s.Substring(start, end - start);
                        }
                    }
                }
            }
            return s;
        }

        /// <summary>
        /// Takes a string which may have XML comments or &amp;...; encoding inside it,
        /// and return the InnerText (decoded) equivalent of it.  This is a quick way
        /// to take the raw text harvested in an HTML or XML tag, and do an Html decode
        /// on the text.
        /// </summary>
        /// <param name="raw">The string to parse</param>
        /// <returns>the decoded string.  If an exception is thrown in the processing
        /// the original raw string </returns>
        public static string TextAsInnerText(string raw)
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.LoadXml("<?xml version='1.0'?><root>" + raw + "</root>");
                return xml.SelectSingleNode(@"/root").InnerText;
            }
            catch
            {
                return raw;
            }
        }

        /// <summary>
        /// Decodes a string containing Base64 to an unencoded string
        /// </summary>
        /// <param name="inputStr">Base64 compliant string</param>
        /// <returns></returns>
        public static string Base64DecodeString(string inputStr)
        {
            byte[] decodedByteArray = Convert.FromBase64CharArray(inputStr.ToCharArray(), 0, inputStr.Length);
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < decodedByteArray.Length; i++)
            {
                s.Append((char)decodedByteArray[i]);
            }
            return (s.ToString());
        }

		/// <summary>
		/// Encodes a string into Base64
		/// </summary>
		/// <param name="inputStr">the string value to encode</param>
		/// <param name="insertLineBreaks">Whether the resulting Base64 should be broken into separate lines.</param>
		/// <returns>Base64</returns>
		public static string Base64EncodeString(string inputStr, bool insertLineBreaks)
        {
            byte[] rawByteArray = new byte[inputStr.Length];
            char[] encodedArray = new char[inputStr.Length * 2];

            for (int i = 0; i < inputStr.Length; i++)
                rawByteArray[i] = (byte)inputStr[i];

            Convert.ToBase64CharArray(
                rawByteArray,
                0,
                inputStr.Length,
                encodedArray,
                0,
                insertLineBreaks ?
                    Base64FormattingOptions.InsertLineBreaks : Base64FormattingOptions.None);
            string EncodedString = new string(encodedArray);
            int ActualLength = EncodedString.Length;
            while (ActualLength-- > 0 && EncodedString[ActualLength] == '\0') ;
            return EncodedString.Substring(0, ActualLength + 1);
        }

		/// <summary>
		/// Encodes a string into Base64
		/// </summary>
		/// <param name="inputStr">the string value to encode</param>
		/// <returns>Base64</returns>
		public static string Base64EncodeString(string inputStr)
        {
            return Base64EncodeString(inputStr, true);
        }

		/// <summary>
		/// Shows a hex display of a source string similiar to:
		/// 0000: 48 65 6c 6c 6f 20 57 6f 72 6c 64                 | Hello World     
		/// </summary>
		/// <param name="source">The string to examine</param>
		/// <returns>As above.</returns>
		public static string ShowStringAsHex(string source)
        {
            int Offset = 0;
            int Index = 0;
            StringBuilder Result = new StringBuilder();

            while (true)
            {
                Result.Append(string.Format("{0:x4}: ", Offset));
                for (Index = Offset; Index < Offset + 16; Index++)
                {
                    if (Index != Offset && Index % 8 == 0)
                    {
                        Result.Append("| ");
                    }
                    if (Index < source.Length)
                    {
                        Result.Append(string.Format("{0:x2} ", (byte)source[Index]));
                    }
                    else
                    {
                        Result.Append("   ");
                    }
                }

                Result.Append(" .. ");

                for (Index = Offset; Index < Offset + 16; Index++)
                {
                    if (Index != Offset && Index % 8 == 0)
                    {
                        Result.Append("|");
                    }
                    if (Index < source.Length)
                    {
                        Result.Append(source[Index] < '!' || source[Index] > '\x7F' ? '.' : source[Index]);
                    }
                    else
                    {
                        Result.Append(' ');
                    }
                }
                Result.AppendLine();
                if (Index >= source.Length) break;
                Offset += 16;
            }
            return Result.ToString();
        }

        private enum enumParseState : int { StartToken, InQuote, InToken };

        /// <summary>
        /// For US dollar only.  Parses a financial value which may contain a dollar sign ($) and
        /// comma separators.  A simple double.Parse() call will choke on these characters.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>The value as a double</returns>
        public static double FinancialDoubleParse(string source)
        {
            bool Negative = false;
            string sourceWork = source;

            sourceWork = sourceWork.Replace("$", string.Empty).Replace(",", string.Empty);
            if (sourceWork.Length > 2 && sourceWork[0] == '(' && sourceWork[sourceWork.Length - 1] == ')')
            {
                sourceWork = sourceWork.Substring(1, sourceWork.Length - 2);
                Negative = true;
            }
            return (Negative ? (double)-1.0 : (double)1.0) * double.Parse(sourceWork);
        }

		/// <summary>
		/// Looks for and replaces embedded environment variables (%...%) and special folders ([...]), and replaces them if found.
		/// If placeholder can not be resolved, it remains unchanged.  Case is ignored for the placeholder.
		/// </summary>
		/// <param name="rawPath">The path string containing potential placeholders.</param>
		/// <returns>The resolved path</returns>
		public static string ResolvePathPlaceholders(string rawPath)
		{
			string result = rawPath;
			// Locate and replace environment variable placeholders, e.g.  "%ALLUSERSPROFILE%"
			foreach (DictionaryEntry env in Environment.GetEnvironmentVariables())
			{
				string searchFor = "%" + (string) env.Key + "%";
				string replaceWith = (string) env.Value;
				result = ReplaceNoCase(result, searchFor, replaceWith, true);
			}

			foreach (string specialFolderName in Enum.GetNames(typeof(Environment.SpecialFolder)))
			{
				Environment.SpecialFolder f = (Environment.SpecialFolder) Enum.Parse(typeof(Environment.SpecialFolder), specialFolderName);
				string searchFor = "[" + specialFolderName + "]";
				string replaceWith = Environment.GetFolderPath(f);
				result = ReplaceNoCase(result, searchFor, replaceWith, true);
			}
			return result;
		}
	}
}
