using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sensors.AsyncSensors
{
    public abstract class AsyncSensorBase<T> : IAsyncSensor<T>
    {

        // 1) avoir un dictionnaire de conditions sur les valeurs mesurées
        // 2) avoir un évènement NewValueAlert qui se déclenche si une condition n'est pas respectee
        // 3) avoir AddContion
        // 4) avoir RemoveCondition
        private Dictionary<string, Func<T, bool>> Validators = new();
        public AsyncSensorBase(string nom, params IEnumerable<(string Nom, Func<T, bool> Condition)> validators)
        {
            this.Nom = nom;
            foreach (var v in validators)
            {
                Validators.Add(v.Nom, v.Condition);
            }
        }

        public void AddValidator(string name, Func<T, bool> condition)
        {
            if (Validators.ContainsKey(name))
            {
                throw new ArgumentException($"Un validateur avec le nom {name} existe déjà");
            }
            Validators.Add(name, condition);
        }
        public void RemoveValidator(string name)
        {
            if (!Validators.ContainsKey(name))
            {
                throw new ArgumentException($"Aucun validateur avec le nom {name} n'existe");
            }
            Validators.Remove(name);
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


        protected List<SensorHistoryEntry<T>> _Histoliste = new();


        public event EventHandler<SensorNewValueEventArgs<T>> NewValueEvent;
        public event EventHandler<SensorNewValueInvalidEventArgs<T>> NewValueInvalidEvent;

        public IEnumerable<SensorHistoryEntry<T>> Historique
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

        protected void OnNewValueInvalid(T newValue, IEnumerable<string> validatorNames)
        {
            if (NewValueInvalidEvent != null)
            {
                NewValueInvalidEvent(this, new SensorNewValueInvalidEventArgs<T>(newValue ,DateTime.Now, validatorNames));
            }
        }

        protected void OnNewValue(T newValue)
        {
            // Est-ce que une fonction est associée à cet évènement
            if (NewValueEvent != null)
            {
                // J'éxécute la/les fonctions associées à cet évènement
                // Argument 1 : this = l'objet déclencheur
                // Argument 2 : eventargs (coquillevide)
                NewValueEvent(this, new SensorNewValueEventArgs<T>() { Date = DateTime.Now, NewValue = newValue });


            }
        }


        protected abstract Task<T> GetNewValue();

        public virtual async Task<T> ReadValueAsync()
        {

            try
            {
                // Cette partie est la partie spécifique au capteur
                var r = await GetNewValue();


                _Histoliste.Add(new SensorHistoryEntry<T>() {  Value = r });
                // déclenche l'évènement
                OnNewValue(r);
                var invalidValidators = Validators.Where(v => !v.Value(r)).Select(v => v.Key).ToList();
                if (invalidValidators.Any()) {
                    OnNewValueInvalid(r, invalidValidators);
                }   
                return r;
            }
            catch (Exception ex)
            {

                _Histoliste.Add(new SensorHistoryEntry<T>() {  Exception=ex});
                OnNewValueException(ex);
                throw new Exception("Erreur");
            }


        }


        protected void OnNewValueException(Exception ex)
        {
            // Est-ce que une fonction est associée à cet évènement
            if (NewValueEvent != null)
            {
                // J'éxécute la/les fonctions associées à cet évènement
                // Argument 1 : this = l'objet déclencheur
                // Argument 2 : eventargs (coquillevide)
                NewValueEvent(this, new SensorNewValueEventArgs<T>() { Date = DateTime.Now, Exception = ex });
            }
        }

        
    }
}
