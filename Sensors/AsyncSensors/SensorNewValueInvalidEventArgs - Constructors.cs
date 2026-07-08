using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{
    public partial class SensorNewValueInvalidEventArgs<T> 
    {

        public SensorNewValueInvalidEventArgs(T? newValue, DateTime date , IEnumerable<string> validatorNames)
        {
            NewValue = newValue;
            Date = date;
            ValidatorNames = validatorNames;
        }
    }
}
