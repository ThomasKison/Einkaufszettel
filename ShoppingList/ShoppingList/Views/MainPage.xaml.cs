using CommonServiceLocator;
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
            Bootstrapper.DoBootstrapping(Navigation);

            var mpvm = ServiceLocator.Current.GetInstance<MainPageViewModel>();
            BindingContext = mpvm;
            
        }

        
        
       
    }
}
