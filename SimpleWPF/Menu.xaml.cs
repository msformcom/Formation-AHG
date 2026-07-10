using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.DependencyInjection;
using SimpleWPF.ViewModels;
using SimpleWPF.ViewModels.Pages;

namespace SimpleWPF
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

		public Object CurrentVM { get; set; } = App.Services.GetService<AccueilVM>();

        public Menu()
        {
            InitializeComponent();
        }
		#region Propriété MenuKey

		private string _MenuKey;

		// Cette propriété permet à ce controle de charger à partir de l'injection de dépendance les VM des buttons
		public string MenuKey
		{
			get { return _MenuKey; }
			set
			{
				// TODO : Tester value
				_MenuKey = value;
				this.DataContext=App.Services.GetKeyedService<MenuVM>(value);
			}
		}
		#endregion

	}
}
