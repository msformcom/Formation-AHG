using System.Text.Json;
using DAL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensors;
using Sensors.AsyncSensors;

namespace DAL.Tests;

[TestClass]
public class SensorContextTests
{
    public static IServiceProvider DI;

    static SensorContextTests()
    {

        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddJsonFile("appsettings.json");
        if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")=="Development")
        {
            configurationBuilder.AddJsonFile("appsettings - dev.json");
        }
        var configuration = configurationBuilder.Build();



        // Creation de la collection des services
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<SensorsConfig>(s => s.GetService<IConfiguration>().GetSection("sensorsConfig").Get<SensorsConfig>());


        // Ajoput de factory pour créer des instances de RandomAsyncSensor
        serviceCollection.AddSingleton<RandomAsyncSensorFactory>(s=>new RandomAsyncSensorFactory(s));

        serviceCollection.AddSingleton<IConfiguration>(configuration);

        // Ajout du SensorContext dans les services
        // Avec la fonction d'extension AddDbContext
        serviceCollection.AddDbContext<SensorContext>(options =>
        {
            //options.UseInMemoryDatabase("TestDatabase");
            options.UseSqlServer(configuration.GetSection("connectionStrings:SensorsBDDConnection").Value);
        });
        DI = serviceCollection.BuildServiceProvider();
    }


    [TestMethod]
    public void CreateDatabase()
    {
        var context=DI.GetService<SensorContext>();

        var created=context.Database.EnsureCreated();
        Assert.IsTrue(created, "La base de données n'a pas été créée");
    }

    [TestMethod]
    public async Task InsertSensor()
    {
        // Obtention du contexte
        var context = DI.GetService<SensorContext>();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();


       var sensorAStocker = DI.GetRequiredService<RandomAsyncSensorFactory>().Create("Capteur de test", 0, 100);
        await sensorAStocker.ReadValueAsync();
        await sensorAStocker.ReadValueAsync();
        // Création d'un nouveau capteur
        var sensorDAO = new SensorDAO
        {
            Name = sensorAStocker.Nom,
            // ConfigJson = sensorAStocker.ConfigJson
            ConfigJson = JsonSerializer.Serialize(new {min=sensorAStocker.Min, max=sensorAStocker.Max})
 
        };

        // Ajouter le capteur au contexte (ajouté en mémoire seulement, pas encore dans la base de données)
   

        var valuesDAO=sensorAStocker.Historique.Select(v => new SensorValueDAO
        {
            SensorId = sensorDAO.Id,
            ValueJson = JsonSerializer.Serialize(v.Value)
        });

        foreach (var valueDAO in valuesDAO)
        {
            sensorDAO.Values.Add(valueDAO);
        }
        context.Sensors.Add(sensorDAO);
        await context.SaveChangesAsync();


    }
}
