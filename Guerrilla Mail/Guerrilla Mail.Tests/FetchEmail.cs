using NUnit.Framework;

namespace DisposableMail.Tests
{
    [TestFixture]
    class Fetch_Email
    {
        [Test]
        public void Test_FirstMail_Contents()
        {
            var body = SetUp.Mail.FetchEmail(SetUp.FirstMail.MailId).MailBody;
            body.Contains("Thank you for using Guerrilla Mail - your temporary email address friend and spam fighter's ally!");
        }

		[Test]
		public void Test_FirstMail_ShowingImages()
		{
			SetUp.Mail.SetEmailUser ("testing@");
			var body = SetUp.Mail.FetchEmail (SetUp.Mail.CheckEmail ().MailList [0].MailId, true).MailBody;
		}

		[Test]
		public void Test_FirstMail_ShowOriginal()
		{
			var email = SetUp.Mail.FetchEmail(SetUp.FirstMail.MailId);
			var source = SetUp.Mail.ShowOriginal (email.MailId);
			Assert.AreNotEqual (source, "Sorry, email not found. Perhaps it was deleted or not sent via smtp (eg. welcome email)");
		}

		[Test]
		public void Test_FirstMail_GetAttachment()
		{
			SetUp.Mail.SetEmailUser ("testing@");
			var email = SetUp.Mail.FetchEmail(SetUp.Mail.CheckEmail ().MailList [0].MailId);
			byte[] attachment = null;

			if (email.AttachmentsCount > 0) {
				attachment = SetUp.Mail.DownloadAttachment (email.MailId, email.Attachments [0].Part);
			}

			Assert.NotNull (attachment);
		}
    }
}
