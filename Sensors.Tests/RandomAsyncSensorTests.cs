using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensors.AsyncSensors;

namespace Sensors.Tests;

[TestClass]
public class RandomAsyncSensorTests
{
    RandomAsyncSensor s = new RandomAsyncSensor("Toto", 0, 100);

    public RandomAsyncSensorTests()
    {
        // Etre averti si nouvelle valeur dans l'historique
        s.NewValue += (o, e) =>
        {
            Console.WriteLine("Nouvelle mesure");
        };

        s.NewValue += (o, e) =>
        {
            Console.WriteLine("Nouvelle mesure");
        };
        s.NewValue += EnvoiMail;
    }

    private void EnvoiMail(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    [TestMethod]
    public async Task ReadValueAsyncTest()
    {
        // Arrange
        //var s = new RandomAsyncSensor("Toto", 0, 100);

        var mesure = await s.ReadValueAsync();

        Assert.IsTrue(mesure>=0 && mesure<=100,"Mesure non valide");
        Assert.AreEqual(1,s.Historique.Count() , "Historique faux");

    }
}
