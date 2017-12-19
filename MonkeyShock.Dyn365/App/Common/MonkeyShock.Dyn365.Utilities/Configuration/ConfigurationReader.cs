using System;
using System.Collections.Generic;
using MonkeyShock.Dyn365.Utilities.Common;

namespace MonkeyShock.Dyn365.Utilities.Configuration
{
    public class ConfigurationReader
    {
        private readonly IConsole console;

        #region Constructors
        public ConfigurationReader()
        {
            this.console = new ConsoleWrapper();
        }
        public ConfigurationReader(IConsole console)
        {
            this.console = console;
        } 
        #endregion

        public String GetServiceConfiguration(IConfigurationManager configurationManager)
        {
            int connectionStringsCount = configurationManager.ConnectionStrings.Count;

            List<KeyValuePair<String, String>> connectionStrings = new List<KeyValuePair<String, String>>();

            for (int a = 0; a < connectionStringsCount; a++)
            {
                if (this.IsConnectionStringValid(configurationManager.ConnectionStrings[a].ConnectionString))
                    connectionStrings.Add
                        (new KeyValuePair<string, string>
                            (configurationManager.ConnectionStrings[a].Name,
                            configurationManager.ConnectionStrings[a].ConnectionString));
            }

            if (connectionStrings.Count == 0)
            {
                this.console.WriteLine("An app.config file containing at least one valid Microsoft Dynamics CRM " +
                    "connection string configuration must exist in the run-time folder.");
                return null;
            }
            else if (connectionStrings.Count == 1)
            {
                return connectionStrings[0].Value;
            }
            else if (connectionStrings.Count > 1)
            {
                this.console.WriteLine("The following connections are available:");
                this.console.WriteLine("------------------------------------------------");

                var validConnectionStringsCount = connectionStrings.Count;

                for (int i = 0; i < validConnectionStringsCount; i++)
                {
                    this.console.Write($"\n({i + 1}) {connectionStrings[i].Key}\t");
                }

                this.console.WriteLine();

                this.console.Write($"\nType the number of the connection to use (1-{ validConnectionStringsCount }) [{validConnectionStringsCount }] : ");
                String input = this.console.ReadLine();

                if (IsInputOptionValid(input, validConnectionStringsCount))
                {
                    return connectionStrings[Int32.Parse(input) - 1].Value;
                }
                else
                {
                    this.console.WriteLine("Option not valid.");
                    return null;
                }  
            }
            return null;

        }

        public bool IsConnectionStringValid(String connectionString)
        {
            if (connectionString.Contains("Url=") ||
                connectionString.Contains("Server=") ||
                connectionString.Contains("ServiceUri="))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsInputOptionValid(string input, int connectionStringsCount)
        {
            if (!Int32.TryParse(input, out int configNumber) || configNumber > connectionStringsCount || configNumber == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
