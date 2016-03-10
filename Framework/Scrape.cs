using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;

namespace BOG.Framework
{
    /// <summary>
    /// An Item which is retained in the list, but marked as consumed.
    /// Allows a unique list, even if an item has been previously read.
    /// </summary>
    public class MemoryItem<T>
    {
        private T _value;
        private DateTime _consumed;
        private DateTime _recorded;

        /// <summary>
        /// This initialize is only for the use of an XMLSerializers
        /// </summary>
        public MemoryItem()
        {
        }

        /// <summary>
        /// Instantiates the object as a copy of an existing object.
        /// </summary>
        /// <param name="value"></param>
        public MemoryItem(T value)
        {
            _value = value;
            _consumed = DateTime.MinValue;
            _recorded = DateTime.Now;
        }

        /// <summary>
        /// The value of the memory item.
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        /// If the value is a datetime, the item has been consumed from the list.
        /// </summary>
        public DateTime Consumed
        {
            get { return _consumed; }
            set { _consumed = value; }
        }

        /// <summary>
        /// The datetime when the item was added to the list.
        /// </summary>
        public DateTime Recorded
        {
            get { return _recorded; }
            set { _recorded = value; }
        }
    }

    /// <summary>
    /// A list of MemoryItem, which can allow/disallow duplicate values, and allows values to be
    /// retrieved at random, or as a stack (FIFO) or queue (LIFO).
    /// </summary>
    /// <typeparam name="T">The type of the value to store as an item in the list.</typeparam>
    public class MemoryList<T>
    {
        /// <summary>
        /// The method of retrieving items from the list.
        /// </summary>
        public enum MemoryListRetrieveSequence
        {
            Random,
            Stack,
            Queue,
            LIFO,  // synonym for Stack
            FIFO   // synonym for Queue
        }

        List<MemoryItem<T>> _l = new List<MemoryItem<T>>();
        MemoryListRetrieveSequence _sequence = MemoryListRetrieveSequence.Random;
        string _Name = string.Empty;
        bool _UniqueValues = true;
        bool _IgnoreCase = false;

        /// <summary>
        /// Default instantiation
        /// </summary>
        public MemoryList()
        {
        }

        /// <summary>
        /// Parameterized instantiation
        /// </summary>
        /// <param name="name">The name of the list</param>
        /// <param name="uniqueValues">when true, values may not duplicate in the list.  Note: even when
        /// an existing value is consumed from the list, it is banned from being entered again.</param>
        /// <param name="ignoreCase"></param>
        public MemoryList(string name, bool uniqueValues, bool ignoreCase)
        {
            _Name = name;
            _UniqueValues = uniqueValues;
            _IgnoreCase = ignoreCase;
        }

        public MemoryList(string name, bool uniqueValues, bool ignoreCase, MemoryListRetrieveSequence readSequence)
        {
            _Name = name;
            _UniqueValues = uniqueValues;
            _IgnoreCase = ignoreCase;
            _sequence = readSequence;
        }

        public MemoryListRetrieveSequence Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public bool UniqueValues
        {
            get { return _UniqueValues; }
            set { _UniqueValues = value; }
        }

        public bool IgnoreCase
        {
            get { return _IgnoreCase; }
            set { _IgnoreCase = value; }
        }

        public List<MemoryItem<T>> ListItem
        {
            get { return _l; }
            set { _l = value; }
        }

        public bool HasValues()
        {
            int i;
            for (i = 0; i < _l.Count; i++)
            {
                if (_l[i].Consumed == DateTime.MinValue)
                {
                    break;
                }
            }
            return (i < _l.Count);
        }

        private int Count(bool Uncomsumed)
        {
            int i, c = 0;
            for (i = 0; i < _l.Count; i++)
                if ((Uncomsumed && _l[i].Consumed == DateTime.MinValue) || (!Uncomsumed && _l[i].Consumed != DateTime.MinValue))
                    c++;
            return c;
        }

        public int ConsumedCount()
        {
            return Count(false);
        }

        public int UnconsumedCount()
        {
            return Count(true);
        }

        public int CountAll()
        {
            return _l.Count;
        }

        public void StoreValue(T value)
        {
            bool isString = value.GetType() == Type.GetType("string");
            if (_UniqueValues)
            {
                int i;
                for (i = 0; i < _l.Count; i++)
                {
                    if (isString)
                    {
                        if (string.Compare(_l[i].Value.ToString(), value.ToString(), _IgnoreCase) == 0)
                        {
                            break;   // already in the list
                        }
                    } else
                    {
                        if (_l[i].Value.Equals(value))
                        {
                            break;   // already in the list
                        }
                    }
                }
                if (i < _l.Count)
                {
                    return;  // prevents adding to the list.
                }
            }
            _l.Add(new MemoryItem<T>(value));
        }

        public T RecallValue()
        {
            bool found = false;
            int i, UseIndex = -1;

            for (i = 0; i < _l.Count && !found; i++)
            {
                if (_l[i].Consumed == DateTime.MinValue)
                {
                    switch (_sequence)
                    {
                        case MemoryListRetrieveSequence.Random:
                            UseIndex = i;
                            found = true;
                            break;

                        case MemoryListRetrieveSequence.Queue:
                        case MemoryListRetrieveSequence.FIFO:
                            if (UseIndex == -1 || _l[i].Recorded < _l[UseIndex].Recorded)
                            {
                                UseIndex = i;
                            }
                            break;

                        case MemoryListRetrieveSequence.Stack:
                        case MemoryListRetrieveSequence.LIFO:
                            if (UseIndex == -1 || _l[i].Recorded > _l[UseIndex].Recorded)
                            {
                                UseIndex = i;
                            }
                            break;
                    }
                }
            }
            if (UseIndex == -1)
            {
                throw new Exception("Method RecallValue() used against an empty or exhausted list.");
            }

            _l[UseIndex].Consumed = DateTime.Now;
            return _l[UseIndex].Value;
        }
    }

    public class WebScrapeResponse
    {
        private string _StatusCode;
        private string _StatusText;
        private string _ErrorMessage;
        private string _Content;
        private string _ContentType;
        private string _ContentEncoding;
        private long _ContentLength;
        private string _CharacterSet;
        private WebHeaderCollection _headers;
        private CookieCollection _cookies;
        private string _ResponseURI;

        public WebScrapeResponse()
        {
            _StatusCode = "-1";
            _StatusText = "";
            _ErrorMessage = string.Empty;
            _Content = string.Empty;
            _ContentType = string.Empty;
            _ContentEncoding = string.Empty;
            _ContentLength = 0;
            _CharacterSet = string.Empty;
            _headers = null;
            _cookies = null;
            _ResponseURI = string.Empty;
        }

        public string StatusCode
        {
            get { return _StatusCode; }
            set { _StatusCode = value; }
        }

        public string StatusText
        {
            get { return _StatusText; }
            set { _StatusText = value; }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }

        public string ContentEncoding
        {
            get { return _ContentEncoding; }
            set { _ContentEncoding = value; }
        }

        public long ContentLength
        {
            get { return _ContentLength; }
            set { _ContentLength = value; }
        }

        public string CharacterSet
        {
            get { return _CharacterSet; }
            set { _CharacterSet = value; }
        }

        public WebHeaderCollection headers
        {
            get { return _headers; }
            set { _headers = value; }
        }

        public CookieCollection cookies
        {
            get { return _cookies; }
            set { _cookies = value; }
        }

        public string ResponseURI
        {
            get { return _ResponseURI; }
            set { _ResponseURI = value; }
        }
    }

    public class Scrape
    {
        // simple: for simple extracts of data from the HTML, not requiring form posting,
        // cookie preservation or session retention.
        public bool HttpTextToString(string url, string headers, ref string captured)
        {
            try
            {
                WebClient wc = new WebClient();
                // Add a user agent header in case the requested URI contains a query.
                if (headers.Length == 0)
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.75 Safari/537.1 ");
                }
                else
                {
                    foreach (string line in headers.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string[] tv = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        wc.Headers.Add(tv[0].Trim(), tv[1].Trim());
                    }
                }
                captured = wc.DownloadString(url);
                return true;
            }
            catch (Exception ex)
            {
                captured = DetailedException.WithEnterpriseContent(ref ex, "***ERROR***", string.Empty);
                return false;
            }
        }

        public WebScrapeResponse HttpCapture(string url, string postdata, string headers, CookieCollection cookie)
        {
            WebScrapeResponse r = new WebScrapeResponse();
            try
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);
                if (headers.Length > 0)
                {
                    string[] raw = headers.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < raw.Length; i++)
                    {
                        string[] v = raw[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (v.Length > 1)
                        {
                            try
                            {
                                WebReq.Headers.Add(v[0].Trim(), v.Length == 1 ? string.Empty : raw[i].Substring(v[0].Length + 1).Trim());
                            }
                            catch
                            {
                            }
                        }
                    }
                }

                if (cookie != null && WebReq.CookieContainer.Count == 0)
                {
                    WebReq.CookieContainer.Add(cookie);
                }

                if (postdata.Length > 0)
                {
                    WebReq.Method = "POST";
                    WebReq.ContentType = "application/x-www-form-urlencoded";
                    byte[] buffer = Encoding.ASCII.GetBytes(postdata);
                    WebReq.ContentLength = buffer.Length;
                    using (Stream PostData = WebReq.GetRequestStream())
                    {
                        PostData.Write(buffer, 0, buffer.Length);
                        PostData.Close();
                    }
                }

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                using (Stream Answer = WebResp.GetResponseStream())
                {
                    using (StreamReader _Answer = new StreamReader(Answer))
                    {
                        r.Content = _Answer.ReadToEnd();
                    }
                }
                r.CharacterSet = WebResp.CharacterSet;
                r.ContentEncoding = WebResp.ContentEncoding;
                r.ContentLength = WebResp.ContentLength;
                r.ContentType = WebResp.ContentType;
                r.cookies = WebResp.Cookies;
                r.ErrorMessage = string.Empty;
                r.headers = WebResp.Headers;
                r.ResponseURI = WebResp.ResponseUri.ToString();
                r.StatusCode = ((int)Enum.Parse(typeof(HttpStatusCode), WebResp.StatusCode.ToString())).ToString();
                r.StatusText = WebResp.StatusDescription;
            }
            catch (Exception ex)
            {
                r.ErrorMessage = ex.Message;
            }
            return r;
        }

        public StringCollection RegExChunk(string rawText,
                string startPattern, bool ignoreStartCase, int startIteration,
                string endPattern, bool ignoreEndCase, int endIteration,
                int MaxLengthCheck)
        {
            int MatchCount = 0;
            StringCollection StringMatches = new StringCollection();
            Regex rStart = new Regex(startPattern, ignoreStartCase ? RegexOptions.IgnoreCase : RegexOptions.None);
            Regex rEnd = new Regex(endPattern, ignoreEndCase ? RegexOptions.IgnoreCase : RegexOptions.None);
            MatchCollection matchesStart = rStart.Matches(rawText);
            for (int i = startIteration == 0 ? 0 : startIteration - 1; i < matchesStart.Count; i++)
            {
                if (startIteration == 0 || i + 1 == startIteration)
                {
                    MatchCollection matchesEnd;
                    int StartOffset;
                    if (MaxLengthCheck <= 0 || matchesStart[i].Index + matchesStart[i].Length + MaxLengthCheck > rawText.Length)
                    {
                        StartOffset = matchesStart[i].Index;
                        matchesEnd = rEnd.Matches(rawText, matchesStart[i].Index + matchesStart[i].Length);
                    }
                    else
                    {
                        StartOffset = 0;
                        matchesEnd = rEnd.Matches(rawText.Substring(matchesStart[i].Index, MaxLengthCheck), matchesStart[i].Length);
                    }
                    for (int j = endIteration == 0 ? 0 : endIteration - 1; j < matchesEnd.Count; j++)
                    {
                        if (endIteration == 0 || j + 1 == endIteration)
                        {
                            MatchCount++;
                            StringMatches.Add(rawText.Substring(
                                matchesStart[i].Index,
                                matchesEnd[j].Index + matchesEnd[j].Length - StartOffset));
                            if (endIteration != 0) break;
                        }
                    }
                    if (startIteration != 0) break;
                }
            }
            return StringMatches;
        }

        public StringCollection RegExFind(string rawText, string pattern, bool ignoreCase, int iteration)
        {
            int MatchCount = 0;
            StringCollection StringMatches = new StringCollection();
            Regex r = new Regex(pattern, ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None);
            MatchCollection matches = r.Matches(rawText);
            for (int i = 0; i < matches.Count; i++)
            {
                if ((iteration == 0 || i + 1 == iteration) && matches[i].Index + 1 <= rawText.Length)
                {
                    MatchCount++;
                    StringMatches.Add(matches[i].Value);
                    if (iteration != 0) break;
                }
            }
            return StringMatches;
        }

        public string StripHTML(string htmlString)
        {
            //This pattern Matches everything found inside html tags;
            //(.|\n) - > Look for any character or a new line
            // *?  -> 0 or more occurences, and make a non-greedy search meaning
            //That the match will stop at the first available '>' it sees, and not at the last one
            //(if it stopped at the last one we could have overlooked
            //nested HTML tags inside a bigger HTML tag..)
            // Thanks to Oisin and Hugh Brown for helping on this one...
            string pattern = @"<(.|\n)*?>";

            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        public string ExtractText(string blob, string XPath, bool cleanAttributes)
        {
            StringBuilder Fragment = new StringBuilder();
            Fragment.Append("<?xml version='1.0' ?><root>");
            StringBuilder cleaned = new StringBuilder();
            if (cleanAttributes == false)
            {
                cleaned.Append(blob);
            }
            else
            {
                bool InTag = true;
                bool Drop = false;
                int Index = 0;
                while (Index < blob.Length)
                {
                    switch (blob[Index])
                    {
                        case '<':
                            InTag = true;
                            Drop = false;
                            break;
                        case '>':
                            InTag = false;
                            Drop = false;
                            break;
                        case ' ':
                            Drop = InTag;
                            break;
                        default:
                            break;
                    }
                    if (Drop == false) cleaned.Append(blob[Index]);
                    Index++;
                }
            }
            Fragment.Append(System.Web.HttpUtility.HtmlDecode(cleaned.ToString()));
            Fragment.Append("</root>");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Fragment.ToString());
            return doc.SelectNodes("//root" + XPath)[0].InnerText;
        }

        public string ExtractText(string blob, string XPath)
        {
            return ExtractText(blob, XPath, false);
        }
    }
}
