using ShoppingList.Interfaces;
using ShoppingList.Models;
using ShoppingList.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShoppingList.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private ICommand _newEntryCommand;
       
        private ICommand _editItemCommand;
        private ICommand _itemBoughtCommand;

        public MainPageViewModel(INavService navService) : base (navService)
        {
            Load();
        }
        public void Load()
        {
            ShoppingListEntries.Add(new ShoppingListEntry
            {
                Label = "Milch",
                Price = 0.89m,
                Quantity = 10,
                Unit = "Stck",
                Store = "Edeka"
            });
            ShoppingListEntries.Add(new ShoppingListEntry
            {
                Label = "Nuss-Nougat-Creme",
                Price = 2.89m,
                Quantity = 1,
                Unit = "Stck",
                Store = "Edeka"
            });
            ShoppingListEntries.Add(
                new ShoppingListEntry
                {
                    Label = "Butter",
                    Price = 0.89m,
                    Quantity = 2,
                    Unit = "Stck",
                    Store = "Edeka"
                });
            ShoppingListEntries.Add(
                new ShoppingListEntry
                {
                    Label = "Hackfleisch",
                    Price = 18,
                    Quantity = 0.5,
                    Unit = "kg",
                    Store = "Rewe"
                });
        }

        public ICommand ItemBoughtCommand => _itemBoughtCommand ?? (_itemBoughtCommand = new Command<ShoppingListEntry>(ExecuteItemBoughtCommand));

        void ExecuteItemBoughtCommand(ShoppingListEntry sle)
        {
            ShoppingListEntries.Remove(sle);
        }

        public ICommand EditItemCommand =>
            _editItemCommand ?? (_editItemCommand = new Command<ShoppingListEntry>(ExecuteEditItemCommand));

        async void ExecuteEditItemCommand(ShoppingListEntry entry)
        {
           await _navService.NavigateTo<ShoppingListEntryViewModel, ShoppingListEntry>(entry);
        }


        public ICommand NewEntryCommand =>
            _newEntryCommand ?? (_newEntryCommand = new Command(ExecuteNewEntryCommand));

        async void ExecuteNewEntryCommand()
        {
            var newSle = new ShoppingListEntry();
            ShoppingListEntries.Add(newSle);
            await _navService.NavigateTo<ShoppingListEntryViewModel, ShoppingListEntry>(newSle);
        }

        public ObservableCollection<ShoppingListEntry> ShoppingListEntries { get; } = new ObservableCollection<ShoppingListEntry>();
    }
}
