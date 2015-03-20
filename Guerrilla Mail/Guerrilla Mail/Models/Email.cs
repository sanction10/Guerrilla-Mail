using System;
using RestSharp.Deserializers;
using System.Collections.Generic;
using RestSharp;

namespace DisposableMail
{
    public class Email
    {
        [DeserializeAs(Name = "mail_from")]
        public string MailFrom { get; set; }

        [DeserializeAs(Name = "mail_timestamp")]
        public int MailTimestamp { get; set; }

        [DeserializeAs(Name = "mail_read")]
        public int MailRead { get; set; }

        [DeserializeAs(Name = "mail_date")]
        public string MailDate { get; set; }

        [DeserializeAs(Name = "reply_to")]
        public string ReplyTo { get; set; }

        [DeserializeAs(Name = "mail_subject")]
        public string MailSubject { get; set; }

        [DeserializeAs(Name = "mail_excerpt")]
        public string MailExcerpt { get; set; }

        [DeserializeAs(Name = "mail_id")]
        public int MailId { get; set; }

        [DeserializeAs(Name = "att")]
        public int AttachmentsCount { get; set; }

		[DeserializeAs(Name = "att_info")]
		public List<AttachmentInfo> Attachments {get;set;}

        [DeserializeAs(Name = "content_type")]
        public string ContentType { get; set; }

        [DeserializeAs(Name = "mail_recipient")]
        public string MailRecipient { get; set; }

        [DeserializeAs(Name = "source_id")]
        public int SourceId { get; set; }

        [DeserializeAs(Name = "source_mail_id")]
        public int SourceMailId { get; set; }

        [DeserializeAs(Name = "mail_body")]
        public String MailBody { get; set; }

        [DeserializeAs(Name = "ref_mid")]
        public string RefMid { get; set; }

        [DeserializeAs(Name = "sid_token")]
        public string SessionID { get; set; }

        [DeserializeAs(Name = "auth")]
        public Auth Authentication { get; set; }
    }

	public class AttachmentInfo 
	{
		//"att_info":[{"t":"image\/png","f":"Woman-Listening.png","p":"1.2"}]
		[DeserializeAs(Name = "t")]
		public string Type { get; set; }

		[DeserializeAs(Name = "f")]
		public string FileName { get; set; }

		[DeserializeAs(Name = "p")]
		public string Part { get; set; }
	}
}
