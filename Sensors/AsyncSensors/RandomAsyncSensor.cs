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

        public RandomAsyncSensor(string nom, int min = 0, int max = 1000) : base(nom)
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

        public override async Task<int> ReadValueAsync()
        {
            
            try
            {
                // Cette partie est la partie spécifique au capteur
                await Task.Delay(2000);
                var r = new Random().Next(Min, Max + 1);


                _Histoliste.Add((DateTime.Now, r, null));
                // déclenche l'évènement
                OnNewValue();
                return r;
            }
            catch (Exception ex)
            {

                _Histoliste.Add((DateTime.Now, 0, ex));
                throw new Exception("Erreur");
            }
           

        }
    }
}
