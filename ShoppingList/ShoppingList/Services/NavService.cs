using ShoppingList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace ShoppingList.Services
{
    class NavService : INavService
    {
        readonly IDictionary<Type, Type> _viewModelPageMapping = new Dictionary<Type, Type>();
        INavigation _navigation;
        IUnityContainer _container;

        public NavService(INavigation navigation, IUnityContainer container)
        {
            _navigation = navigation;
            _container = container;
        }

        public void RegisterViewModel<TVM, TV>()
        {
            _viewModelPageMapping.Add(typeof(TVM), typeof(TV));
        }

        public Task NavigateTo<TVM, TParameter>(TParameter param)
        {
            Page view = GetView<TVM, TParameter>(param);
            return _navigation.PushAsync(view);

        }
        public Task NavigateModalTo<TVM, TParameter>(TParameter param)
        {
            Page view = GetView<TVM, TParameter>(param);
            return _navigation.PushModalAsync(view);

        }

        private Page GetView<TVM, TParameter>(TParameter param) 
        {
            Type viewType;
            if (!_viewModelPageMapping.TryGetValue(typeof(TVM), out viewType))
            {
                throw new ArgumentException($"could not find view for {typeof(TVM)}");
            }
            var viewModel = _container.Resolve<TVM>();
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

        public Task GoBack()
        {
            return _navigation.PopAsync();
        }
        
    }
}
