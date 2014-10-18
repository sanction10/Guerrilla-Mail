using NUnit.Framework;

namespace DisposableMail
{
    [TestFixture]
    class Check_Email
    {        
        [Test]
        public void Test_FirstMail_MetaData()
        {
            var firstMail = SetUp.mail.CheckEmail(0).MailList[0];
            Assert.AreEqual("Welcome to Guerrilla Mail", firstMail.MailSubject);
            Assert.AreEqual("no-reply@guerrillamail.com", firstMail.MailFrom);
        }
    }
}
