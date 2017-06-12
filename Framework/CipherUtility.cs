using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BOG.Framework
{
	using System;
	using System.Text;
	using System.Security.Cryptography;
	using System.IO;

	/// <summary>
	/// Drived from: http://www.superstarcoders.com/blogs/posts/symmetric-encryption-in-c-sharp.aspx
	/// </summary>
	public class CipherUtility
	{
		SymmetricAlgorithm CryptoAlgorithm = null;

		/// <summary>
		/// Use the default encryption provider.
		/// </summary>
		public CipherUtility()
		{
			this.CryptoAlgorithm = new AesManaged();
		}

		/// <summary>
		/// Use a specific encryption provider which inherits from base class SymmetricAlgorithm.
		/// </summary>
		public CipherUtility(SymmetricAlgorithm cryptoAlgorithm)
		{
			this.CryptoAlgorithm = cryptoAlgorithm;
		}

		/// <summary>
		/// Encrypt a given string using specific password and salt values
		/// </summary>
		/// <param name="value">string to encrypt</param>
		/// <param name="password"></param>
		/// <param name="salt"></param>
		/// <param name="base64Options">whether or not line breaks are added to the resulting Base64 result.</param>
		/// <returns>string containing protected content</returns>
		public string Encrypt(string value, string password, string salt, Base64FormattingOptions base64Options)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}

			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("password can not be blank");
			}
			if (string.IsNullOrEmpty(salt))
			{
				throw new ArgumentException("salt can not be blank");
			}

			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

			byte[] rgbKey = rgb.GetBytes(this.CryptoAlgorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(this.CryptoAlgorithm.BlockSize >> 3);

			ICryptoTransform transform = this.CryptoAlgorithm.CreateEncryptor(rgbKey, rgbIV);

			using (MemoryStream buffer = new MemoryStream())
			{
				using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
				{
					using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
					{
						writer.Write(value);
					}
				}
				return Convert.ToBase64String(buffer.ToArray(), base64Options);
			}
		}

		/// <summary>
		/// Decrypt a given protected string using specific password and salt values
		/// </summary>
		/// <param name="protectedValue">protected string to decrypt</param>
		/// <param name="password"></param>
		/// <param name="salt"></param>
		/// <returns>string with original content</returns>
		public string Decrypt(string protectedValue, string password, string salt)
		{
			if (string.IsNullOrEmpty(protectedValue))
				return string.Empty;

			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

			byte[] rgbKey = rgb.GetBytes(this.CryptoAlgorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(this.CryptoAlgorithm.BlockSize >> 3);

			ICryptoTransform transform = this.CryptoAlgorithm.CreateDecryptor(rgbKey, rgbIV);

			using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(protectedValue)))
			{
				using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
				{
					using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
					{
						return reader.ReadToEnd();
					}
				}
			}
		}

		/// <summary>
		/// Encrypt a given byte[] array conent using specific password and salt values
		/// </summary>
		/// <param name="value">byte array to encrypt</param>
		/// <param name="password"></param>
		/// <param name="salt"></param>
		/// <param name="base64Options"></param>
		/// <returns>Base64 encoded string containing protected content</returns>
		public string EncryptByteArray(byte[] value, string password, string salt, Base64FormattingOptions base64Options)
		{
			if (value.Length == 0)
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(password))
			{
				throw new ArgumentException("password can not be blank");
			}
			if (string.IsNullOrEmpty(salt))
			{
				throw new ArgumentException("salt can not be blank");
			}

			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

			byte[] rgbKey = rgb.GetBytes(this.CryptoAlgorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(this.CryptoAlgorithm.BlockSize >> 3);

			ICryptoTransform transform = this.CryptoAlgorithm.CreateEncryptor(rgbKey, rgbIV);

			using (MemoryStream buffer = new MemoryStream())
			{
				using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
				{
					stream.Write(value, 0, value.Length);
				}
				return Convert.ToBase64String(buffer.ToArray(), base64Options);
			}
		}

		/// <summary>
		/// Decrypt a given Base64 encoded protected byte array using specific password and salt values
		/// </summary>
		/// <param name="protectedValue">Base64 encoded string with encrypted content</param>
		/// <param name="password"></param>
		/// <param name="salt"></param>
		/// <returns>byte[] with unprotected content</returns>
		public byte[] DecryptByteArray(string protectedValue, string password, string salt)
		{
			if (protectedValue.Length == 0)
			{
				return new byte[] { };
			}

			DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

			byte[] rgbKey = rgb.GetBytes(this.CryptoAlgorithm.KeySize >> 3);
			byte[] rgbIV = rgb.GetBytes(this.CryptoAlgorithm.BlockSize >> 3);

			ICryptoTransform transform = this.CryptoAlgorithm.CreateDecryptor(rgbKey, rgbIV);
			using (MemoryStream sourceBuffer = new MemoryStream(Convert.FromBase64String(protectedValue)))
			{
				using (CryptoStream stream = new CryptoStream(sourceBuffer, transform, CryptoStreamMode.Read))
				{
					const int size = 4096;
					byte[] buffer = new byte[size];
					using (MemoryStream memory = new MemoryStream())
					{
						int count = -1;
						while (count != 0)
						{
							count = stream.Read(buffer, 0, size);
							if (count > 0)
							{
								memory.Write(buffer, 0, count);
							}
						}
						return memory.ToArray();
					}
				}
			}
		}
	}
}