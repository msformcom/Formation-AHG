using System.Configuration;
using System.Data;
using System.ServiceProcess;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using SimpleWPF.Menus;
using SimpleWPF.ViewModels;
using SimpleWPF.ViewModels.Pages;

namespace SimpleWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services;

        static App()
        {
            // Création du provider
            var collection = new ServiceCollection();
            collection.AddMainMenu();
            // Un seul AccueilVM pour tous les affichages de la page Accueil
            collection.AddSingleton<AccueilVM>();
            // Un  QuitterVM pour chaque nouvel affichage de la page Quitter
            collection.AddTransient<QuitterVM>();


            Services = collection.BuildServiceProvider();



        }
    }

}
