using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class Media : InstagramEntityBase
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