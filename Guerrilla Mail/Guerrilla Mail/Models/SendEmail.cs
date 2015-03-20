using System;
using RestSharp.Deserializers;

namespace DisposableMail
{
	public class SendEmail
	{
		[DeserializeAs(Name = "valid")]
		public bool Valid { get; set; }
	}
}

