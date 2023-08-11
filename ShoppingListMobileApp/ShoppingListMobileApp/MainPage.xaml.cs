using System.Collections.ObjectModel;
using System.Collections.Generic; // Bu satırı ekleyin
using ShoppingListMobileApp.Models;

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
        private void CreateSampleBasketsAndItems()
        {
            // Bu kısım örnek sepet detayları oluşturur.
            var basketDetailsList = new List<BasketDetailsModel>();

            for (int basketId = 0; basketId < 10; basketId++)
            {
                // Her bir sepet detayı için örnek ürünler oluşturun.
                var productItems = new ObservableCollection<ProductItem>();

                for (int productId = 0; productId < 5; productId++)
                {
                    // Örnek ProductItem'ı oluşturun ve sepete ekleyin.
                    var productItem = new ProductItem
                    {
                        ProductName = $"Product {productId}",
                        Description = $"Description of Product {productId}",
                        Quantity = 1, // Varsayılan miktar
                        Price = $"{(productId + 1) * 100}$",
                        ProductImage = "airpods.jpeg" // Ürünün resmi
                    };

                    productItems.Add(productItem);
                }

                // Oluşturulan ürünlerle bir BasketDetailsModel nesnesi oluşturun ve listeye ekleyin.
                var basketDetails = new BasketDetailsModel
                {
                    BasketId = basketId, // Sepet ID'si
                    ProductItems = productItems // Ürün listesi
                };

                basketDetailsList.Add(basketDetails);
            }

            // Şimdi, her bir BasketDetailsModel nesnesi için örnek ürünler içeren bir liste (basketDetailsList) var.


            // BasketDetailsModel koleksiyonunu başka bir veri bağlamayla eşleme
            BindingContext = basketDetailsList;
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
