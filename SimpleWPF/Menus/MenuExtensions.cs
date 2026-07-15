using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleWPF.ViewModels;
using SimpleWPF.ViewModels.Pages;

namespace SimpleWPF.Menus
{
    public static class MenuExtensions
    {
        public static void AddMainMenu(this ServiceCollection c)
        {
            c.AddKeyedSingleton<MenuVM>("MainMenu", new MenuVM()
            {
                TopButtons = new List<MenuItemVM>()
                            {
                                //GetNewVM demande à DI de nous fournir un VM à afficher
                                new MenuItemVM(){Libelle="Accueil", GetNewVM=()=>App.Services.GetService<AccueilVM>()},
                                new MenuItemVM(){Libelle="Quitter", Type= ButtonTypeEnum.Danger, GetNewVM=()=>App.Services.GetService<QuitterVM>()},
                            },
                BottomButtons = new List<MenuItemVM>()
                            {
                                new MenuItemVM(){Libelle="Accueil"},
                                 new MenuItemVM(){Libelle="Quitter", Type= ButtonTypeEnum.Danger},
                            } 
            });
        }
    }
}
