using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapteurNS
{
    public class CapteurNewValueEventArgs<TValue> : EventArgs
    {
        public CapteurNewValueEventArgs(TValue value, bool conforme)
        {
            this.Value = value;
            this.Conforme = conforme;
        }
        public TValue Value { get; set; }

        public Boolean Conforme { get; set; } 
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
