using Microsoft.Extensions.Configuration;

namespace Watch_Tronics.Utils
{
    public static class ConfigReader
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigReader()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string GetBaseUrl() => Configuration["BaseUrl"];
        public static string GetBrowser() => Configuration["Browser"];
    }
}
