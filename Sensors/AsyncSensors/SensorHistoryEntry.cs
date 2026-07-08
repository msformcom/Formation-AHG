using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{
    public class SensorHistoryEntry<T>
    {
        public T Value { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Exception Exception { get; set; }
    }
}
