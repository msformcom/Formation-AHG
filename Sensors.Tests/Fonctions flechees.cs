using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class Fonctions_flechees
{
    [TestMethod]
    public void TestMethod1()
    {
        Func<int, int, int> f = Addition;
        f=(a, b) =>3;
        f = (int a, int b) =>
        {
            return a * b; 
        };

      

    }

    int Addition(int a, int b) {
        return a + b; 
    }
}
