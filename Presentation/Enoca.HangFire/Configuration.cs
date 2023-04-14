namespace Enoca.HangFire
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
                return configurationManager.GetSection("HangfireSettings:ConnectionStr").Value;

            }
        }
    }
}
