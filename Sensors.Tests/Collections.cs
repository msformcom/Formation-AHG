using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensors.Tests;

[TestClass]
public class Collections
{

    [TestMethod]
    public void InterfaceTest()
    {
        ISensor<double> s = new WMISensor("toto", "", "");
        List<WMISensor> listeCapteurs= new ();
        //listeCapteurs.Add()
        listeCapteurs.Select(c => c.ReadValue()).Average();

    }
    [TestMethod]
    public void Tableaux()
    {
        // Déclaration d'un tableau d'entiers et instanciation
        int[] tab1D = new int[10];
        tab1D[0]= 1;
        tab1D[1]= 2;
        int[,] tab2D = new int[10, 5];
        tab2D[0,1]=4;
        int[,,] tab3D = new int[10, 5,8];
        int[,,,] tab4D = new int[10, 5, 8,6];
        var nbDim = tab4D.Rank; // 4
        var nbCelles= tab4D.Length; //2400
        var nbCellsDim1 = tab4D.GetLength(0); //10
        
        foreach(var e in tab4D)
        {

        }
    }
    [TestMethod]
    public void IEnumerableTest()
    {
        IEnumerable<int> liste=new int[10];
        IEnumerable<char> mot;
        mot= new char[10];
        mot = "Toto";

        foreach(var e in mot)
        {

        }

        //var enumerator = mot.GetEnumerator();
        //while (enumerator.MoveNext()) { 
        //    var e=enumerator.Current;
        //}

        //var entiers = GetEntiers();


        //var histo = entiers.ToArray();
        //foreach (var e in entiers)
        //{
        //    var a = e;
        //}
       
        var traitement = (int a, int b) => a + b;
        traitement = (a, b) => a - b;
        traitement = (a, b) =>
        {
            return a - b; 
        };
        traitement = Addition;

        var entiers = GetEntiers();
        Func<int,bool> estPair = (int e) => e % 2 == 0;

        var entiersPairs = entiers  // 0,1,2,3,4



            .Where(c => c % 2 == 0) // 0,2,4,6,8,10

            .Skip(2) // 4,6,8,10... 1020,... 

            .Take(10) //4, 6,8,   ,22
            .Reverse(); // 22,20,, 4;

        var entiersPairsDansUnTableau=entiersPairs.ToArray();
        var somme = entiersPairsDansUnTableau.Sum();
        var moyenne = entiersPairsDansUnTableau.Average();


        foreach (var e in entiersPairs) { 
        
        }

    }

    // Fonction qui indique si e est pair
    bool Filtre(int e)
    {
        return e % 2 == 0;
    }
    int Addition(int a, int b)
    {
        return a + b;
    }

    IEnumerable<Int64> GetEntiers()
    {
        Int64 i = 0;
        while (true)
        {
            yield return i;
            i++;
        }
            

    }

    [TestMethod]
    public void ListeSensor()
    {
        var entiers = new int[] { 1, 2, 3 };
        float coef = 2;
        var doubles = entiers.Select(c=>Transformation(c,2));

       // string chaine = "toto".OrderBy(c => c); //oott

        var mesCapteurs = new List<ISensor<float>>();
        mesCapteurs.Add(new TempSensor("Capteur1"));
        mesCapteurs.Add(new TempSensor("Capteur2"));



        mesCapteurs.Select(c => c.ReadValue()).Average();


    }

    float Transformation(int c, float coef=2)
    {
        return c * coef;
       }

}
