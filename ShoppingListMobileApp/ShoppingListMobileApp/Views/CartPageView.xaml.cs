using Microsoft.Maui.Controls;
using ShoppingListMobileApp.ViewModels;

namespace ShoppingListMobileApp
{
    public partial class CartPageView : ContentPage
    {
        public CartPageView()
        {
            InitializeComponent();
        }

        private CartViewModel ViewModel => (CartViewModel)BindingContext;

        private void OnDecreaseClicked(object sender, EventArgs e)
        {
            var cartItem = (CartItem)((Button)sender).CommandParameter;
            if (cartItem.Quantity > 1)
                cartItem.Quantity--;
        }

        private void OnIncreaseClicked(object sender, EventArgs e)
        {
            var cartItem = (CartItem)((Button)sender).CommandParameter;
            cartItem.Quantity++;
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var cartItem = (CartItem)((Button)sender).CommandParameter;
            ViewModel.CartItems.Remove(cartItem);
        }

        private void OnConfirmClicked(object sender, EventArgs e)
        {
            // Sepeti onaylama işlemlerini burada yapabilirsiniz.
        }
    }
}
