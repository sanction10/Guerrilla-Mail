using DisposableMail.Functions;
using NUnit.Framework;

namespace DisposableMail.Tests
{
    [SetUpFixture]
    class SetUp
    {
        public static GuerrillaMail Mail = new GuerrillaMail("127.0.0.1", "Visual Studio");
        public static Mail FirstMail;
        [SetUp]
        public void RunBeforeAnyTests()
        {
            Mail.GetEmailAddress();
            FirstMail = Mail.CheckEmail(0).MailList[0];
        }
    }
}
