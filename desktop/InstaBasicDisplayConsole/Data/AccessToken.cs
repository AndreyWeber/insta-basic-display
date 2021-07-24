using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class AccessToken
    {
        [JsonProperty("access_token")]
        public String Token { get; set; }

        [JsonProperty("user_id")]
        public String UserId { get; set; }

        [JsonProperty("error_type")]
        public String ErrorType { get; set; }

        [JsonProperty("code")]
        public String Code { get; set; }

        [JsonProperty("error_message")]
        public String ErrorMessage { get; set; }
    }
}