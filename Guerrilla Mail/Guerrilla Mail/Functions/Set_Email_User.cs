using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuerrillaMail.Functions
{
    /// <summary>
    /// {"alias_error":"","alias":"sivfd+p9dy2hc","email_addr":"test@guerrillamailblock.com","email_timestamp":1413294259,"site_id":1,"sid_token":"n02s2jtdgnlqlceicbde09reh6","auth":{"success":true,"error_codes":[]}}
    /// </summary>
    public class Set_Email_User
    {
        /// <summary>
        /// Error message if the alias could not be set
        /// </summary>
        [DeserializeAs(Name = "alias_error")]
        public string AliasError { get; set; }

        /// <summary>
        /// This is the scrambled version of email_addr, eg “fcs5d3+vgdtknvsyt4”. The scrambled address is an alias for email_addr, so all email going to alias will arrive at 
        /// the inbox of email_addr. Scrambled addresses are used to mask the email_addr, so it is difficult for someone else to know which email_addr was used.
        /// </summary>
        [DeserializeAs(Name = "alias")]
        public String Alias { get; set; }

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
        /// The ID of the site which the domain belongs to
        /// </summary>
        [DeserializeAs(Name = "site_id")]
        public int SiteID { get; set; }

        /// <summary>
        /// Session Token
        /// </summary>
        [DeserializeAs(Name = "sid_token")]
        public String SessionID { get; set; }

        // Unknown
        public Auth Authentication { get; set; }

        public class Auth
        {

            [DeserializeAs(Name = "success")]
            public bool Success { get; set; }

            [DeserializeAs(Name = "error_codes")]
            public object[] ErrorCodes { get; set; }
        }
    }
}
