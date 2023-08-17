using ShoppingListMobileApp.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShoppingListMobileApp.ViewModels
{
    public class EditProfilePageViewModel : INotifyPropertyChanged
    {
        private User _user;

        public event PropertyChangedEventHandler PropertyChanged;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public EditProfilePageViewModel(User user)
        {
            User = user;
        }

        // PropertyChanged eventini tetiklemek için yardımcı metot
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
