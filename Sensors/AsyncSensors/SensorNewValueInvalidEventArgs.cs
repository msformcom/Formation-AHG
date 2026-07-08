using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{
    public partial class SensorNewValueInvalidEventArgs<T> 
    {
        public IEnumerable<string> ValidatorNames { get; set; }
        public T NewValue { get; set; }
        public DateTime Date { get; set; }

    }
}
