using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GlobalElements
{
    public static class ServicesExtension
    {

        public static  IConfiguration AddAppConfiguration(this ServiceCollection serviceCollection, string path)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Ajouter le fichier de configuration
            configurationBuilder.AddJsonFile("appsettings.json");
            //configurationBuilder.AddJsonFile("appsettings-local.json");

            // Builder l'objet configuration
            var config = configurationBuilder.Build();
         

            // Builder l'objet configuration

            serviceCollection.AddSingleton<IConfiguration>(config);
            return config;
        }

        public static void AddAppLogging(this ServiceCollection serviceCollection, IConfiguration config)
        {
          
          
            serviceCollection.AddLogging(builder =>

            {
                var logFilePath = config.GetSection("logfile").Value;
                var logger = new LoggerConfiguration().MinimumLevel.Debug()
                                                            .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                                                            .CreateLogger();

                builder.AddSerilog(logger);
            });
        }

    }
}
