using System;
using System.Configuration;

using InstaBasicDisplayConsole.Data;
using InstaBasicDisplayConsole.Services.Interfaces;

namespace InstaBasicDisplayConsole.Services
{
    public class AppConfigurationFileService : IAppConfigurationService
    {
        public AppConfiguration GetConfiguration()
        {
            var appSettings = ConfigurationManager.AppSettings;

            var mediaRequestLimitStr = appSettings["MediaRequestLimit"] ?? throw new ConfigurationErrorsException("'MediaRequestLimit' configuration node not found");

            return new AppConfiguration
            {
                InstagramAppId = appSettings["InstagramAppId"] ?? throw new ConfigurationErrorsException("'InstagramAppId' configuration node not found"),
                InstagramAppSecret = appSettings["InstagramAppSecret"] ?? throw new ConfigurationErrorsException("'InstagramAppSecret' configuration node not found"),
                MediaRequestLimit = Int32.Parse(mediaRequestLimitStr)
            };
        }
    }
}