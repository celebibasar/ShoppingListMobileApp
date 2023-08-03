﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

using ShoppingListMobileApp.ViewModels;

namespace ShoppingListMobileApp
{
    public partial class ItemDetailPageView : ContentPage
    {
        public ItemDetailPageView()
        {
            InitializeComponent();
            BindingContext = new ItemDetailPageViewModel();
        }
    }
}
