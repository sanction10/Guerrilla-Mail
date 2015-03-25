using System;
using NUnit.Framework;

namespace DisposableMail.Tests
{
	[TestFixture]
	public class SendEmail
	{
		[Test]
		public void Test_SendEmail_Success()
		{
			var valid = SetUp.Mail.SendEmail (SetUp.Mail.Email, "Testing Email", "Testing 1\rTesting 2");
			Assert.True (valid);
		}
	}
}

