using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence
{
    public class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Core/Enoca.EnvironmentConfiguration"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("localDb");

            }
        }
    }
}
