using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Interfaces
{
    public interface INavService
    {
        void RegisterViewModel<TVM, TV>();
        Task GoBack();
        Task NavigateTo<TVM, TParameter>(TParameter param);
    }
}
