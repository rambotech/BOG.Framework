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
	public class SecuredGramTest
	{
		const string ValidCharacters =
			"0123456789ABCDEFGHIJKLMNOPQURSTUVWXYZabcdefghijklmnopqurstuvwxyz" +
			"\"':;<,>./?{[}]=+-_\\!@#$%^&*()";

		const string ShortTest = "The slow brown cow jumped over the moon with Elon Musk's help.";

		[Test, Description("doesShortTestWithDefaultEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
		public void doesShortTestWithDefaultEncryptionMethodReturnCorrectValue()
		{
			string key = RandomString();
			string salt = RandomString();

			SecureGram g = new SecureGram();
			g.Sender = "Pinnochio";
			g.Subject = "Marionette";
			g.Message = ShortTest;
			string encrypted = g.CreateGramContent(key, salt);
			SecureGram decrypted = new SecureGram();
			decrypted.LoadFromReceivedMessage(encrypted, key, salt);
			Assert.AreEqual(decrypted.Message, ShortTest);
			Assert.AreEqual(decrypted.Message.Length, ShortTest.Length);
			Assert.AreEqual(decrypted.Subject, g.Subject);
			Assert.AreEqual(decrypted.Sender, g.Sender);
			Assert.IsFalse(g.IsCompressed);
		}

		[Test, Description("doesLargeTestWithDefaultEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
		public void doesLargeTestWithDefaultEncryptionMethodReturnCorrectValue()
		{
			string key = RandomString();
			string salt = RandomString();

			SecureGram g = new SecureGram();
			g.Sender = "Pinnochio";
			g.Subject = "Marionette";
			g.Message = MakeLargeTest();
			string encrypted = g.CreateGramContent(key, salt);
			SecureGram decrypted = new SecureGram();
			decrypted.LoadFromReceivedMessage(encrypted, key, salt);
			Assert.AreEqual(decrypted.Message, g.Message);
			Assert.AreEqual(decrypted.Message.Length, g.Message.Length);
			Assert.AreEqual(decrypted.Subject, g.Subject);
			Assert.AreEqual(decrypted.Sender, g.Sender);
			Assert.IsFalse(g.IsCompressed);
		}

		[Test, Description("doesShortTestWithSpecificEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
		public void doesShortTestWithSpecificEncryptionMethodReturnCorrectValue()
		{
			string key = RandomString();
			string salt = RandomString();

			SecureGram g = new SecureGram();
			g.Sender = "Pinnochio";
			g.Subject = "Marionette";
			g.Message = ShortTest;
			string encrypted = g.CreateGramContent<RijndaelManaged>(key, salt);
			SecureGram decrypted = new SecureGram();
			decrypted.LoadFromReceivedMessage<RijndaelManaged>(encrypted, key, salt);
			Assert.AreEqual(decrypted.Message, ShortTest);
			Assert.AreEqual(decrypted.Message.Length, ShortTest.Length);
			Assert.AreEqual(decrypted.Subject, g.Subject);
			Assert.AreEqual(decrypted.Sender, g.Sender);
			Assert.IsFalse(g.IsCompressed);
		}

		[Test, Description("doesLargeTestWithSpecificEncryptionMethodReturnCorrectValue(): basic encryption / decryption validation with default method")]
		public void doesLargeTestWithSpecificEncryptionMethodReturnCorrectValue()
		{
			string key = RandomString();
			string salt = RandomString();

			SecureGram g = new SecureGram();
			g.Sender = "Pinnochio";
			g.Subject = "Marionette";
			g.Message = MakeLargeTest();
			string encrypted = g.CreateGramContent<RijndaelManaged>(key, salt);
			SecureGram decrypted = new SecureGram();
			decrypted.LoadFromReceivedMessage<RijndaelManaged>(encrypted, key, salt);
			Assert.AreEqual(decrypted.Message, g.Message);
			Assert.AreEqual(decrypted.Message.Length, g.Message.Length);
			Assert.AreEqual(decrypted.Subject, g.Subject);
			Assert.AreEqual(decrypted.Sender, g.Sender);
			Assert.IsFalse(g.IsCompressed);
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
