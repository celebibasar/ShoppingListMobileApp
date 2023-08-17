using ShoppingListMobileApp;
using ShoppingListMobileApp.Models;
using ShoppingListMobileApp.ViewModels;

namespace ShoppingListMobileApp;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        // ViewModel oluşturup, içeriği doldurun.
        ProfilePageViewModel viewModel = new ProfilePageViewModel();
        // Örnek bir User modeli oluşturup ViewModel'e atayın.
        viewModel.User = new User
        {
            Username = "celebibasar",
            Password = "******",
            Email = "basarcelebi02@gmail.com"
            // Diğer özellikleri de burada doldurabilirsiniz.
        };
        BindingContext = viewModel;
    }

    private void EditBtn1_Clicked(object sender, EventArgs e)
    {
        // Mevcut kullanıcı bilgilerini alın veya oluşturun
        User currentUser = new User
        {
            Username = "celebibasar", // Kullanıcı adı
            Password = "******",      // Şifre
            Email = "basarcelebi02@gmail.com" // E-posta
                                              // Diğer kullanıcı bilgileri
        };

        // EditPageView'a geçiş yaparken currentUser bilgilerini taşıyın
        Navigation.PushAsync(new EditPageView(currentUser));
    }


}