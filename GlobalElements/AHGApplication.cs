using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GlobalElements
{
    public class AHGApplication : Application
    {
        public IServiceProvider Services { get; protected set; }
    }
}
