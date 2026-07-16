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
using GlobalElements;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleAppli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //CapteurNS.CapteurDMX c=App.Services.GetRequiredKeyedService<CapteurDMX>("COM4");


        


        // Debut infos VM
        public ObservableCollection<object> Mesures { get; set; } = new () {  };
        
        // Fin infos VM
        
        public MainWindow()
        {
            InitializeComponent();

            // Sans factory
            //CapteurNS.CapteurDMX c = App.Services.GetRequiredKeyedService<CapteurDMX>("COM4");

            // Avec Factory
            var capteurRandomFactory =App.CurrentApp.Services.GetRequiredService<Func<int, CapteurRandom>>();

            var cr1 = capteurRandomFactory(1000);
            cr1.NewValueEvent += Cr_NewValueEvent1;
            var cr2= capteurRandomFactory(667); 
            cr2.NewValueEvent += Cr_NewValueEvent1;
            var cr3 = capteurRandomFactory(456);
            cr3.NewValueEvent += Cr_NewValueEvent1;



            this.DataContext = this;
           
            //c.NewValueEvent += async (o, e) =>
            //{
            //    await App.Current.Dispatcher.InvokeAsync(() =>
            //    {
            //        // Ce code s'exécute sur le thread principal UI
            //        Mesures.Add(e);
            //    });
             
            //};

        }

        private async void Cr_NewValueEvent1(object? sender, CapteurNewValueEventArgs<int> e)
        {
            await App.Current.Dispatcher.InvokeAsync(() =>
            {
                // Ce code s'exécute sur le thread principal UI
                Mesures.Add(e);
            });
        }



        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //c.StopListening();
        }
    }


    public class Mesure
    {
        public Double Valeur { get; set; }
        public bool Conforme { get; set; }
    }
}