using NUnit.Framework;
using System;

namespace DisposableMail.Tests
{
    [TestFixture]
    public class Get_Email_Address
    {
        [Test]
        public void Test_EmailAddress_Equal()
        {
            var email1 = SetUp.Mail.GetEmailAddress().EmailAddress;
            var email2 = SetUp.Mail.GetEmailAddress().EmailAddress;
            Assert.AreEqual(email1, email2);
        }

        [Test]
        public void Test_EmailAddress_NotEmpty()
        {
            Assert.IsNotNullOrEmpty(SetUp.Mail.GetEmailAddress().EmailAddress);
        }

        [Test]
        public void Test_Alias_NotEmpty()
        {
            Assert.IsNotNullOrEmpty(SetUp.Mail.GetEmailAddress().Alias);
        }

        [Test]
        public void Test_Timestamp_Correct()
        {
            var serverTimestamp = SetUp.Mail.GetEmailAddress().Timestamp;
            var localTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            // Need to remove 3 digits from the end as the difference is very less and causes the test to fail.
            Assert.AreEqual(serverTimestamp.Remove(7), localTimestamp.ToString().Remove(7));
        }
    }
}
