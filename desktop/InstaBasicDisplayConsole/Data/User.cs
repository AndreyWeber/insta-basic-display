using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
<<<<<<< HEAD
    public sealed class User : InstagramEntityBase
=======
    public sealed class User
>>>>>>> 560b841f76a6544d1cffbdbb9dee33834bad531d
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