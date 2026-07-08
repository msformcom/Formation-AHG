using Capteurs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests
{
    [TestClass]
    public sealed class Sensors
    {
        [TestMethod]
        public void TypesEtOverflow()
        {

            // Float, double, decimal
            float d = 0;
            float inc = 0.3F;
            for(int i = 0; i < 10; i++)
            {
                d += inc;
            }
            if (d == 3F)
            {
                Assert.IsFalse(d == 3F, "a n'est qu'une approximation de 3");
                // En cas de nécessité de précision => Decimal
                // Pour rapiditté => Float ou double
            }

            Object o = 1;
            // test de typage
            if (o is int o2)
            {
                // o2 est la valeur de o castée en int
                var b2 = o2 * 2;
            }

            // Cast en int
            var b = (int)o * 2;

            // Selon le contexte (csproj) une erreur survient ou pas
            int a = int.MaxValue;
            b = a * 2;


            checked
            {
                a++;
            }

            // Parse => accessible sur les types pour convertir une chaine
            b = int.Parse("1");

            b = Convert.ToInt32(12.8D);



        }

        [TestMethod]
        public void TestSensorRange()
        {
            // Arrange
            Sensor s = new Sensor("",1);
            s.Nom = "Température de la bouilloire";
            float resultat=0; // déclaration de numerique => 0;


            // Act
            resultat = s.GetValue();

            // Assert
            Assert.IsTrue(resultat > -273.15 && resultat<1000,$"La valeur renvoyée n'est pas dans l'interval attendu. Valeur : {resultat:#.00}");
        }


        [TestMethod]
        public void CreateSensor()
        {
            // Arrange
            Sensor s = new Sensor("Sensor1",1) { Port=23, NumeroSerie="Toto"};



            // act
            s.Nom = "";


;
        }
    }
}
