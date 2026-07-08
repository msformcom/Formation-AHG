using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public abstract class SensorBase<T> : ISensor<T>
    {
        public SensorBase(string nom)
        {
            this.Nom = nom;
        }
        public string Nom { get; private set; }

        // Virtual => autorise les classes héritante à réécrire la méthode
        public abstract T ReadValue();
     
    }
}
