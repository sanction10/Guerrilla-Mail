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
			SetUp.Mail.SendEmail (SetUp.Mail.Email, "Testing Email", "Testing 1\rTesting 2");
		}
	}
}

