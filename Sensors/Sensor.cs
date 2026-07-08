using System.ComponentModel.DataAnnotations;

namespace Capteurs
{
    // Classe
    // Constructeurs : initialisation des informations de la classe
    // Champs : stocker
    // Propriété : Lire ou modifier des informations sur l'objet
    // Functions : Exécuter du code relatif à l'objet
    


    public class Sensor
    {
        public Sensor(string nom,string numeroSerie,int port=1)
        {
            this.Nom = nom;
            this.NumeroSerie = numeroSerie;
            this.Port = port;
        }

        public Sensor(string nom,  int port ) : this(nom,"A0000",port)
        {
 
        }






        public int Port { get; set; } = 1;


        [RegularExpression(@"[A-Z]\d{4}", ErrorMessage ="Une lettre et 4 chiffres")]
        public string? NumeroSerie { get; set; }

        private string _Nom; // champs => espace de stockage



        [Required(ErrorMessage="Le nom est obligatoire")]
        // Propriété : accesseurs get et set
        public string Nom
        {
            get { return _Nom; }
            set
            {
                // Check de value avant de l'utiliser
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le Nom ne peut être vide");
                }
                _Nom = value;
            }

        }


        public float GetValue()
        {

            return 40000.987987F; // F float, D double, M Decimal
        }
    }


}
