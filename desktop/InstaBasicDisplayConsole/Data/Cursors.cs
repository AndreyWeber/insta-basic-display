using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
<<<<<<< HEAD
    public sealed class Cursors : InstagramEntityBase
=======
    public sealed class Cursors
>>>>>>> 560b841f76a6544d1cffbdbb9dee33834bad531d
    {
        [JsonProperty("after")]
        public String After { get; set; }

        [JsonProperty("before")]
        public String Before { get; set; }

    }
}