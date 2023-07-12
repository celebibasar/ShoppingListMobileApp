using ShoppingListMobileApp;
using Microsoft.Maui.Controls;
using System;

namespace ShoppingListMobileApp;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnButtonClick(object sender, EventArgs e)
	{
        Navigation.PushAsync(new RegisterPageView());
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ItemPageView());
    }

    void TapGestureRecognizer_Tapped(System.Object sender, Microsoft.Maui.Controls.TappedEventArgs e)
    {
    }
}


