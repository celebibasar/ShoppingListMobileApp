using System.Diagnostics;

namespace ShoppingListMobileApp.Views;

public partial class CartPageView : ContentPage
{
    private readonly CartView cartView;

    public CartPageView()
    {
        InitializeComponent();

        // CartView kontrolünü ekle.
        cartView = new CartView();
        Content = cartView;
    }



    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Sepetteki tüm ürün öğelerini yazdır.
        foreach (var item in cartView.GetCartItems())
        {
            Debug.WriteLine(item.ProductName + ", " + item.Price + ", " + item.Quantity);
        }
    }
    private async void CheckoutButtonClicked(object sender, EventArgs e)
    {
        //go to payment
        await Navigation.PushAsync(new MainPage());
    }
}
