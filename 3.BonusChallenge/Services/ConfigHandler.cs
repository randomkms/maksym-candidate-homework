using _3.BonusChallenge.Interfaces;
using System.Collections.Generic;
using System.Configuration;

namespace _3.BonusChallenge.Services
{
    public class ConfigHandler : IConfigHandler
    {
        public IReadOnlyList<string> SimpleAnagramsList { get; } = GetConfig("SimpleAnagramsList").Split(Constants.WordsToSearchForAnagramsSeparator);
        public IReadOnlyList<string> HardAnagramsList { get; } = GetConfig("HardAnagramsList").Split(Constants.WordsToSearchForAnagramsSeparator);

        private static string GetConfig(string key)
        {
            var config = ConfigurationManager.AppSettings[key];
            if (config == null)
                throw new SettingsPropertyNotFoundException($"'{key}' was not found in application config");

            return config;
        }
    }
}