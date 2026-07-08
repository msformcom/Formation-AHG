using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensors.AsyncSensors;

namespace Sensors.Tests;

[TestClass]
public class RandomAsyncSensorTests
{
    RandomAsyncSensor s = new RandomAsyncSensor("Toto", 0, 100);

    
    //static RandomAsyncSensorTests()
    //{
    //    RandomAsyncSensor.NewValue+=(o, e) =>
    //    {
    //        if (e.Exception != null)
    //        {
    //            // Notification opérateur
    //            // o contient le capteur qui a généré l'exception
    //            // cela me permet de réagir en fonction du capteur
    //        }
    //    };
    //}
    public RandomAsyncSensorTests()
    {
        // Etre averti si nouvelle valeur dans l'historique
        s.NewValueEvent += (o, e) =>
        {
            if (e.Exception!=null)
            {
                // Notifier par mail un opérateur
                Console.WriteLine("Nouvelle mesure");
            }
            
        };

        s.NewValueEvent += (o, e) =>
        {
            Console.WriteLine("Nouvelle mesure");
        };
        s.NewValueEvent += EnvoiMail;
    }

    private void EnvoiMail(object? sender, EventArgs e)
    {
       // throw new NotImplementedException();
    }

    [TestMethod]
    public async Task ReadValueAsyncTest()
    {
        // Arrange
        //var s = new RandomAsyncSensor("Toto", 0, 100);
        int nbEvents = 0;
        s.NewValueInvalidEvent += (o,e)=> nbEvents++;
        var r = await Task.WhenAll(Enumerable.Range(0, 100).Select(c => s.ReadValueAsync()));

        var nbValueInvalid= r.Count(c => c < 0 || c > 100);
        Assert.AreEqual(nbValueInvalid, nbEvents);




    }

    private void S_NewValueInvalidEvent(object? sender, SensorNewValueInvalidEventArgs<int> e)
    {
        throw new NotImplementedException();
    }
}
