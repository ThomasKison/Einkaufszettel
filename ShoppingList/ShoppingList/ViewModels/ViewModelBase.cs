﻿using ShoppingList.Interfaces;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ShoppingList.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        protected readonly INavService _navService;
        public ViewModelBase(INavService navService)
        {
            _navService = navService;
        }
    }
}
