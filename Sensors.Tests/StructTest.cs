using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class StructTest
{
    [TestMethod]
    public void TestMethod1()
    {
        var p1 = new ClassPoint() { X=1, Y=2 };
        var p2 = p1;
        p1.X = 3;

        var r1 = new StructPoint() { X = 1, Y = 2 };
        var r2 = r1;
        r1.X = 3;

    }


    class ClassPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Norme()
        {
            return Math.Abs(X)+Math.Abs(Y);
        }
    }
    struct StructPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Norme()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }
    }
}
