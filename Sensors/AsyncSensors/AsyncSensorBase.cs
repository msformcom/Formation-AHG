using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sensors.AsyncSensors
{
    public abstract class AsyncSensorBase<T> : IAsyncSensor<T>
    {
        public AsyncSensorBase(string nom)
        {
            this.Nom = nom;
            

        }

        #region Propriété Nom

        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le nom doit être fourni");
                }
                _Nom = value;
            }
        }
        #endregion


        public string? Description { get; set; }


        protected List<(DateTime Date, T? Value, Exception? Exception)> _Histoliste = new();

        
        public event EventHandler NewValue;

        public IEnumerable<(DateTime Date, T? Value, Exception? Exception)> Historique
        {
            get
            {
                return _Histoliste.AsEnumerable();
            }
        }

        public virtual void ClearHistorique()
        {
            _Histoliste.RemoveAll(c => c.Date < DateTime.Now.AddDays(-2));
        }

        protected void OnNewValue()
        {
            // Est-ce que une fonction est associée à cet évènement
            if (NewValue != null)
            {
                // J'éxécute la/les fonctions associées à cet évènement
                // Argument 1 : this = l'objet déclencheur
                // Argument 2 : eventargs (coquillevide)
                NewValue(this, EventArgs.Empty);
            }
        }


        public abstract Task<T> ReadValueAsync();
    }
}
