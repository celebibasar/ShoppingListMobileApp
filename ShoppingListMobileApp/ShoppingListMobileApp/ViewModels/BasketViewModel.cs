using System.Collections.ObjectModel;
using System.Windows.Input;
using ShoppingListMobileApp.Models;
using System.Collections.Generic; // Bu satırı ekleyin


namespace ShoppingListMobileApp.ViewModels
{
    public class BasketPageViewModel : BindableObject
    {
        public BasketPageViewModel()
        {
            Baskets = new ObservableCollection<Basket>
            {
                new Basket { Id = 0, Name = "Ev" },
                new Basket { Id = 1, Name = "İş" },
                new Basket { Id = 2, Name = "Okul" }
            };

            AddBasketCommand = new Command(OnAddBasket);
            EditBasketCommand = new Command(EditBasket);
            DeleteBasketCommand = new Command(DeleteBasket);
            ViewBasketDetailsCommand = new Command(BasketDetails);
            SaveBasketCommand = new Command(OnSaveBasket);
            CancelAddBasketCommand = new Command(OnCancelAddBasket);

            IsAddingBasket = false;
            IsBasketSelected = false;
            AddBasketButton = true;
        }

        public ObservableCollection<Basket> Baskets { get; set; }

        private Basket _selectedBasket;
        public Basket SelectedBasket
        {
            get { return _selectedBasket; }
            set
            {
                _selectedBasket = value;
                OnPropertyChanged(nameof(IsBasketSelected));
                IsBasketSelected = _selectedBasket != null;
            }
        }

        private bool _isBasketSelected;
        public bool IsBasketSelected
        {
            get { return _isBasketSelected; }
            set
            {
                _isBasketSelected = value;
                OnPropertyChanged();
            }
        }

        private bool _isAddingBasket;
        public bool IsAddingBasket
        {
            get { return _isAddingBasket; }
            set
            {
                _isAddingBasket = value;
                OnPropertyChanged();
            }
        }

        private bool _addBasketButton;
        public bool AddBasketButton
        {
            get { return _addBasketButton; }
            set
            {
                _addBasketButton = value;
                OnPropertyChanged();
            }
        }

        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddBasketCommand { get; }
        public ICommand EditBasketCommand { get; }
        public ICommand DeleteBasketCommand { get; }
        public ICommand ViewBasketDetailsCommand { get; }
        public ICommand SaveBasketCommand { get; }
        public ICommand CancelAddBasketCommand { get; }

        private async void EditBasket()
        {
            if (SelectedBasket != null)
            {
                var editBasketViewModel = new EditBasketPageViewModel();
                editBasketViewModel.SelectedBasket = SelectedBasket;

                // Handle the edit completed event
                editBasketViewModel.EditCompletedEvent += (sender, args) =>
                {
                    if (editBasketViewModel.EditCompleted)
                    {
                        // Editing was completed, trigger PropertyChanged for SelectedBasket
                        OnPropertyChanged(nameof(SelectedBasket));
                    }
                    // Close the EditBasketPage (pop the navigation stack)
                    Shell.Current.Navigation.PopAsync();
                };

                var editBasketPage = new EditBasketPageView();
                editBasketPage.BindingContext = editBasketViewModel;

                await Shell.Current.Navigation.PushAsync(editBasketPage);
            }
        }


        private void DeleteBasket()
        {
            if (SelectedBasket != null)
            {
                Baskets.Remove(SelectedBasket);
                SelectedBasket = null;
            }
        }


        private void BasketDetails()
        {
            // Seçilen sepetin detaylarını almak için gerekli işlemleri yapın.
            // Örneğin, sepetin kimliğine (Id) veya başka bir tanımlayıcıya göre sepeti bulun.

            // Ardından, sepetin detaylarını içeren bir nesne oluşturun ve bu nesneyi CartPageView'e ileten bir Navigation işlemi yapın.
            // Örnek olarak:
            var selectedBasketDetails = new BasketDetailsModel
            {
                BasketId = _selectedBasket.Id,
                BasketName = _selectedBasket.Name,
                ProductItems = new ObservableCollection<ProductItem>
        {
            new ProductItem
            {
                ProductName = "Apple",
                Description = "Iphone 14 Pro Max",
                Quantity = 2,
                Price = "1199$",
                ProductImage = "telefon.jpg"
            },
            // Diğer ürünleri buraya ekleyin...
        }
            };

            // CartPageView'in bağlamını ayarlayın:
            var cartPage = new CartPageView();
            cartPage.BindingContext = selectedBasketDetails;

            // Sayfayı navigasyon yoluyla gösterin:
            Application.Current.MainPage.Navigation.PushAsync(cartPage);
        }





        private void OnAddBasket()
        {
            IsAddingBasket = true;
            IsBasketSelected = false;
            AddBasketButton = false;
        }

        private void OnSaveBasket()
        {
            Baskets.Add(new Basket
            {
                Name = NewName
            });
            OnPropertyChanged();

            IsAddingBasket = false;
            AddBasketButton = true;
            NewName = string.Empty;
        }

        private void OnCancelAddBasket()
        {
            IsAddingBasket = false;
            AddBasketButton = true;
            NewName = string.Empty;
        }
    }
}
