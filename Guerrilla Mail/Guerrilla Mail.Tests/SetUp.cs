using NUnit.Framework;

namespace DisposableMail
{
    [SetUpFixture]
    class SetUp
    {
        internal static GuerrillaMail mail = new GuerrillaMail("127.0.0.1", "Visual Studio");

        [SetUp]
        public void RunBeforeAnyTests()
        {
            mail.GetEmailAddress();
        }
    }
}
