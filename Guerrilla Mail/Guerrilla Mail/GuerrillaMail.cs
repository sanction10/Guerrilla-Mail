using RestSharp;
using System;
using System.Text.RegularExpressions;

namespace DisposableMail
{
    public class GuerrillaMail
    {
		// url constants
		private const string ApiUrl = "https://api.guerrillamail.com/ajax.php";
		private const string WebUrl = "https://www.guerrillamail.com/ajax.php";
		private const string InboxUrl = "https://www.guerrillamail.com/inbox";

        public string IP { get; set; }
        public string UserAgent { get; set; }
        public string Email { get; set; }
        public string SessionId { get; private set; }
		public string Alias { get; private set;}

		readonly RestClient _client = new RestClient { BaseUrl = new Uri(ApiUrl) };

        public GuerrillaMail(string ip = "127.0.0.1", string useragent = "localhost")
        {
            IP = ip;
            UserAgent = useragent;
        }

		private T Execute<T>(RestRequest request, RestClient client = null) where T : new()
        {
            request.AddParameter("ip", IP);
            request.AddParameter("agent", UserAgent);

            if (!String.IsNullOrEmpty(SessionId))
                request.AddParameter("sid_token", SessionId);
			
			var response = (client != null ? client : _client).Execute<T>(request);
            if (response.ErrorException != null)
                throw response.ErrorException;
			
            return response.Data;
        }	

        /// <summary>
        /// The function is used to initialize a session and set the client with an email address. If the session already exists, then it will return the email address details 
        /// of the existing session. If a new session needs to be created, then it will create new email address randomly. The function will return a number of arguments for 
        /// the client to remember, including the ‘sid_token’. The ‘sid_token’ is passed to each subsequent API call to maintain state.
        /// </summary>
        /// <param name="lang">A string representing the language code. Currently supported: en, fr, nl, ru, tr, uk, ar, ko, jp, zh, zh-hant, de, es, it, pt</param>
        /// <param name="domain">The domain name for the site. Defaults to guerrillamail.com</param>
        /// <returns></returns>
        public EmailAddress GetEmailAddress(string lang = "en", string domain = "guerrillamail.com")
        {
            var request = new RestRequest();
            request.AddParameter("f", "get_email_address");
            request.AddParameter("lang", lang);
            request.AddParameter("domain", domain);
			var result = Execute<EmailAddress>(request);
            
			SessionId = result.SessionID;
			Alias = result.Alias;
			Email = result.Address;

            return result;
        }

        /// <summary>
        /// Set the email address to a different email address. If the email has already been set, it will be given additional 60 minutes.
        /// Otherwise, a new email address will be generated if the email address is not in the database.
        /// </summary>
        /// <param name="lang">A string representing the language code. Currently supported: en, fr, nl, ru, tr, uk, ar, ko, jp, zh, zh-hant, de, es, it, pt</param>
        /// <param name="domain">The domain name for the site. Defaults to guerrillamail.com</param>
        /// <returns></returns>
		public EmailUser SetEmailUser(string email = "", string lang = "en", string domain = "guerrillamail.com")
        {
			if (!string.IsNullOrEmpty (email)) {
				Email = email;
			}

            var request = new RestRequest();
            request.AddParameter("f", "set_email_user");
            request.AddParameter("email_user", Email);
            request.AddParameter("lang", lang);
            request.AddParameter("domain", domain);
            var result = Execute<EmailUser>(request);
            
			SessionId = result.SessionID;
			Alias = result.Alias;
			Email = result.EmailAddress;

            return result;
        }

		public Inbox ListEmail(int offset = 0, int seq = 0)
		{
			var request = new RestRequest();
			request.AddParameter ("f", "get_email_list");
			request.AddParameter("offset", offset);
			request.AddParameter("seq", seq);

			var result = Execute<Inbox>(request);
			SessionId = result.SessionID;
			return result;
		}

        /// <summary>
        /// Check for new email on the server. Returns a list of the newest messages. The maximum size of the list is 20 items.
        /// The client should not check email too many times as to not overload the server. Do not check if the email expired, the email checking routing should pause 
        /// if the email expired.
        /// </summary>
        /// <param name="seq">The sequence number of the oldest email</param>
		public Inbox CheckEmail(int seq = 0)
        {
            var request = new RestRequest();
            request.AddParameter("f", "check_email");
            request.AddParameter("seq", seq);

			var result = Execute<Inbox>(request);
            SessionId = result.SessionID;
            return result;
        }
        
        /// <summary>
        /// Get the contents of an email.
        /// </summary>
        /// <param name="mailId"></param>
        /// <returns></returns>
		public Email FetchEmail(int mailId, bool showImages = false)
        {
            var request = new RestRequest();
            request.AddParameter("f", "fetch_email");
            request.AddParameter("email_id", mailId);
            var result = Execute<Email>(request);
            
			SessionId = result.SessionID;

			if (showImages)
				result.MailBody = ParseImages (result.MailBody);

            return result;
        }

		/// <summary>
		/// Send email from your guerrillamail address
		/// </summary>
		/// <param name="to">email address you are sending to</param>
		/// <param name="subject">subject of the email</param>
		/// <param name="to">text only email body content [no html]</param>
		/// <param name="to">domain (optional)</param>
		/// <returns></returns>
		public bool SendEmail(string to, string subject, string body, string domain = "guerrillamail.com")
		{
			var request = new RestRequest();

			// alternative client to API
			var client = new RestClient { BaseUrl = new Uri (WebUrl) };
			request.AddCookie ("PHPSESSID", SessionId);

			request.AddParameter("f", "send_email");

			request.AddParameter("to", to);
			request.AddParameter("from", Email);
			request.AddParameter("subject", subject);
			request.AddParameter("body", body);
			request.AddParameter ("g-recaptcha-response", string.Empty);
			request.AddParameter("domain", domain);

			var result = Execute<SendEmail>(request, client);
			return result.Valid;
		}

        /// <summary>
        /// Delete a email from the server
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
		public DeletedEmail DeleteEmail(int emailId)
        {
            var request = new RestRequest();
            request.AddParameter("f", "del_email");
            request.AddParameter("email_ids[]", emailId);
			var result = Execute<DeletedEmail>(request);
            return result;
        }

		/// <summary>
		/// Download attachment bytes from a specific email
		/// </summary>
		/// <param name="emailId">ID of the email</param>
		/// <param name="emailId">Specific attachment part</param>
		/// <returns></returns>
		public byte[] DownloadAttachment(int emailId, string part)
		{
			var request = new RestRequest ();
			var client = new RestClient { BaseUrl = new Uri (InboxUrl) };

			request.AddParameter ("get_att", string.Empty);
			request.AddParameter ("email_id", emailId);
			request.AddParameter ("part_id", part);
			request.AddCookie ("PHPSESSID", SessionId);
			var response = client.Execute(request);

			byte[] bytes = new byte[response.Content.Length * sizeof(char)];
			System.Buffer.BlockCopy(response.Content.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		/// <summary>
		/// Show original email header source
		/// </summary>
		/// <param name="emailId"></param>
		/// <returns></returns>
		public string ShowOriginal(int emailId)
		{
			var request = new RestRequest ();
			var client = new RestClient { BaseUrl = new Uri (InboxUrl) };

			request.AddParameter ("show_source", emailId);
			request.AddCookie ("PHPSESSID", SessionId);
			var response = client.Execute(request);

			return response.Content;
		}

		private string ParseImages(string body)
		{
			body = Regex.Replace (body, "\\/res.php\\?r=1\\&amp;n=img\\&amp;q\\=", string.Empty, RegexOptions.IgnoreCase);
			return body;
		}
    }
}
