using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Controls;
using System.Windows.Media;


namespace GlobalElements.ViewModels
{
    public class MenuItemVM
    {
 
        public string Libelle { get; set; }

        public ButtonTypeEnum Type { get; set; } = ButtonTypeEnum.Normal;

        public Func<Object> GetNewVM { get; set; }

    }
}
