using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{
    public class RandomAsyncSensor : AsyncSensorBase<int>
    {

        public RandomAsyncSensor(string nom, int min = 0, int max = 1000) : base(nom, ("Minimum", v => v >= min),("Maximum", v => v <= max))
        {
            if (min > max)
            {
                throw new ArgumentException("Min doit être inférieur à max");
            }
            Min = min;
            Max = max;
        }

        public int Min { get; }
        public int Max { get; }



     

        protected override async Task<int> GetNewValue()
        {
            await Task.Delay(200);
            var r = new Random().Next(Min, Max + 100);
            return r;
        }
    }
}
