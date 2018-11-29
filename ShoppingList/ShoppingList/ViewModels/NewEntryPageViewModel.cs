using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    class NewEntryPageViewModel : ViewModelBase
    {
        public NewEntryPageViewModel()
        {
            ShoppingListEntry = new ShoppingListEntry();
        }

        private ShoppingListEntry _shoppingListEntry;

        public ShoppingListEntry ShoppingListEntry
        {
            get { return _shoppingListEntry; }
            set { RaisePropertyChanged(ref _shoppingListEntry, value); }
        }

        private ICommand _saveEntryCommand;
        public ICommand SaveEntryCommand =>
            _saveEntryCommand ?? (_saveEntryCommand = new Command(ExecuteSaveEntryCommand));

        void ExecuteSaveEntryCommand()
        {

        }

    }
}
