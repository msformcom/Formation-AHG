using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MonApp.Model;

namespace MonApp.ViewModels
{
    internal class IPointVM2 : ViewModelBase
    {
        public IPoint Model { get; set; }


        #region Propriété X
        public float X
        {
            get { return Model.X; }
            set {
                Model.X = value;
                OnPropertyChanged("");
            }
        }
        #endregion


        #region Propriété Y
        public float Y
        {
            get { return Model.Y; }
            set
            {
                Model.Y = value;
                OnPropertyChanged("");
            }
        }
        #endregion


        public float Norme=>Model.Norme;

        RelayCommand _multiplyByCommand;
        public ICommand MultiplyByCommand
        {
            get
            {

                if (_multiplyByCommand == null)
                {
                    _multiplyByCommand = new RelayCommand(
                        execute: async (o) =>
                        {
                            var m = int.Parse(o.ToString());
                            Model.MultiplyBy(m);
                            this.OnPropertyChanged("");
                            _multiplyByCommand.OnCanExecuteChanged();

                        },
                        canExecute: o => {
                            var m = int.Parse(o.ToString());
                            return Model.Norme * m < 20;
                        }
                    );
                }
                return _multiplyByCommand;
            }
        }

    }
}
