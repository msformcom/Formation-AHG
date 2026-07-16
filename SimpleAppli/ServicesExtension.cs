using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapteurNS;
using GlobalElements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace SimpleAppli
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


        public static void AddAppComPorts(this ServiceCollection serviceCollection,string coms)
        {
        
            var tabComs = coms.Split(",");
            foreach (var com in tabComs)
            {
                serviceCollection.AddKeyedSingleton<CapteurDMX>(com, (s, o) => {
                    var logger = s.GetRequiredService<ILogger<CapteurDMX>>();
                    var capteur = new CapteurDMX(com, logger);
                    capteur.TestConformite = v => v > 10;
                    capteur.StartListening();
                    return capteur;
                });
            }
        }


        public static void AddAppLogging(this ServiceCollection serviceCollection, string logFilePath)
        {
        
            serviceCollection.AddLogging(builder =>

            {

                var logger = new LoggerConfiguration().MinimumLevel.Debug()
                                                            .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                                                            .CreateLogger();

                builder.AddSerilog();
             
            });

        }

        //public  static void AddAppCapteurRandomFactory(this ServiceCollection serviceCollection)
        //{
        //    //Création d'un factory => une fonction qui créé un CapteurRandom à partir du parametre max
        //    Func<int, CapteurRandom> capteurRandomFactory = (i =>
        //    {
        //        var logger = App.Services.GetRequiredService<ILogger<CapteurRandom>>();
        //        var random = new CapteurRandom(i, logger);
        //        random.TestConformite = r => r < i / 2;
        //        random.StartListening();
        //        return random;
        //    });

        //    // On met le factory à disposition
        //    serviceCollection.AddSingleton(capteurRandomFactory);
        //}
    }
}
