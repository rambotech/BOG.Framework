using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BOG.Framework;
using BOG.Framework.Extensions;
using NUnit.Framework;

namespace BOG.Framework_NUnit
{
    [TestFixture]
    public class SecureGramTest
    {
        const string ValidCharacters =
            "0123456789ABCDEFGHIJKLMNOPQURSTUVWXYZabcdefghijklmnopqurstuvwxyz" +
            "\"':;<,>./?{[}]=+-_\\!@#$%^&*()";

        const string ShortTest = "The slow brown cow jumped over the moon with Elon Musk's help.";

        [Test, Description("SecureGram_ShortTestWithDefaultEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
        public void SecureGram_ShortTestWithDefaultEncryptionMethodReturnCorrectValue()
        {
            string key = RandomString();
            string salt = RandomString();

            SecureGram g = new SecureGram();
            g.Sender = "Pinnochio";
            g.Subject = "Marionette";
            g.Message = ShortTest;
            string encrypted = g.CreateGramContent(key, salt);
            SecureGram decrypted = new SecureGram();
            decrypted.LoadGramContent(encrypted, key, salt);
            Assert.That(string.Compare(decrypted.Message, ShortTest, false) == 0);
            Assert.That(decrypted.Message.Length == ShortTest.Length);
            Assert.That(encrypted.Length > g.Message.Length);
            Assert.That(!decrypted.IsCompressed);
            Assert.That(string.Compare(decrypted.Subject, g.Subject, false) == 0);
            Assert.That(string.Compare(decrypted.Sender, g.Sender, false) == 0);
            Assert.That(!g.IsCompressed);
        }

        [Test, Description("SecureGram_LargeTestWithDefaultEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
        public void SecureGram_LargeTestWithDefaultEncryptionMethodReturnCorrectValue()
        {
            string key = RandomString();
            string salt = RandomString();

            SecureGram g = new SecureGram();
            g.Sender = "Pinnochio";
            g.Subject = "Marionette";
            g.Message = MakeLargeTest();
            string encrypted = g.CreateGramContent(key, salt);
            SecureGram decrypted = new SecureGram();
            decrypted.LoadGramContent(encrypted, key, salt);
            Assert.That(string.Compare(decrypted.Message, g.Message, false) == 0);
            Assert.That(decrypted.Message.Length == g.Message.Length);
            Assert.That(encrypted.Length < g.Message.Length);
            Assert.That(decrypted.IsCompressed);
            Assert.That(string.Compare(decrypted.Subject, g.Subject, false) == 0);
            Assert.That(string.Compare(decrypted.Sender, g.Sender, false) == 0);
            Assert.That(!g.IsCompressed);
        }

        [Test, Description("SecureGram_ShortTestWithSpecificEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
        public void SecureGram_ShortTestWithSpecificEncryptionMethodReturnCorrectValue()
        {
            string key = RandomString();
            string salt = RandomString();

            SecureGram g = new SecureGram();
            g.Sender = "Pinnochio";
            g.Subject = "Marionette";
            g.Message = ShortTest;
            string encrypted = g.CreateGramContent<RijndaelManaged>(key, salt);
            SecureGram decrypted = new SecureGram();
            decrypted.LoadGramContent<RijndaelManaged>(encrypted, key, salt);
            Assert.That(string.Compare(decrypted.Message, ShortTest, false) == 0);
            Assert.That(decrypted.Message.Length == ShortTest.Length);
            Assert.That(encrypted.Length > g.Message.Length);
            Assert.That(!decrypted.IsCompressed);
            Assert.That(string.Compare(decrypted.Subject, g.Subject, false) == 0);
            Assert.That(string.Compare(decrypted.Sender, g.Sender, false) == 0);
            Assert.That(!g.IsCompressed);
        }

        [Test, Description("SecureGram_LargeTestWithSpecificEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
        public void SecureGram_LargeTestWithSpecificEncryptionMethodReturnCorrectValue()
        {
            string key = RandomString();
            string salt = RandomString();

            SecureGram g = new SecureGram();
            g.Sender = "Pinnochio";
            g.Subject = "Marionette";
            g.Message = MakeLargeTest();
            string encrypted = g.CreateGramContent<RijndaelManaged>(key, salt);
            SecureGram decrypted = new SecureGram();
            decrypted.LoadGramContent<RijndaelManaged>(encrypted, key, salt);
            Assert.That(string.Compare(decrypted.Message, g.Message, false) == 0);
            Assert.That(decrypted.Message.Length == g.Message.Length);
            Assert.That(encrypted.Length < g.Message.Length);
            Assert.That(decrypted.IsCompressed);
            Assert.That(string.Compare(decrypted.Subject, g.Subject, false) == 0);
            Assert.That(string.Compare(decrypted.Sender, g.Sender, false) == 0);
            Assert.That(!g.IsCompressed);
        }

        #region Helper methods
        private string MakeLargeTest()
        {
            StringBuilder result = new StringBuilder();
            while (result.Length < 10000)
            {
                result.AppendLine(ShortTest);
            }
            return result.ToString();
        }

        private string RandomString()
        {
            StringBuilder result = new StringBuilder();
            DateTime now = DateTime.Now;
            Random r = new Random(
                now.Millisecond + now.Second * 1000 + now.Minute * 60000 + now.Hour * 3600000
                + (now.DayOfYear % 25) * 86400000);
            int length = r.Next(18, 50);
            for (int index = 0; index < length; index++)
                result.Append(ValidCharacters.Substring(r.Next(ValidCharacters.Length), 1));
            return result.ToString();
        }
        #endregion
    }
}
