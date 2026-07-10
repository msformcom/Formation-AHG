using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonApp.Model;

namespace MonApp.ViewModels
{
    internal class IPointVM : ViewModelBase
    {
        public IPoint Model { get; set; }



        #region Propriété X
        public float X
        {
            get { return Model.X; }
            set
            {
                // TODO : Tester value
                if (value != Model.X)
                {
                    Model.X = value;
                    OnPropertyChanged(nameof(Norme));
                }

            }
        }
        #endregion

        #region Propriété Y
        public float Y
        {
            get { return Model.Y; }
            set
            {
                // TODO : Tester value
                if (value != Model.Y)
                {
                    Model.Y = value;
                    OnPropertyChanged(nameof(Norme));
                }

            }
        }
        #endregion

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
                            OnPropertyChanged(nameof(X), nameof(Y), nameof(Norme));
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
