using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class User : InstagramEntityBase
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("account_type")]
        public String AccountType { get; set; }

        [JsonProperty("media_count")]
        public String MediaCount { get; set; }
    }
}