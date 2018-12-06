using ShoppingList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList.Services
{
    static class NavService
    {
        static readonly IDictionary<Type, Type> _viewModelPageMapping = new Dictionary<Type, Type>();
        static INavigation _navigation;

        public static void RegisterNavigation(INavigation navigation)
        {
            _navigation = navigation;
        }

        public static void RegisterViewModel<TVM, TV>()
        {
            _viewModelPageMapping.Add(typeof(TVM), typeof(TV));
        }

        public static Task NavigateTo<TVM, TParameter>(TParameter param)
             where TVM:new()
        {
            Page view = GetView<TVM, TParameter>(param);
            return _navigation.PushAsync(view);

        }
        public static Task NavigateModalTo<TVM, TParameter>(TParameter param)
          where TVM : new()
        {
            Page view = GetView<TVM, TParameter>(param);
            return _navigation.PushModalAsync(view);

        }

        private static Page GetView<TVM, TParameter>(TParameter param) where TVM : new()
        {
            Type viewType;
            if (!_viewModelPageMapping.TryGetValue(typeof(TVM), out viewType))
            {
                throw new ArgumentException($"could not find view for {typeof(TVM)}");
            }
            var viewModel = new TVM();
            // get view ctor with no parameters
            var ctors = viewType.GetTypeInfo().DeclaredConstructors;
            var viewCtor = viewType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(ct => ct.GetParameters().Length == 0);
            var view = viewCtor.Invoke(null) as Page;
            view.BindingContext = viewModel;
            IInit<TParameter> init = viewModel as IInit<TParameter>;
            if (init != null)
            {
                init.Init(param);
            }

            return view;
        }

        public static Task GoBack()
        {
            return _navigation.PopAsync();
        }
        
    }
}
