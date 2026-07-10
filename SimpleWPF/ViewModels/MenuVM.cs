using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWPF.ViewModels
{
    public class MenuVM
    {
        public IEnumerable<MenuItemVM> TopButtons { get; set; }
        public IEnumerable<MenuItemVM> BottomButtons { get; set; }
    }
}
