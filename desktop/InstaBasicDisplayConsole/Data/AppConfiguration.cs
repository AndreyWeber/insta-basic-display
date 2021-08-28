using System;

namespace InstaBasicDisplayConsole.Data
{
    public sealed class AppConfiguration
    {
        public String InstagramAppId { get;  set; }

        public String InstagramAppSecret { get; set; }

        public String RedirectUrl { get; set; }

        public Int32 MediaRequestLimit { get; set; }
    }
}