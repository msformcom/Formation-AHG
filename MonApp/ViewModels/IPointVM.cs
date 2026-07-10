using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MonApp.Model;

namespace MonApp.ViewModels
{
    internal partial class IPointVM : ObservableObject
    {
        [ObservableProperty()]
        [NotifyPropertyChangedFor(nameof(Norme))]
        [NotifyPropertyChangedFor(nameof(X))]
        [NotifyPropertyChangedFor(nameof(Y))]
        private IPoint _Model;

        partial void OnModelChanged(IPoint m)
        {
            X = m.X;
            Y = m.Y;
        }

        

        // Cet attribut entraine la génération d'une propriété X dans un fichier de classe partielle
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Norme))]
        private float _X;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Norme))]
        private float _Y;

        partial void OnXChanged(float v)
        {
            Model.X = v;
        }
        partial void OnYChanged(float v)
        {
            Model.Y = v;
        }



        public float Norme => Model.Norme;


        RelayCommand _multiplyByCommand;
        public ICommand MultiplyByCommand
        {
            get
            {
   
                if (_multiplyByCommand == null)
                {
                    _multiplyByCommand = new RelayCommand(
                        execute:async (o) =>
                        {
                            var m = int.Parse(o.ToString());
                            Model.MultiplyBy(m);
                            this.OnPropertyChanged(nameof(Model));
                            X = Model.X;
                            Y = Model.Y;
                            _multiplyByCommand.OnCanExecuteChanged();

                        }, 
                        canExecute:o=> {
                            var m = int.Parse(o.ToString());
                            return Norme*m < 20;
                        }
                    );
                }
                return _multiplyByCommand;
            }
        }



    }
}
