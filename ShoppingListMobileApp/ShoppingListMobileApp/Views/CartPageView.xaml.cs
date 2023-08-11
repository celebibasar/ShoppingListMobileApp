using Microsoft.Maui.Controls;
using ShoppingListMobileApp.Models;
using ShoppingListMobileApp.ViewModels;
using System.Collections.Generic; // Bu satırı ekleyin
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AndroidX.Lifecycle;

namespace ShoppingListMobileApp
{
    public partial class CartPageView : ContentPage
    {
        public CartPageView()
        {
            InitializeComponent();
        }
        public void SetBindingContext(BasketDetailsModel basketDetails)
        {
            BindingContext = basketDetails;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }

        private void Button_Clicked_Home(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemPageView());
        }

        private void Button_Clicked_Search(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ItemPageView());
        }

        private void Button_Clicked_Checkout(object sender, EventArgs e)
        {
           
            Navigation.PushAsync(new CheckoutPageView());
        }

        private void ImageButton_Decrease(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.BindingContext is CartItem cartItem)
            {
                var cartViewModel = BindingContext as CartViewModel;
                cartViewModel?.OnDecreaseQuantity(cartItem);
            }
        }

        private void ImageButton_Increase(object sender, EventArgs e)
        {
            if (sender is ImageButton button && button.BindingContext is CartItem cartItem)
            {
                var cartViewModel = BindingContext as CartViewModel;
                cartViewModel?.OnIncreaseQuantity(cartItem);
            }
        }
        private void ClearCart_Clicked(object sender, EventArgs e)
        {
            // ViewModel referansını alarak ClearCart metotunu çağırın.
            var viewModel = (CartViewModel)BindingContext;
            viewModel.ClearCart();
        }


    }
}
