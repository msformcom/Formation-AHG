using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{

    // List<int> entiers=new List<int>(){1,2,3,2,3,4,2,3};
    // List<int> subSelect=entiers.sample(3) // 1,2,2
    // "Toto aime aller à la peche".Sample(3) // Toi...

    internal static class MyLinqExtensions
    {
        public static IEnumerable<T> Sample<T>(this IEnumerable<T> source,int step)
        {
            int i = 0;
 
            foreach (T t in source) {
                if (i % step == 0)
                {
                    // yield return renvoit les éléments 1 par 1
                    yield return t;
                }
                i++;
            }
        }
    }
}
