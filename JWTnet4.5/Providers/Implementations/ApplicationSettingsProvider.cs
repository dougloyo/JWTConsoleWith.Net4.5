using System.Configuration;

namespace JWTnet4._5.Providers
{
    public class ApplicationSettingsProvider : IApplicationSettingsProvider
    {
        public string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}