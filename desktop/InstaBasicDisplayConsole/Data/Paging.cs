using System;

using Newtonsoft.Json;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }

        [JsonProperty("next")]
        public String Next { get; set; }
    }
}