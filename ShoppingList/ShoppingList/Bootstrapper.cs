using CommonServiceLocator;
using ShoppingList.Interfaces;
using ShoppingList.Services;
using ShoppingList.ViewModels;
using ShoppingList.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace ShoppingList
{
    class Bootstrapper
    {
        public static void DoBootstrapping(INavigation navigation)
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterInstance(navigation);
            unityContainer.RegisterSingleton<INavService, NavService>();


            // init the viewModels
            var navService = unityContainer.Resolve<INavService>();
            navService.RegisterViewModel<ShoppingListEntryViewModel, EditEntryPage>();
            navService.RegisterViewModel<MainPageViewModel, MainPage>();

            var unityServiceLocator = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
