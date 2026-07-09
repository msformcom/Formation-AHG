using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sensors.AsyncSensors;

namespace Sensors
{
    public static class DI
    {
        private static IServiceProvider _provider;


        public static IServiceProvider Provider
        {
            get { return _provider; }
        }


        static DI()
        {
            // Création du provider
            // on va configurer les services fournis
            var serviceCollection = new ServiceCollection();
            // Commencer par la config
            // Création d'un builder
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Ajouter le fichier de configuration
            configurationBuilder.AddJsonFile("appsettings.json");
            configurationBuilder.AddJsonFile("appsettings-local.json");

           
          

            // Builder l'objet configuration
            IConfiguration config =configurationBuilder.Build();

            //var sensorTypeName=config.GetSection("sensorTypeName").Value;
            //var sensorType=Type.GetType(sensorTypeName);
            //serviceCollection.AddTransient(typeof(IAsyncSensor<int>), sensorType);



            var applicationName = config.GetSection("applicationName").Value;

            // Ajout de SensorsConfig dans les services en mode singleton
            // 
            serviceCollection.AddSingleton<SensorsConfig>(s=>s.GetService<IConfiguration>().GetSection("sensorsConfig").Get<SensorsConfig>());
            serviceCollection.AddSingleton<IConfiguration>(config);
            serviceCollection.AddKeyedSingleton<IConfiguration>("local", config);
            serviceCollection.AddKeyedSingleton<IConfiguration>("global", config);

            _provider = serviceCollection.BuildServiceProvider();

           
            
            // Obtention du service de config
            var c=_provider.GetService<IConfiguration>();

        }
    }
}
