using Microsoft.Maui.Controls;
using ShoppingListMobileApp.ViewModels;
using System.Windows.Input;

namespace ShoppingListMobileApp
{
    public class VerificationPageViewModel : BaseViewModel
    {
        private string verificationCode;
        public string VerificationCode
        {
            get => verificationCode;
            set => SetProperty(ref verificationCode, value);
        }

        private static bool isVerificationCodeWrong;
        public bool IsVerificationCodeWrong
        {
            get { return isVerificationCodeWrong; }
            set
            {
                isVerificationCodeWrong = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; }

        public VerificationPageViewModel()
        {
            VerifyCommand = new Command(Verify);
        }

        private void Verify()
        {
            // Burada kullanıcının girdiği verificationCode'u doğrulama işlemlerini gerçekleştirin.
            // Örneğin, e-posta veya SMS ile gönderilen kodu kaydedin ve girdi ile karşılaştırın.
            // Doğrulama işlemlerini gerçek projeye uygun şekilde doldurun.

            if (VerificationCode != "123")
            {
                IsVerificationCodeWrong = true;
            }
            else
            {
                //shell'den Verification page kaldırılmalı.
                Application.Current.MainPage.Navigation.PopAsync();
                IsVerificationCodeWrong = false;
            }
        }
    }
}
