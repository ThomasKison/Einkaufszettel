using ShoppingList.Models;
using ShoppingList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.Views
{
    public partial class MainPage : ContentPage
    {
        List<ShoppingListEntry> _entries;
        public MainPage()
        {
            InitializeComponent();
            var mpvm = new MainPageViewModel();
            shoppingListView.BindingContext = mpvm;
        }
        
        //private void Bought_Clicked(object sender, EventArgs e)
        //{
        //    _entries.Remove((sender as Button)?.BindingContext as ShoppingListEntry);
        //    shoppingListView.ItemsSource = null;
        //    shoppingListView.ItemsSource = _entries;
        //}

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewEntryPage());
        }
    }
}
