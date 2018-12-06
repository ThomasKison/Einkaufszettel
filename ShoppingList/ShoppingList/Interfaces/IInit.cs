using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList.Interfaces
{
    public interface IInit<TParam>
    {
        void Init(TParam param);
    }
}
