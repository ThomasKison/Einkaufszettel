using ShoppingList.Services;
using ShoppingList.ViewModels;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ShoppingList
{
    class Bootstrapper
    {
        public static void DoBootstrapping(INavigation navigation)
        {
            NavService.RegisterNavigation(navigation);
            NavService.RegisterViewModel<ShoppingListEntryViewModel, EditEntryPage>();
            NavService.RegisterViewModel<MainPageViewModel, MainPage>();
        }
    }
}
