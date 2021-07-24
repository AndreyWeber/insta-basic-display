using System.Collections.Generic;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class MediaCollection
    {
        [JsonProperty("data")]
        public IList<Media> Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}