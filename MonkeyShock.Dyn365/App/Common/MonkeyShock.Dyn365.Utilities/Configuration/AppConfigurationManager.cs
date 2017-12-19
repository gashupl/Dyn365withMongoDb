using System.Configuration;

namespace MonkeyShock.Dyn365.Utilities.Configuration
{
    public class AppConfigurationManager : IConfigurationManager
    {
        public ConnectionStringSettingsCollection ConnectionStrings => ConfigurationManager.ConnectionStrings;
    }
}
