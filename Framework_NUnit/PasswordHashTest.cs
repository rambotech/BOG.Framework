using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOG.Framework;
using NUnit.Framework;

namespace BOG.Framework_NUnit
{
	[TestFixture]
	public class PasswordHashTest
	{
		string password1 = "NehemiahTurm$41c&";
		string password2 = "The quick brown fox jumped over the lazy dog's back again... lazy mutt!";
		string password3 = "";
		string hash1 = "";
		string hash2 = "";
		string hash3 = "";

		[Test, Description("Password 1 valid hash")]
		public void PasswordHash_Password1Valid()
		{
			hash1 = PasswordHash.CreateHash(password1);
			Assert.That(PasswordHash.ValidatePassword(password1, hash1));
		}

		[Test, Description("Password 2 valid hash")]
		public void PasswordHash_Password2Valid()
		{
			hash2 = PasswordHash.CreateHash(password2);
			Assert.That(PasswordHash.ValidatePassword(password2, hash2));
		}

		[Test, Description("Password 3 valid hash")]
		public void PasswordHash_Password3Valid()
		{
			hash3 = PasswordHash.CreateHash(password3);
			Assert.That(PasswordHash.ValidatePassword(password3, hash3));
		}
	}
}
