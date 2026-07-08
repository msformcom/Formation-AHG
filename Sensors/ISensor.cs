using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    public interface ISensor<T>
    {
        string Nom { get; }
        T ReadValue();
    }
}
