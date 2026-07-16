using System.Configuration;
using System.Data;
using System.Windows;
using Calculator.ViewModels;
using GlobalElements;
using GlobalElements.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AHGApplication
    {
        public App()
        {
            
        }

        public override void ConfigureServices(ServiceCollection serviceCollection)
        {
            // Configure automatiquement la Config et le Logging
            base.ConfigureServices(serviceCollection);
            serviceCollection.AddKeyedSingleton<MenuVM>("mainmenu", new MenuVM()
                .AddTopButton(new MenuItemVM() { Libelle = "Accueil", GetNewVM = () => new AccueilVM() })
                .AddTopButton(new MenuItemVM() { Libelle = "Calculator", GetNewVM = () => new CalculatorVM() }));

        }
    }

}
