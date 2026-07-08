using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{

    class A
    {
         static int coef { get; set; }
        public string Nom { get; set; }
        // Pour exécuter MaMethode
        // var instanceDeA=new A();
        // instanceDeA.MaMethode();
        void MaMethode()
        {
            Math.Cos(1);
            A.coef = 4;
            MaMethodeStatique();
        }
        static void MaMethodeStatique()
        {
            // this pas disponible car méthode statique => exécutable sans créer d'instance
            A.MaMethodeStatique();
            string s = "Toto aime aller à la pêche";
          
            var s2 = StringExtensions.Ellipsis(s, 10);
            // Fonction d'extension
            // classe static, fonction static + this sur param1
            s2 = s.Ellipsis(10);
            // Remplace par s2=StringExtensions.Ellipsis(s, 10);

           
        }

    }
    internal static class StringExtensions
    {

        public static string Ellipsis(this string s, int n)
        {
            if (s.Length <= n)
            {
                return s;
            }
            return s.Substring(0, n - 3) + "...";
        }
    }
}
