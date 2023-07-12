using System.Collections.ObjectModel;
using ShoppingListMobileApp.DataSources;
using Xamarin.KotlinX.Coroutines.Channels;

namespace ShoppingListMobileApp;

public partial class ItemPageView : ContentPage
{
    public ItemPageView()
	{
		InitializeComponent();
        var Products = new ObservableCollection<Product>
        {
            new Product { Name = "Ürün 1", Price = 10.99 },
            new Product { Name = "Ürün 2", Price = 19.99 },
            new Product { Name = "Ürün 3", Price = 8.99 }
        };
        BindingContext = this;
    }
    private void OnAddToCartClicked(object sender, EventArgs e)
    {
    }
}
