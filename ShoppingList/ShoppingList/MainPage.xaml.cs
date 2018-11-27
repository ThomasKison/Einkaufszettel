using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class MainPage : ContentPage
    {
        List<ShoppingListEntry> _entries;
        public MainPage()
        {
            InitializeComponent();
            // load model
           _entries = new List<ShoppingListEntry> {
                new ShoppingListEntry {
                    Label = "Milch",
                    Price = 0.89m,
                    Quantity = 10,
                    Unit = "Stck",
                    Store = "Edeka"
                },
                 new ShoppingListEntry {
                    Label = "Nuss-Nougat-Creme",
                    Price = 2.89m,
                    Quantity = 1,
                    Unit = "Stck",
                    Store = "Edeka"
                },
                new ShoppingListEntry {
                    Label = "Butter",
                    Price = 0.89m,
                    Quantity = 2,
                    Unit = "Stck",
                    Store = "Edeka"
                }
                ,
                new ShoppingListEntry {
                    Label = "Hackfleisch",
                    Price = 18,
                    Quantity = 0.5,
                    Unit = "kg",
                    Store = "Rewe"
                }
            };
            shoppingListView.ItemsSource = _entries;
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            _entries.Remove((sender as Button)?.BindingContext as ShoppingListEntry);
            shoppingListView.ItemsSource = null;
            shoppingListView.ItemsSource = _entries;
        }
    }
}
