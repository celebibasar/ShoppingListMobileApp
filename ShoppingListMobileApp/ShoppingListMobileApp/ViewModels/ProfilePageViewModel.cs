using ShoppingListMobileApp.Models;

namespace ShoppingListMobileApp.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        private User _user;
        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        // Diğer ViewModel özellikleri ve yöntemleri eklenebilir.
    }
}
