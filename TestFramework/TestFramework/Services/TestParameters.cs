using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Services
{
    class TestParameters
    {
        static Configuration ConfigFile
        {
            get
            {
                var variableFromConsole = TestContext.Parameters.Get("env");
                string file = string.IsNullOrEmpty(variableFromConsole) ? "dev" : variableFromConsole;
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"ConfigFiles\" + file + ".config"
                };
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }

        public static string GetData(string key)
        {
            var data = ConfigFile.AppSettings.Settings[key];
            return data.Value;
        }
    }
}
