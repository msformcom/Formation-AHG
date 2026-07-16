using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalElements.ViewModels
{
    public class MenuVM
    {

        public MenuVM AddBottomButton(MenuItemVM button)
        {
            this.BottomButtons.Add(button);
            return this;
        }
        public MenuVM AddTopButton(MenuItemVM button)
        {
            this.TopButtons.Add(button);
            return this;
        }
        public List<MenuItemVM> TopButtons { get; set; } = new();
        public List<MenuItemVM> BottomButtons { get; set; } = new();
    }
}
