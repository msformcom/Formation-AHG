using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Sensors.AsyncSensors
{
    public class RandomAsyncSensorFactory
    {
        private readonly IServiceProvider applicationProvider;

        public RandomAsyncSensorFactory(IServiceProvider applicationProvider)
        {
       

            this.applicationProvider = applicationProvider;
        }

        public RandomAsyncSensor Create(string nom,int min, int max)
        {
            var sensorConfig = applicationProvider.GetRequiredService<SensorsConfig>();
            var instance = new RandomAsyncSensor(nom,sensorConfig, min, max);
            return instance;

        }
    }
}
