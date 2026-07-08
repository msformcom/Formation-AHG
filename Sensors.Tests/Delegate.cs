using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class Delegate
{
    public Func<int,int> Log { get; set; }


    [TestMethod]
    public void TestMeDelegateTestthod1()
    {
        Func<double, double, string> f = (a, b) => "Toto";
        Action<string, string> g = (a, b) =>
        {
            Console.WriteLine(a);
        };

        Operation h = (a, b) => 1D;

    }

    // Je déclare un type de fonction Operation <=> Func<int,string,double>
    delegate double Operation(int a, string b);
}
