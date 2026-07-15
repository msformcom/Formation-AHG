namespace CapteurNS.Tests
{
    [TestClass]
    public sealed class CapteurTest
    {
        [TestMethod]
        public async Task TestMesure()
        {
     
            Double? valeurLue = null;
            var c = new CapteurDMX("COM4");
            try
            {
                c.StartListening();
                c.NewValueEvent += (o, e) =>
                {
                    // Fonction exécutée quand la mesure apparait
                    valeurLue = e.Value;
                };
                // Je demande une attente de 1 minute, le temps d'appuyer sur le pressoir
                await Task.Delay(60000);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Garanti que le port sera fermé
                c.StopListening();
            }
            

            Assert.IsNotNull(valeurLue,"La lecture a bie eu lieu");


        }
    }
}
