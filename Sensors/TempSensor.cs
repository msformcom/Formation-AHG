using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class TempSensor : ISensor<float>
    {
        // Constructeur
        public TempSensor(string nom)
        {
            this.Nom = nom;
        }

        #region Propriété Numero

        private string _Numero;

        public string Numero
        {
            get { return _Numero; }
            set
            {
                // TODO : Tester value
                _Numero = value;
            }
        }
        #endregion



        // Champs
        private string _Nom;

        // propriété
        public string Nom
        {
            get { return _Nom; }
            set
            {
                // Check de value avant de l'utiliser
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le Nom ne peut être vide");
                }
                _Nom = value;
            }

        }

        public float? LastRead { get; private set; }


        //public float ReadTemperatureAsync()
        //{
        //    Task T = new Task<float>(ReadTemperature);
        //}

        // Méthode synchrone => bloque le thread qui l'appelle pendant 8 s
        public float ReadValue()
        {

            Thread.Sleep(8000);
            var r= new Random().Next(0, 1000) / 10F;
            this.LastRead = r;
            return r;
        }



    }
}
