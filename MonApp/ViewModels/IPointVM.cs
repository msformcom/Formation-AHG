using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Model.X=value;
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
                    Model.X = value;
                    OnPropertyChanged(nameof(Norme));
                }

            }
        }
        #endregion

        public float Norme => Model.Norme;

     
    }
}
