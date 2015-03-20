using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace DisposableMail
{   
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
        public List<object> ErrorCodes { get; set; }
    }

    public class Inbox
    {
        [DeserializeAs(Name = "list")]
        public List<Email> MailList { get; set; }

        [DeserializeAs(Name = "count")]
        public String Count { get; set; }

        [DeserializeAs(Name = "email")]
        public String Email { get; set; }

        [DeserializeAs(Name = "alias")]
        public String Alias { get; set; }

        [DeserializeAs(Name = "ts")]
        public int TS { get; set; }

        [DeserializeAs(Name = "sid_token")]
        public string SessionID { get; set; }

        [DeserializeAs(Name = "stats")]
        public Stats Statistics { get; set; }

        [DeserializeAs(Name = "auth")]
        public Auth Authentication { get; set; }
    }
}
