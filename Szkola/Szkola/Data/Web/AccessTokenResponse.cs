using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Szkola.Data.Web
{
    public class AccessTokenResponse
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("data")]
        public AccessTokenData Data { get; set; }
    }

    public class AccessTokenData
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
    }
}
