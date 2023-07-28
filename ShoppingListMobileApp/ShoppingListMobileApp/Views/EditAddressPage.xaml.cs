

namespace ShoppingListMobileApp;

public partial class EditAddressPage : ContentPage
{
	public EditAddressPage(Address address)
	{
        InitializeComponent();

        BindingContext = new EditAddressViewModel(address);
    }
}
