using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class Cursors : InstagramEntityBase
    {
        [JsonProperty("after")]
        public String After { get; set; }

        [JsonProperty("before")]
        public String Before { get; set; }

    }
}
