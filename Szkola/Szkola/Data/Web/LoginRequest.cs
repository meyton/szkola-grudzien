using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Web
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
