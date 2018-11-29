﻿using ShoppingList.Models;
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
        public MainPageViewModel()
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

        private ICommand _itemBoughtCommand;
        public ICommand ItemBoughtCommand => _itemBoughtCommand ?? (_itemBoughtCommand = new Command<ShoppingListEntry>(ExecuteItemBoughtCommand));

        void ExecuteItemBoughtCommand(ShoppingListEntry sle)
        {
            ShoppingListEntries.Remove(sle);
        }

        public ObservableCollection<ShoppingListEntry> ShoppingListEntries { get; } = new ObservableCollection<ShoppingListEntry>();
    }
}
