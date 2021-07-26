using System.Collections.Generic;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
<<<<<<< HEAD
    public sealed class MediaCollection : InstagramEntityBase
=======
    public sealed class MediaCollection
>>>>>>> 560b841f76a6544d1cffbdbb9dee33834bad531d
    {
        [JsonProperty("data")]
        public IList<Media> Data { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}