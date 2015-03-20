using System;
using NUnit.Framework;

namespace DisposableMail.Tests
{
	[TestFixture]
	public class Set_Email_Address
	{
		[Test]
		public void Test_SetEmailAddress_Equal()
		{
			var email1 = SetUp.Mail.SetEmailUser("testing").EmailAddress;
			var email2 = SetUp.Mail.GetEmailAddress().Address;
			Assert.AreEqual(email1, email2);
		}
	}
}

