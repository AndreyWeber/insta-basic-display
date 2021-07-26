using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
<<<<<<< HEAD
    public sealed class Media : InstagramEntityBase
=======
    public sealed class Media
>>>>>>> 560b841f76a6544d1cffbdbb9dee33834bad531d
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("caption")]
        public String Caption { get; set; }

        [JsonProperty("media_type")]
        public MediaType MediaType { get; set; }

        [JsonProperty("media_url")]
        public String MediaUrl { get; set; }

        [JsonProperty("permalink")]
        public String PermanentLink { get; set; }

        [JsonProperty("thumbnail_url")]
        public String ThumbnailUrl { get; set; }

        [JsonProperty("timestamp")]
        public String Timestamp { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }
    }
}