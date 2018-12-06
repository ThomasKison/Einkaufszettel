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
        public MainPage()
        {
            InitializeComponent();
            
            var mpvm = new MainPageViewModel();
            BindingContext = mpvm;
            Bootstrapper.DoBootstrapping(Navigation);
        }

        
        
       
    }
}
