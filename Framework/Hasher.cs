using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework
{
	/// <summary>
	/// Methods for generating a hash value from file content or string content.
	/// </summary>
	public class Hasher
	{
		/// <summary>
		/// The hash method to use
		/// </summary>
		public enum HashMethod : int {
			/// <summary>
			/// SHA1
			/// </summary>
			SHA1,
			/// <summary>
			/// SHA256
			/// </summary>
			SHA256,
			/// <summary>
			/// SHA384
			/// </summary>
			SHA384,
			/// <summary>
			/// SHA512
			/// </summary>
			SHA512,
			/// <summary>
			/// MD5
			/// </summary>
			MD5,
			/// <summary>
			/// RIPEMD
			/// </summary>
			RIPEMD
		}

		private static string ByteArrayToHex(byte[] value)
		{
			string result = string.Empty;
			foreach (byte x in value)
			{
				result += String.Format("{0:x2}", x);
			}
			return result;
		}

		/// <summary>
		/// Create a hash value from a file's content.
		/// </summary>
		/// <param name="filename">The file to hash</param>
		/// <param name="encoding">The encoding of the file content</param>
		/// <param name="method">The HashMethod enumeration for the evaluation</param>
		/// <returns>A hex-encoded value of the hash value</returns>
		public static string GetHashFromFileContent(string filename, Encoding encoding, HashMethod method)
		{
			return GetHash(encoding.GetBytes(File.ReadAllText(filename)), method);
		}

		/// <summary>
		/// Create a hash value from a string's content.
		/// </summary>
		/// <param name="content">the literal content to evaluate for the hash.</param>
		/// <param name="encoding">The encoding of the file content</param>
		/// <param name="method">The HashMethod enumeration for the evaluation</param>
		/// <returns>A hex-encoded value of the hash value</returns>
		public static string GetHashFromStringContent(string content, Encoding encoding, HashMethod method)
		{
			return GetHash(encoding.GetBytes(content), method);
		}

		private static string GetHash(byte[] content, HashMethod method)
		{
			HashAlgorithm hashString = new SHA1Managed();
			switch (method)
			{
				case HashMethod.SHA1:
					break;
				case HashMethod.SHA256:
					hashString = new SHA256Managed();
					break;
				case HashMethod.SHA384:
					hashString = new SHA384Managed();
					break;
				case HashMethod.SHA512:
					hashString = new SHA512Managed();
					break;
				case HashMethod.MD5:
					hashString = new MD5CryptoServiceProvider();
					break;
				case HashMethod.RIPEMD:
					hashString = new RIPEMD160Managed();
					break;
			}
			return ByteArrayToHex(hashString.ComputeHash(content));
		}
	}
}
