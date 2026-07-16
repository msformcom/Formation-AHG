using System.Configuration;
using System.Data;
using System.Windows;
using CapteurNS;
using GlobalElements;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace SimpleAppli
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : AHGApplication
    {
        public static App CurrentApp
        {
            get
            {
                return (App)Application.Current;
            }
        }

        public App()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            //ServicesExtension.AddConfiguration(serviceCollection, "");
            var config = serviceCollection.AddAppConfiguration("");


            serviceCollection.AddAppLogging(config.GetSection("logfile").Value);


            serviceCollection.AddAppComPorts(config.GetSection("coms").Value);

            serviceCollection.AddAppCapteurRandomFactory(this);

            Services = serviceCollection.BuildServiceProvider();
        }


    }

}
