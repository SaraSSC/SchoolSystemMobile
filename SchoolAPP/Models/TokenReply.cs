using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolAPP.Models
{
    public class TokenReply
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiration")]
        public string Expiration { get; set; }
    }
}
