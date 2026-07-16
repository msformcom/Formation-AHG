using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class CalculatorVM
    {
        private readonly Func<int, int, int> calcul;

        public CalculatorVM(Func<int, int, int> calcul = null)
        {
            this.calcul = calcul ?? ((a,b)=>a + b) ;
        }
  
        public int A { get; set; }
        public int B { get; set; }
        public int Resultat { get; set; }


    }
}
