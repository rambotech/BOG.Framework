using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework
{
	/// <summary>
	/// Url parser and reconstructor.
	/// </summary>
	public class Url
	{
		/// <summary>
		/// Specifices the part of a URL to return for the GetRaw() ,method
		/// </summary>
		public enum UrlPart : int
		{
			/// <summary>
			/// the portion before ::/
			/// </summary>
			Scheme,
			/// <summary>
			/// The user part of credentials (user:password)
			/// </summary>
			User,
			/// <summary>
			/// The password part of credentials (user:password)
			/// </summary>
			Password,
			/// <summary>
			/// The remote server for the connection.
			/// </summary>
			Host,
			/// <summary>
			/// The port of the remote server for the connection.
			/// </summary>
			Port,
			/// <summary>
			/// The port of the remote server, or empty if it is the default port for the scheme
			/// </summary>
			PortExplicit,
			/// <summary>
			/// The path (after server, before ? or #)
			/// </summary>
			Path,
			/// <summary>
			/// The query (after ?, before #) 
			/// </summary>
			Query,
			/// <summary>
			///  The fragment (after #)
			/// </summary>
			Fragment
		}

		private string _scheme = string.Empty;
		private string _user = string.Empty;
		private string _password = string.Empty;
		private string _host = string.Empty;
		private int _port = -1;
		private string _portRaw = string.Empty;
		private string _path = string.Empty;
		private string _query = string.Empty;
		private string _fragment = string.Empty;

		bool UnknownDefaultPort = true;

		private Dictionary<string, int> _defaultPorts = new Dictionary<string, int>()
		{
			{ "ftp", 21 },
			{ "ssh", 22 },
			{ "telnet", 23 },
			{ "smtp", 25 },
			{ "dns",  53},
			{ "tftp", 69 },
			{ "http", 80 },
			{ "pop3", 110 },
			{ "ntp", 123 },
			{ "imap",  143 },
			{ "snmp",  161 },
			{ "ldap",  389 },
			{ "https", 443 },
			{ "ldaps",  636 },
			{ "mysql",  3306 }
		};

		/// <summary>
		/// New instance with no data population.
		/// </summary>
		public Url()
		{

		}

		/// <summary>
		/// New instance from a url string.
		/// </summary>
		/// <param name="url"></param>
		public Url(string url)
		{
			ParseUrl(url);
		}

		/// <summary>
		/// Get the scheme, url-decoded.
		/// </summary>
		public string Scheme { get { return System.Web.HttpUtility.UrlDecode(this._scheme); } set { this._scheme = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Get the user, url-decoded.
		/// </summary>
		public string User { get { return System.Web.HttpUtility.UrlDecode(this._user); } set { this._user = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Get the password, url-decoded.
		/// </summary>
		public string Password { get { return System.Web.HttpUtility.UrlDecode(this._password); } set { this._password = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Get the host, url-decoded.
		/// </summary>
		public string Host { get { return System.Web.HttpUtility.UrlDecode(this._host); } set { this._host = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Gets or sets the port as it appears in the URL, url-decoded.
		/// </summary>
		public int Port
		{
			get
			{
				return this._port;
			}
			set
			{
				this._port = value;
				this._portRaw = this._defaultPorts.ContainsKey(this._scheme) && _defaultPorts[this._scheme] == this._port ? string.Empty : this._port.ToString();
			}
		}

		/// <summary>
		/// Gets the port as it appears in the URL, which may be blank.
		/// </summary>
		public string PortExplicit
		{
			get
			{
				return this.UnknownDefaultPort ? System.Web.HttpUtility.UrlDecode(this._portRaw) : string.Empty;
			}
		}

		/// <summary>
		/// Get the path, url-decoded.
		/// </summary>
		public string Path { get { return System.Web.HttpUtility.UrlDecode(this._path); } set { this._path = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Get the query, url-decoded.
		/// </summary>
		public string Query { get { return System.Web.HttpUtility.UrlDecode(this._query); } set { this._query = System.Web.HttpUtility.UrlEncode(value); } }

		/// <summary>
		/// Get the fragment, url-decoded.
		/// </summary>
		public string Fragment { get { return System.Web.HttpUtility.UrlDecode(this._fragment); } set { this._fragment = System.Web.HttpUtility.UrlEncode(value); } }

		private void ParseUrl(string url)
		{
			string workingUrl = url;
			string[] urlParts = workingUrl.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);

			if ((urlParts.Length == 1 && urlParts[0] == workingUrl) || urlParts.Length > 2)
			{
				throw new UriFormatException("invalid url format: missing or multiple scheme delimiters: \"://\"");
			}

			this._scheme = urlParts[0];
			workingUrl = urlParts.Length == 1 ? string.Empty : urlParts[1];

			this._portRaw = string.Empty;
			this.UnknownDefaultPort = !this._defaultPorts.ContainsKey(this._scheme);
			if (!this.UnknownDefaultPort)
			{
				this._port = this._defaultPorts[this._scheme];
			}

			if (string.IsNullOrWhiteSpace(workingUrl))
			{
				throw new UriFormatException("invalid url format: missing hostname");
			}

			// test 2: "@" means there is a username, and possibly a username:password combination.
			urlParts = workingUrl.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
			if (urlParts.Length > 1)
			{
				string userpass = urlParts[0];
				string[] userpassParts = userpass.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
				if (userpassParts.Length > 2)
				{
					throw new UriFormatException("invalid url format: too many entries for username:password portion");
				}
				this._user = userpassParts[0];
				if (userpassParts.Length > 1 && userpassParts[1].Length > 0)
				{
					this._password = userpassParts[1];
				}
				workingUrl = workingUrl.Length == urlParts[0].Length + 1 ? string.Empty : workingUrl.Substring(urlParts[0].Length + 1);
			}

			if (string.IsNullOrWhiteSpace(workingUrl))
			{
				throw new UriFormatException("invalid url format: missing hostname");
			}

			// test 3: host (or server) part
			urlParts = workingUrl.Split(new string[] { ":", "/", "?", "#" }, StringSplitOptions.None);
			if (urlParts[0].Length > 0)
			{
				this._host = urlParts[0];
				workingUrl = workingUrl.Length == urlParts[0].Length ? string.Empty : workingUrl.Substring(urlParts[0].Length);
			}
			else
			{
				throw new UriFormatException("invalid url format: missing hostname");
			}

			if (!string.IsNullOrWhiteSpace(workingUrl))
			{
				// test 3: a colon indicates a port number, 0 <= x <= 65535
				urlParts = workingUrl.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
				if (urlParts.Length > 1 || urlParts[0] != workingUrl)
				{
					string[] portParts = urlParts[0].Split(new string[] { "/", "?", "#" }, StringSplitOptions.None);
					try
					{
						this._portRaw = portParts[0];
						this._port = int.Parse(System.Web.HttpUtility.UrlDecode(this._portRaw));
					}
					catch
					{
						throw new UriFormatException("invalid url format: port number is not an integer");
					}
					workingUrl = workingUrl.Length == portParts[0].Length + 1 ? string.Empty : workingUrl.Substring(portParts[0].Length + 1);
					if (!UnknownDefaultPort)
					{
						UnknownDefaultPort = _defaultPorts[this._scheme] != this._port;
					}
				}
			}
			if (this._port <= 0 || this._port >= 65536)
			{
				if (this._port == -1 && UnknownDefaultPort)
				{
					throw new UriFormatException("Invalid url format: no default port number is registered for this scheme. Must be provided explicitly.");
				}
				throw new UriFormatException("invalid url format: port number not in range (1 <= port <= 65535)");
			}

			// test 4: path, query and fragment.
			// path is up until the next ? or #, or end-of-line if not present.
			if (!string.IsNullOrWhiteSpace(workingUrl))
			{
				int queryMarker = workingUrl.IndexOf("?", StringComparison.CurrentCultureIgnoreCase);
				int fragmentMarker = workingUrl.IndexOf("#", StringComparison.CurrentCultureIgnoreCase);
				if (fragmentMarker >= 0 && fragmentMarker < queryMarker)
				{
					throw new UriFormatException("invalid url format: fragment section appears before query section. Is something not URL-encoded.");
				}
				if (queryMarker == -1 && fragmentMarker == -1)
				{
					this._path = workingUrl;
					workingUrl = string.Empty;
				}
				if (queryMarker >= 0)
				{
					this._path = workingUrl.Substring(0, queryMarker);
					if (fragmentMarker >= 0)
					{
						this._query = workingUrl.Substring(queryMarker + 1, (fragmentMarker - queryMarker) - 1);
						workingUrl = workingUrl.Substring(fragmentMarker);
						fragmentMarker = 0;
					}
					else
					{
						this._query = workingUrl;
						workingUrl = string.Empty;
					}
				}
				if (fragmentMarker >= 0)
				{
					if (string.IsNullOrEmpty(this._path))
					{
						this._path = workingUrl.Substring(0, fragmentMarker);
					}
					this._fragment = workingUrl.Length - 1 == fragmentMarker ? string.Empty : workingUrl.Substring(fragmentMarker + 1);
					workingUrl = string.Empty;
				}
			}
		}

		/// <summary>
		/// ToString()
		/// </summary>
		/// <returns>Reconstructs a url string from the parts of the Url, with proper encoding where needed.</returns>
		public override string ToString()
		{
			string result = 
				System.Web.HttpUtility.UrlEncode(Scheme) + "://" +
				System.Web.HttpUtility.UrlEncode(User) +
				(this._password.Length > 0 ? ":" + System.Web.HttpUtility.UrlEncode(Password) : string.Empty) +
				((this._user.Length + this._password.Length) > 0 ? "@" : string.Empty) +
				(this._host.Length > 0 ? System.Web.HttpUtility.UrlEncode(Host) : string.Empty) +
				(this.PortExplicit.Length > 0 ? ":" + this.Port.ToString() : string.Empty) +
				(this._path.Length > 0 ? this._path : string.Empty) +
				(this._query.Length > 0 ? "?" + this._query : string.Empty) +
				(this._fragment.Length > 0 ? "#" + this._fragment : string.Empty);
			return result;
		}

		/// <summary>
		/// Get the Raw value of a specific part of the Url, before an decoding was done.
		/// </summary>
		/// <param name="part"></param>
		/// <returns></returns>
		public string GetRaw(UrlPart part)
		{
			string result = string.Empty;
			switch (part)
			{
				case UrlPart.Scheme:
					result = this._scheme;
					break;
				case UrlPart.User:
					result = this._user;
					break;
				case UrlPart.Password:
					result = this._password;
					break;
				case UrlPart.Host:
					result = this._host;
					break;
				case UrlPart.Port:
					result = this._port.ToString();
					break;
				case UrlPart.PortExplicit:
					result = this._portRaw;
					break;
				case UrlPart.Path:
					result = this._path;
					break;
				case UrlPart.Query:
					result = this._query;
					break;
				case UrlPart.Fragment:
					result = this._fragment;
					break;
				default:
					break;
			}

			return result;
		}
	}
}
