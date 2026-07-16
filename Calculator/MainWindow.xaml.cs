using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GlobalElements;
using GlobalElements.MVVM;
using GlobalElements.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        ICommand ChangePage = new RelayCommand(async o =>
        {
            var button = (Button)o;
            var menuItemVM = (MenuItemVM)button.DataContext;
            var newPageVM = menuItemVM.GetNewVM();
            //this.CurrentPage=newPageVM;


        });

        public Object CurrentPage { get; set; }

        public MenuVM MainMenu { get; set; } = AHGApplication.Current.Services.GetRequiredKeyedService<MenuVM>("mainmenu");
    }
}