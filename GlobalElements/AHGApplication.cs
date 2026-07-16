using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalElements
{
    public class AHGApplication : Application
    {
        public static AHGApplication Current
        {
            get {
                return (AHGApplication)Application.Current;
            }
        }
        public AHGApplication()
        {
            var serviceCollection = new ServiceCollection();
           

            ConfigureServices(serviceCollection);
            this.Services = serviceCollection.BuildServiceProvider();

        }

        public IConfiguration Config { get; protected set; }
        public IServiceProvider Services { get; protected set; }


        public virtual void ConfigureServices(ServiceCollection serviceCollection)
        {
            Config = serviceCollection.AddAppConfiguration("logfile");
            serviceCollection.AddAppLogging(Config);
        }


    }
}
