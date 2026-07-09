using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sensors.AsyncSensors
{
    public class RandomAsyncSensor : AsyncSensorBase<int>
    {
        private readonly SensorsConfig config;

        internal RandomAsyncSensor(string nom, SensorsConfig config, int min = 0, int max = 1000) : base(nom, ("Minimum", v => v >= min),("Maximum", v => v <= max))
        {
            if (min > max)
            {
                throw new ArgumentException("Min doit être inférieur à max");
            }
            Min = min;
            Max = max;
            this.config = config;
        }

        public int Min { get; }
        public int Max { get; }



     

        protected override async Task<int> GetNewValue()
        {

            var A = config.A;
            await Task.Delay(200);
            // Journaliser la lecture de la valeur
            var r = new Random().Next(Min, Max + 100);
            return r;
        }
    }
}
