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
using MonApp.Model;
using MonApp.ViewModels;

namespace MonApp.Controls
{
    /// <summary>
    /// Logique d'interaction pour PointDisplay.xaml
    /// </summary>
    public partial class PointDisplay : UserControl
    {
        public PointDisplay()
        {
            InitializeComponent();
        }


        // <ShowValue Value="4"></ShowValue>  => Une propriéré int de nom Value sur la classe ShowValue suffit
        // <ShowValue Value="{staticresource R1}"></ShowValue>  => Une propriéré int de nom Value sur la classe ShowValue suffit
        // <ShowValue Value="{Binding Age}"></ShowValue>  => Il faut une dépendency property
        // 
        public IPoint Point
        {
            get { return (IPoint)GetValue(PointProperty); }
            set { SetValue(PointProperty, value); }
        }



        // Using a DependencyProperty as the backing store for Point.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointProperty =
            DependencyProperty.Register("Point", typeof(IPoint), typeof(PointDisplay), new PropertyMetadata(null,
                    // callback exécuté automatiquement lorsque la valeur change
                    new PropertyChangedCallback((o, e) => {
                        var me = (PointDisplay)o;
                        me.DataContext = new IPointVM2() { Model=(IPoint)e.NewValue };
                        }
                    )));

    }
}
