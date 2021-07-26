using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
<<<<<<< HEAD
    public sealed class Paging : InstagramEntityBase
=======
    public sealed class Paging
>>>>>>> 560b841f76a6544d1cffbdbb9dee33834bad531d
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }

        [JsonProperty("next")]
        public String Next { get; set; }
    }
}