using System.Configuration;

namespace MonkeyShock.Dyn365.Utilities.Configuration
{
    public interface IConfigurationManager
    {
        ConnectionStringSettingsCollection ConnectionStrings { get; }
    }
}
