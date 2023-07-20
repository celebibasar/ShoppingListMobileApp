
using ShoppingListMobileApp.DataSources;
namespace ShoppingListMobileApp;

public class CartView : ContentView
{
    private List<CartItem> _cartItems = new List<CartItem>();

    public void AddToCart(string productName, double price, int quantity)
    {
        _cartItems.Add(new CartItem(productName, price, quantity));
    }

    public IEnumerable<CartItem> GetCartItems()
    {
        return _cartItems;
    }

    public void ClearCart()
    {
        _cartItems.Clear();
    }
}

