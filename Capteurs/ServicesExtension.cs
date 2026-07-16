
using CapteurNS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace GlobalElements
{
    public static class ServicesExtension
    {
        public static void AddAppComPorts(this ServiceCollection serviceCollection,string configKey)
        {
            var config = serviceCollection.OfType<IConfiguration>().First();
            var tabComs = config.GetSection(configKey).Value.Split(",");
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
        public static void AddAppCapteurRandomFactory(this ServiceCollection serviceCollection, AHGApplication app)
        {
            //Création d'un factory => une fonction qui créé un CapteurRandom à partir du parametre max
            Func<int, CapteurRandom> capteurRandomFactory = (i =>
            {

                var logger = app.Services.GetRequiredService<ILogger<CapteurRandom>>();
                var random = new CapteurRandom(i, logger);
                random.TestConformite = r => r < i / 2;
                random.StartListening();
                return random;
            });

            // On met le factory à disposition
            serviceCollection.AddSingleton(capteurRandomFactory);
        }
    }
}
