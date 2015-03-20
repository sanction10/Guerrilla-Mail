using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;

namespace DisposableMail
{
    public class DeletedEmail
    {
        [DeserializeAs(Name = "deleted_ids")]
        public List<string> DeletedIDs { get; set; }

        [DeserializeAs(Name = "auth")]
        public Auth Authentication { get; set; }
    }
}
