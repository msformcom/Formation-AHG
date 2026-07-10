using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonApp.ViewModels
{
    internal class ViewModelBase : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(params IEnumerable<string> propertyNames)
        {
            foreach (var name in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
