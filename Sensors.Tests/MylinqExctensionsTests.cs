using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class MylinqExctensionsTests
{
    [TestMethod]
    public void SampleTest()
    {
        var chaine = "Toto aime aller à la pêche";

        var selection = chaine.Sample(3);

        var resultat = selection.ToList();

        var chaine2 = String.Join("", resultat);
        Assert.AreEqual(chaine2, "Toi l lph");
    }
}
