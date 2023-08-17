using ShoppingListMobileApp.Models;
using ShoppingListMobileApp.ViewModels;

namespace ShoppingListMobileApp;

public partial class EditPageView : ContentPage
{
    public EditPageView(User user)
    {
        InitializeComponent();
        BindingContext = new EditProfilePageViewModel(user);
    }


    void BackBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }

    void SaveBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new ItemPageView());
    }
}
