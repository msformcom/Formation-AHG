using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CapteurNS;

namespace SimpleAppli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CapteurNS.CapteurDMX c=new CapteurNS.CapteurDMX("COM4") { TestConformite=(v=>v>10 && v<20)};


        // Debut infos VM
        public ObservableCollection<CapteurNewValueEventArgs<double>> Mesures { get; set; } = new () {  };
        
        // Fin infos VM
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
           
            c.NewValueEvent += async (o, e) =>
            {
                await App.Current.Dispatcher.InvokeAsync(() =>
                {
                    // Ce code s'exécute sur le thread principal UI
                    Mesures.Add(e);
                });
             
            };
            c.StartListening();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            c.StopListening();
        }
    }


    public class Mesure
    {
        public Double Valeur { get; set; }
        public bool Conforme { get; set; }
    }
}