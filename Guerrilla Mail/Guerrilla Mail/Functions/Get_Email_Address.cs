using RestSharp.Deserializers;
using System;

namespace DisposableMail.Functions
{
    /// <summary>
    /// https://api.guerrillamail.com/ajax.php?f=get_email_address&ip=127.0.0.1&agent=Mozilla_foo_bar
    /// {"email_addr":"tnyjsrkr@guerrillamailblock.com","email_timestamp":1413289742,"alias":"sis9m+8wjsdfudnaobw","sid_token":"n02s2jtdgnlqlceicbde09reh6"}
    /// </summary>
    public class Get_Email_Address
    {
        /// <summary>
        /// The email address that that was determined. If a previous session was found, then it will be the email address of that session else a new random email address will 
        /// be created.
        /// </summary>
        [DeserializeAs(Name = "email_addr")]
        public String EmailAddress { get; set; }

        /// <summary>
        /// A UNIX timestamp when the email address was created. Used by the client to keep track of expiry.
        /// </summary>
        [DeserializeAs(Name = "email_timestamp")]
        public String Timestamp { get; set; }

        /// <summary>
        /// This is the scrambled version of email_addr, eg “fcs5d3+vgdtknvsyt4”. The scrambled address is an alias for email_addr, so all email going to alias will arrive at 
        /// the inbox of email_addr. Scrambled addresses are used to mask the email_addr, so it is difficult for someone else to know which email_addr was used.
        /// </summary>
        [DeserializeAs(Name = "alias")]
        public String Alias { get; set; }

        /// <summary>
        /// Session Token
        /// </summary>
        [DeserializeAs(Name = "sid_token")]
        public String SessionID { get; set; }
    }
}
