using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CapteurNS;

namespace Capteur
{
    public abstract class CapteurBase<TValue> : ICapteur<TValue>
    {
        protected CapteurBase(Func<string,TValue> interpretationString)
        {
            this.InterpretationString = interpretationString;
        }
        // Evènement qui va se déclencher quand une nouvelle valeur est lue et transcrite à partir du capteur
        public event EventHandler<CapteurNewValueEventArgs<TValue>> NewValueEvent;


        protected List<CapteurNewValueEventArgs<TValue>> _Historique = new List<CapteurNewValueEventArgs<TValue>>();
        public IEnumerable<CapteurNewValueEventArgs<TValue>> Historique
        {
            get { return _Historique.AsEnumerable(); }
        }

        public Func<TValue, bool> TestConformite { get; set; } = (v) => false;

        /// <summary>
        /// Ajoute une nouvelle valeur lue par le capteur dans l'historique
        /// Et déclenche l'évènement
        /// </summary>
        /// <param name="valeur"></param>
        protected void NewValue(TValue valeur)
        {
            var ev = new CapteurNewValueEventArgs<TValue>(valeur, TestConformite(valeur));
            _Historique.Add(ev);

            // Si ce code est exécuté par un thread secondaire => 
            // le gestionnaire associé sera lui-même exécuté par un thread secondaire
            // erreur si on essaye de modifier un élément de l'UI
            if (NewValueEvent != null)
            {
                NewValueEvent(this, ev);
            }

        }

        public Func<string,TValue> InterpretationString { get; set; }

        protected TValue GetValueFromString(string s)
        {
            try
            {

                //var reg = new Regex(@"[1-9]\d*\.\d+");
                //var numString = reg.Matches(s)[0].Value; //00005.194
                ////numString = numString.Replace(".", ",");
                //var value = Convert.ToDouble(numString, CultureInfo.InvariantCulture);
                return InterpretationString(s);
            }
            catch (Exception)
            {

                throw new Exception("Le découpage n'a pas donné de résultat correct");
            }

        }


        public abstract void StartListening();
        public abstract void StopListening();
    }
}
