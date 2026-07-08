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
        IEnumerable<SensorHistoryEntry<T>> Historique { get; }

        // Pour RandomAsyncValidator AddValidator("Minimum",c=>c>10)
        // Pour RandomAsyncValidator AddValidator("Maximum", c=>c<100)
        void AddValidator(string name, Func<T, bool> condition);
        void RemoveValidator(string name);



        public void ClearHistorique();
        Task<T> ReadValueAsync();

        // event => Evenement 
        // Pour prévenir qu'une nouvelle mesure a été inséree dans l'historique
        public event EventHandler<SensorNewValueEventArgs<T>> NewValueEvent;
        public event EventHandler<SensorNewValueInvalidEventArgs<T>> NewValueInvalidEvent;


    }
}
