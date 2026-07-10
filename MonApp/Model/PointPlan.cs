using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonApp.Model
{
    public class PointPlan : IPoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public float Norme => (float)Math.Sqrt(Math.Pow(X,2) + Y * Y);
    }
}
