using ShoppingList.Interfaces;
using ShoppingList.Models;
using ShoppingList.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    public class ShoppingListEntryViewModel : ViewModelBase, IInit<ShoppingListEntry>
    {
        #region bindable properties
        private string _label;
        private double _quantity;
        private string _unit;
        private decimal _price;
        private string _store;

        public string Label
        {
            get { return _label; }
            set { base.RaisePropertyChanged(ref _label, value); }
        }
        public double Quantity
        {
            get { return _quantity; }
            set { base.RaisePropertyChanged(ref _quantity, value); }
        }

        public string Unit
        {
            get { return _unit; }
            set { base.RaisePropertyChanged(ref _unit, value); }
        }
        public decimal Price
        {
            get { return _price; }
            set { base.RaisePropertyChanged(ref _price, value); }
        }
        public string Store
        {
            get { return _store; }
            set { base.RaisePropertyChanged(ref _store, value); }
        }

        #endregion

        public ShoppingListEntryViewModel(INavService navService) : base(navService)
        {
        }

        private ShoppingListEntry _shoppingListEntry;

        private bool _isNew;

        public bool IsNew
        {
            get { return _isNew; }
            set { RaisePropertyChanged(ref _isNew, value); }
        }

       

        public string Title
        {
            get { return IsNew? "Neuer Eintrag" : "Eintrag bearbeiten"; }
        }

        private ICommand _saveEntryCommand;
        public ICommand SaveEntryCommand =>
            _saveEntryCommand ?? (_saveEntryCommand = new Command(ExecuteSaveEntryCommand));

        void ExecuteSaveEntryCommand()
        {
            _shoppingListEntry.Label = Label;
            _shoppingListEntry.Price = Price;
            _shoppingListEntry.Quantity = Quantity;
            _shoppingListEntry.Store = Store;
            _shoppingListEntry.Unit = Unit;
            _navService.GoBack();
        }

        public void Init(ShoppingListEntry param)
        {
            _shoppingListEntry = param;
            Label = param.Label;
            Price = param.Price;
            Quantity = param.Quantity;
            Store = param.Store;
            Unit = param.Unit;
        }
    }
}
