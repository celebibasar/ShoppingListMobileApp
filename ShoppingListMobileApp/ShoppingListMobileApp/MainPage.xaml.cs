

namespace ShoppingListMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Giriş butonuna tıklanınca çağrılacak işlem
            // Kullanıcı adı ve parola buradan alınabilir
            string username = (BindingContext as ViewModels.MainPageViewModel)?.Username;
            string password = (BindingContext as ViewModels.MainPageViewModel)?.Password;

            // Burada giriş işlemleri yapılabilir
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            // Kayıt ol butonuna tıklanınca çağrılacak işlem
            // Burada kayıt ol sayfasına geçiş yapabilirsiniz
        }
        private async void OnNotificationsClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NotificationsPageView());
        }
    }
}
