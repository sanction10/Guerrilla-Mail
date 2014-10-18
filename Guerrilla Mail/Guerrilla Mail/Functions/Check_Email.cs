﻿using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuerrillaMail.Functions
{
    public class Check_Email
    {
        [DeserializeAs(Name = "list")]
        public List<Mail> MailList { get; set; }

        [DeserializeAs(Name = "count")]
        public String Count { get; set; }

        [DeserializeAs(Name = "email")]
        public String Email { get; set; }

        [DeserializeAs(Name = "alias")]
        public String Alias { get; set; }

        [DeserializeAs(Name = "ts")]
        public int Ts { get; set; }

        [DeserializeAs(Name = "sid_token")]
        public string SessionID { get; set; }

        [DeserializeAs(Name = "stats")]
        public Stats Statistics { get; set; }

        [DeserializeAs(Name = "auth")]
        public Auth Authentication { get; set; }

        public class Mail
        {

            [DeserializeAs(Name = "mail_id")]
            public object MailID { get; set; }

            [DeserializeAs(Name = "mail_from")]
            public string MailFrom { get; set; }

            [DeserializeAs(Name = "mail_subject")]
            public string MailSubject { get; set; }

            [DeserializeAs(Name = "mail_excerpt")]
            public string MailExcerpt { get; set; }

            [DeserializeAs(Name = "mail_timestamp")]
            public object MailTimestamp { get; set; }

            [DeserializeAs(Name = "mail_read")]
            public object MailRead { get; set; }

            [DeserializeAs(Name = "mail_date")]
            public string MailDate { get; set; }

            [DeserializeAs(Name = "att")]
            public object Att { get; set; }

            [DeserializeAs(Name = "reply_to")]
            public string ReplyTo { get; set; }

            [DeserializeAs(Name = "content_type")]
            public string ContentType { get; set; }

            [DeserializeAs(Name = "mail_recipient")]
            public string MailRecipient { get; set; }

            [DeserializeAs(Name = "source_id")]
            public int? SourceId { get; set; }

            [DeserializeAs(Name = "source_mail_id")]
            public int? SourceMailId { get; set; }
        }

        public class Stats
        {

            [DeserializeAs(Name = "sequence_mail")]
            public string SequenceMail { get; set; }

            [DeserializeAs(Name = "created_addresses")]
            public int CreatedAddresses { get; set; }

            [DeserializeAs(Name = "received_emails")]
            public string ReceivedEmails { get; set; }

            [DeserializeAs(Name = "total")]
            public string Total { get; set; }

            [DeserializeAs(Name = "total_per_hour")]
            public string TotalPerHour { get; set; }
        }

        public class Auth
        {
            [DeserializeAs(Name = "success")]
            public bool Success { get; set; }

            [DeserializeAs(Name = "error_codes")]
            public object[] ErrorCodes { get; set; }
        }
    }
}