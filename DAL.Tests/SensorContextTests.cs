using DAL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        serviceCollection.AddSingleton<IConfiguration>(configuration);

        // Ajout du SensorContext dans les services
        // Avec la fonction d'extension AddDbContext
        serviceCollection.AddDbContext<SensorContext>(options =>
        {
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
    public void InsertSensor()
    {
        // Obtention du contexte
        var context = DI.GetService<SensorContext>();


        var sensorAStocker=new RandomAsyncSensor()
        // Création d'un nouveau capteur
        var sensor = new SensorDAO
        {
            Name = "Capteur de test",
           
        };

    }
}
