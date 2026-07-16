using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using Capteur;
using Microsoft.Extensions.Logging;


namespace CapteurNS
{
    public class CapteurDMX : CapteurBase<Double>
    {
        private readonly string port;

        public CapteurDMX(string port, ILogger<CapteurDMX> logger) : base(s =>
        {
            var reg = new Regex(@"[1-9]\d*\.\d+");
            var numString = reg.Matches(s)[0].Value; //00005.194
            //numString = numString.Replace(".", ",");
            var value = Convert.ToDouble(numString, CultureInfo.InvariantCulture);
            return value;
        },logger )
        {
            this.port = port;
   
        }

     



        // Chaine renvoyée par capteur 1 MW +00005.194 mm


        private SerialPort SerialPort { get; set; }

        public override void StartListening()
        {
            SerialPort = new SerialPort();
            SerialPort.PortName = this.port;      // À adapter selon votre port
            SerialPort.BaudRate = 9600;        // Vitesse (ex: 9600, 115200)
            SerialPort.Parity = Parity.None;
            SerialPort.StopBits = StopBits.One;
            SerialPort.DataBits = 8;
            SerialPort.Open();
            SerialPort.DataReceived += SerialPort_DataReceived;
        }

        private  void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // peut être exécuté par un thread secondaire
            var chaine = this.SerialPort.ReadLine();
            var valeur = this.GetValueFromString(chaine);
            NewValue(valeur);

        }

        public override void StopListening()
        {
            SerialPort.Close();


            //using(var c= new SerialPort())
            //{
            //    c.Open();

            //   // c.Dispose() => Fermerure des resources ouvertes va être appelée automatiquement
            //}
        }
    }
}
