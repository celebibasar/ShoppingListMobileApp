using ShoppingListMobileApp;

namespace ShoppingListMobileApp;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();

       

    }

    void EditBtn1_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new EditPageView());

    }

    
}