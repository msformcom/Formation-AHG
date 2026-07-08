using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public class StingSensor : ISensor<(float x, float y, float z)>
    {
        public string Nom { get; private set; }

        public (float x, float y, float z) ReadValue()
        {
            // Utiliser le matériel pour obtenir les infos
            return (1, 2, 3);
        }
    }
}
