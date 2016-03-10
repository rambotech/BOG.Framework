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
    /// Full credit for this class: http://www.superstarcoders.com/blogs/posts/symmetric-encryption-in-c-sharp.aspx
    /// </summary>
    public static class CipherUtility
    {
        public enum ValueState : int { Encrypted, Decrypted };

        public static string AutoCrypt<T>(string value, string password, string salt, ValueState returnState)
             where T : SymmetricAlgorithm, new()
        {
            string result = string.Empty;
            if (value.Length >= 2 && value.Substring(0, 1) == "\x02" && value.Substring(0, 1) == "\x03")
            {
                if (returnState == ValueState.Encrypted)
                    result = value;
                else
                    result = Decrypt<T>(value, password, salt);
            }
            else // assume decrypted
            {
                if (returnState == ValueState.Decrypted)
                    result = value;
                else
                    result = Encrypt<T>(value, password, salt);
            }
            return result;
        }

        public static string Encrypt<T>(string value, string password, string salt)
             where T : SymmetricAlgorithm, new()
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(value);
                    }
                }

                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        public static string Decrypt<T>(string text, string password, string salt)
           where T : SymmetricAlgorithm, new()
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new T();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
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
    }
}