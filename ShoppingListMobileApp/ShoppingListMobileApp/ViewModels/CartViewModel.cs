using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ShoppingListMobileApp.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CartItem> _cartItems;
        public ObservableCollection<CartItem> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged();
                RecalculateTotalPrice();
            }
        }

        private string _newTotalPrice;
        public string NewTotalPrice
        {
            get { return _newTotalPrice; }
            set
            {
                _newTotalPrice = value;
                OnPropertyChanged();
            }
        }

        public CartViewModel()
        {
            InitializeCartItems();
            InitializeCommands();
        }

        public ICommand IncreaseQuantityCommand { get; private set; }
        public ICommand DecreaseQuantityCommand { get; private set; }

        private void InitializeCartItems()
        {
            // Örnek ürünleri ekleyelim.
            CartItems = new ObservableCollection<CartItem>
            {
                new CartItem { ProductName = "Ürün 1", Description = "ürün 1 açıklama", Quantity = 2, Price = "100", ProductImage = "telefon.jpg" },
                new CartItem { ProductName = "Ürün 2", Description = "ürün 2 açıklama", Quantity = 1, Price = "200", ProductImage = "telefon.jpg" },
                new CartItem { ProductName = "Ürün 3", Description = "ürün 3 açıklama", Quantity = 3, Price = "300", ProductImage = "telefon.jpg" },
                // Diğer örnek ürünler burada tanımlanır
            };
        }

        private void InitializeCommands()
        {
            IncreaseQuantityCommand = new Command<CartItem>(OnIncreaseQuantity);
            DecreaseQuantityCommand = new Command<CartItem>(OnDecreaseQuantity);
        }

        public void OnIncreaseQuantity(CartItem cartItem)
        {
            // Artırma işlemleri burada yapılır.
            cartItem.Quantity++;
            CartItems = new ObservableCollection<CartItem>(CartItems); // ObservableCollection'i güncelle
            OnPropertyChanged();
        }

        public void OnDecreaseQuantity(CartItem cartItem)
        {
            // Azaltma işlemleri burada yapılır.
            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                CartItems = new ObservableCollection<CartItem>(CartItems); // ObservableCollection'i güncelle
            }
            OnPropertyChanged();
        }

        private void RecalculateTotalPrice()
        {
            // Toplam fiyatı yeniden hesapla ve NewTotalPrice özelliğini güncelle.
            int total_price = 0;
            foreach (var item in CartItems)
            {
                total_price += int.Parse(item.Price) * item.Quantity;
            }
            NewTotalPrice = total_price.ToString();
        }
        public void Checkout()
        {
            // Checkout işlemi burada yapılır (örneğin, ödeme işlemleri vb.)
            // Sepeti boşaltmadan CheckoutPageView'e yönlendirme işlemi:
            Application.Current.MainPage.Navigation.PushAsync(new CheckoutPageView());
        }

        public void ClearCart()
        {
            // Sepeti boşaltmak için kullanılacak metot
            CartItems.Clear();
            RecalculateTotalPrice();
        }

        // INotifyPropertyChanged implementasyonu
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class CartItem : INotifyPropertyChanged
    {
        private int _quantity;
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }
        public string Price { get; set; }
        public string ProductImage { get; set; }

        // INotifyPropertyChanged implementasyonu
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // Diğer sınıflar ve modeller burada tanımlanır.
}
