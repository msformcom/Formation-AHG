using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class WMISensorTest
{
    [TestMethod]
    public void WMISensorReadValueTest()
    {
        // Arrange
        var sensor = new WMISensor(espace: @"root\wmi",
                                    nom: "CPU Temp",
                                    requete: "SELECT CurrentTemperature FROM MSAcpi_ThermalZoneTemperature");
        Exception erreur = null;
        double? resultat=null;
        try
        {
            // act
            resultat = sensor.ReadValue();
        }
        catch (Exception ex)
        {

           erreur=ex;
        }


        // Assert
        Assert.IsNull(erreur, "Erreur dans WMI");
        Assert.IsNotNull(resultat, "Valeur de température non donnée");
    }
}
