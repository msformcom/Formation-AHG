using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.AsyncSensors
{


    public  interface IAsyncSensor<Tvalue> 
    {
        string Nom { get; }
        string? Description { get; }

        // Permet de lire l'historique des valeurs (pas List ou Array modifiables)
        IEnumerable<SensorHistoryEntry<Tvalue>> Historique { get; }

        // Pour RandomAsyncValidator AddValidator("Minimum",c=>c>10)
        // Pour RandomAsyncValidator AddValidator("Maximum", c=>c<100)
        void AddValidator(string name, Func<Tvalue, bool> condition);
        void RemoveValidator(string name);



        public void ClearHistorique();
        Task<Tvalue> ReadValueAsync();

        // event => Evenement 
        // Pour prévenir qu'une nouvelle mesure a été inséree dans l'historique
        public event EventHandler<SensorNewValueEventArgs<Tvalue>> NewValueEvent;
        public event EventHandler<SensorNewValueInvalidEventArgs<Tvalue>> NewValueInvalidEvent;


    }
}
