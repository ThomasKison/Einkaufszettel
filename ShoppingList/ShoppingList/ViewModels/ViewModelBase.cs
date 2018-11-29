using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingList.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged<T>(ref T field, T newValue, [CallerMemberName] string caller = "")
        {
            if (!field?.Equals(newValue) ?? true)
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
