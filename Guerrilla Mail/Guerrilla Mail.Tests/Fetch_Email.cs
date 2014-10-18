using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DisposableMail.Tests
{
    [TestFixture]
    class Fetch_Email
    {
        [Test]
        public void Test_FirstMail_Contents()
        {
            var body = SetUp.Mail.FetchEmail(SetUp.FirstMail.MailID).mail_body;
            body.Contains("Thank you for using Guerrilla Mail - your temporary email address friend and spam fighter's ally!");
        }
    }
}
