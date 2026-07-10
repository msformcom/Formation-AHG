using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonApp.Model
{
    public interface IPoint
    {
        float X { get; set; }
        float Y { get; set; }

        float Norme { get; }

        void MultiplyBy(float c);

    }
}
