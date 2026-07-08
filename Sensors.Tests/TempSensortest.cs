using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class TempSensortest
{
    [TestMethod]
    public void LastReadValueTest()
    {
        // Act
        TempSensor t = new TempSensor("Processeur");

        Assert.IsNull(t.LastRead,"Température non null après initialisation" );

        t.ReadValue();



        Assert.IsNotNull(t.LastRead, "Température null après lecture");
    }
}
