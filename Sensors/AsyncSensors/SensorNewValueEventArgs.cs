using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{
    // Cette classe sert de conteneur d'informations relative à l'évènement NewValue sur un IAsyncSensor
    public class SensorNewValueEventArgs<T> : EventArgs
    {
        public T? NewValue { get; set; }
        public DateTime Date { get; set; }

        public Exception? Exception { get; set; }
    }
}
