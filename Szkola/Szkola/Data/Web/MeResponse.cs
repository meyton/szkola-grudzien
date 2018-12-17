using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Web
{
    public class MeResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("data")]
        public UserDetails Data { get; set; }
    }
}
