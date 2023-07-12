using ShoppingListMobileApp;
using Microsoft.Maui.Controls;
using System;

namespace ShoppingListMobileApp;

public partial class RegisterPageView : ContentPage
{
    public RegisterPageView()
	{
        InitializeComponent();
	}
    private void SignUpBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }


}
