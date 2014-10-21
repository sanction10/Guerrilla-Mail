using NUnit.Framework;

namespace DisposableMail.Tests
{
    [TestFixture]
    class Fetch_Email
    {
        [Test]
        public void Test_FirstMail_Contents()
        {
            var body = SetUp.Mail.FetchEmail(SetUp.FirstMail.MailID).MailBody;
            body.Contains("Thank you for using Guerrilla Mail - your temporary email address friend and spam fighter's ally!");
        }
    }
}
