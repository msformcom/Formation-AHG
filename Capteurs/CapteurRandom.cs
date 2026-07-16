using System.Globalization;
using System.IO.Ports;

using Capteur;
using Microsoft.Extensions.Logging;


namespace CapteurNS
{
    public class CapteurRandom : CapteurBase<int>
    {
        private readonly int max;
        System.Timers.Timer timer = new System.Timers.Timer();

        public CapteurRandom(int max, ILogger<CapteurRandom> logger) : base(s =>
        {

            var value = Convert.ToInt32(s);
            return value;
        }, logger)
        {

            this.max = max;
        }



        // Chaine renvoyée par capteur 1 MW +00005.194 mm


        private Random generateur = new Random();

        public override void StartListening()
        {

            timer.Interval = 1000;
            timer.Start();
            timer.Elapsed += (o, e) =>
            {
                NewValue(generateur.Next(0, max + 1));
            };
        }
        public override void StopListening()
        {
            timer.Stop();
        }
    }
}
