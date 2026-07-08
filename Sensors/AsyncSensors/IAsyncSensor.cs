using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{


    public  interface IAsyncSensor<T> 
    {
        string Nom { get; }
        string? Description { get; }

        // Permet de lire l'historique des valeurs (pas List ou Array modifiables)
        IEnumerable<(DateTime Date, T? Value, Exception? Exception)> Historique { get; }

        public void ClearHistorique();
        Task<T> ReadValueAsync();

        // event => Evenement 
        // Pour prévenir qu'une nouvelle mesure a été inséree dans l'historique
        public event EventHandler<SensorNewValueEventArgs<T>> NewValue;
        

    }
}
