using NUnit.Framework;

namespace DisposableMail.Tests
{
    [TestFixture]
    class Check_Email
    {        
        [Test]
        public void Test_FirstMail_MetaData()
        {
            
            Assert.AreEqual("Welcome to Guerrilla Mail", SetUp.FirstMail.MailSubject);
            Assert.AreEqual("no-reply@guerrillamail.com", SetUp.FirstMail.MailFrom);
        }
    }
}
