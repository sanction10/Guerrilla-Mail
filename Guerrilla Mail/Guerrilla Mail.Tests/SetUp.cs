using NUnit.Framework;

namespace DisposableMail.Tests
{
    [SetUpFixture]
    class SetUp
    {
        public static GuerrillaMail Mail = new GuerrillaMail();
        public static Email FirstMail;
        [SetUp]
        public void RunBeforeAnyTests()
        {
            Mail.GetEmailAddress();
            FirstMail = Mail.CheckEmail().MailList[0];
        }
    }
}
