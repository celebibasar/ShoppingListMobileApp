using System;
using System.Windows.Input;


namespace ShoppingListMobileApp.ViewModels
{
    public class NewPasswordPageViewModel : BaseViewModel
    {
        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged();
            }
        }
        private string reNewPassword;
        public string ReNewPassword
        {
            get { return reNewPassword; }
            set
            {
                reNewPassword = value;
                OnPropertyChanged();
            }
        }

        public ICommand ChangePasswordCommand { get; }

        public NewPasswordPageViewModel()
        {
            ChangePasswordCommand = new Command(ChangePassword);
        }

        private void ChangePassword()
        {
            // Implement your password change logic here
            // You can access the new password using the 'NewPassword' property
            // For example, you can call a service to change the password
            // Once the password is successfully changed, you can navigate to another page
        }
    }
}
