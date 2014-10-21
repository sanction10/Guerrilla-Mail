using DisposableMail.Functions;
using RestSharp;
using System;

namespace DisposableMail
{
    public class GuerrillaMail
    {
        public String IP { get; set; }
        public String UserAgent { get; set; }
        public String Email { get; private set; }
        public String SessionID { get; private set; }

        RestClient Client = new RestClient { BaseUrl = "https://api.guerrillamail.com/ajax.php" };

        public GuerrillaMail(String ip, String useragent)
        {
            IP = ip;
            UserAgent = useragent;
        }

        T Execute<T>(RestRequest request) where T : new()
        {
            request.AddParameter("ip", IP);
            request.AddParameter("agent", UserAgent);

            if (!String.IsNullOrEmpty(SessionID))
                request.AddParameter("sid_token", SessionID);

            var response = Client.Execute<T>(request);
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
        public Get_Email_Address GetEmailAddress(String lang = "en", String domain = "guerrillamail.com")
        {
            var request = new RestRequest();
            request.AddParameter("f", "get_email_address");
            request.AddParameter("lang", lang);
            request.AddParameter("domain", domain);
            var result = Execute<Get_Email_Address>(request);
            SessionID = result.SessionID;
            return result;
        }

        /// <summary>
        /// Set the email address to a different email address. If the email has already been set, it will be given additional 60 minutes.
        /// Otherwise, a new email address will be generated if the email address is not in the database.
        /// </summary>
        /// <param name="lang">A string representing the language code. Currently supported: en, fr, nl, ru, tr, uk, ar, ko, jp, zh, zh-hant, de, es, it, pt</param>
        /// <param name="domain">The domain name for the site. Defaults to guerrillamail.com</param>
        /// <returns></returns>
        public Set_Email_User SetEmailUser(String lang = "en", String domain = "guerrillamail.com")
        {
            var request = new RestRequest();
            request.AddParameter("f", "set_email_user");
            request.AddParameter("email_user", Email.Remove(Email.IndexOf('@')));
            request.AddParameter("lang", lang);
            request.AddParameter("domain", domain);
            var result = Execute<Set_Email_User>(request);
            SessionID = result.SessionID;
            return result;
        }

        /// <summary>
        /// Check for new email on the server. Returns a list of the newest messages. The maximum size of the list is 20 items.
        /// The client should not check email too many times as to not overload the server. Do not check if the email expired, the email checking routing should pause 
        /// if the email expired.
        /// </summary>
        /// <param name="seq">The sequence number of the oldest email</param>
        public Check_Email CheckEmail(Int32 seq)
        {
            var request = new RestRequest();
            request.AddParameter("f", "check_email");
            request.AddParameter("seq", seq);
            var result = Execute<Check_Email>(request);
            SessionID = result.SessionID;
            return result;
        }

        //get_email_list

        /// <summary>
        /// Get the contents of an email.
        /// </summary>
        /// <param name="MailID"></param>
        /// <returns></returns>
        public Fetch_Email FetchEmail(Int32 MailID)
        {
            var request = new RestRequest();
            request.AddParameter("f", "fetch_email");
            request.AddParameter("email_id", MailID);
            var result = Execute<Fetch_Email>(request);
            SessionID = result.SessionID;
            return result;
        }
    }
}
