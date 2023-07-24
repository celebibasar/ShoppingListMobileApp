using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingListMobileApp
{
    public class AddressViewModel : BindableObject
    {
        public AddressViewModel()
        {
            // Örnek hayali adresler oluştur
            Addresses = new ObservableCollection<Address>
            {
                new Address { FullAddress = "123 Main St, City A, Country" },
                new Address { FullAddress = "456 Elm St, City B, Country" },
                new Address { FullAddress = "789 Oak St, City C, Country" }
            };

            // Komutlar oluştur
            EditCommand = new Command(OnEdit);
            DeleteCommand = new Command(OnDelete);
            AddAddressCommand = new Command(OnAddAddress);
            SaveAddressCommand = new Command(OnSaveAddress);
            CancelAddAddressCommand = new Command(OnCancelAddAddress);

            // Yeni adres eklemeyi gizle
            IsAddingAddress = false;
        }

        // Adresler koleksiyonu
        public ObservableCollection<Address> Addresses { get; set; }

        // Seçili adres
        private Address selectedAddress;
        public Address SelectedAddress
        {
            get { return selectedAddress; }
            set
            {
                selectedAddress = value;
                OnPropertyChanged();
                IsAddressSelected = selectedAddress != null;
            }
        }

        // Seçili adres var mı?
        private bool isAddressSelected;
        public bool IsAddressSelected
        {
            get { return isAddressSelected; }
            set
            {
                isAddressSelected = value;
                OnPropertyChanged();
            }
        }

        // Yeni adres ekleniyor mu?
        private bool isAddingAddress;
        public bool IsAddingAddress
        {
            get { return isAddingAddress; }
            set
            {
                isAddingAddress = value;
                OnPropertyChanged();
            }
        }

        // Yeni eklenen adres
        private string newAddress;
        public string NewAddress
        {
            get { return newAddress; }
            set
            {
                newAddress = value;
                OnPropertyChanged();
            }
        }

        // Komutlar
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddAddressCommand { get; }
        public ICommand SaveAddressCommand { get; }
        public ICommand CancelAddAddressCommand { get; }

        // Düzenleme komutu işlemi
        private void OnEdit()
        {
            // Seçili adresi düzenlemek için gerekli işlemler yapabilirsiniz
            // Örneğin, düzenleme sayfasına yönlendirebilir veya pop-up açabilirsiniz

            // Seçili adresi null kontrolü yaparak düzenleme sayfasına gönderelim
            if (SelectedAddress != null)
            {
                // TODO: Düzenleme işlemleri için gerekli kodları buraya ekleyin
                Application.Current.MainPage.Navigation.PushAsync(new EditAddressPage(selectedAddress));
            }
        }

        // Silme komutu işlemi
        private void OnDelete()
        {
            // Seçili adresi silmek için gerekli işlemleri yapalım

            // Seçili adresi null kontrolü yaparak silme işlemini gerçekleştirelim
            if (SelectedAddress != null)
            {
                Addresses.Remove(SelectedAddress);
                SelectedAddress = null; // Seçili adresi sıfırlayalım
            }
        }

        // Adres ekleme komutu işlemi
        private void OnAddAddress()
        {
            // Yeni adres eklemeyi göster
            IsAddingAddress = true;
        }

        // Yeni adresi kaydetme komutu işlemi
        private void OnSaveAddress()
        {
            // Yeni adresi koleksiyona ekleyelim
            Addresses.Add(new Address { FullAddress = NewAddress });

            // Yeni adres eklemeyi gizle ve formu sıfırla
            IsAddingAddress = false;
            NewAddress = string.Empty;
        }

        // Yeni adres eklemeyi iptal etme komutu işlemi
        private void OnCancelAddAddress()
        {
            // Yeni adres eklemeyi gizle ve formu sıfırla
            IsAddingAddress = false;
            NewAddress = string.Empty;
        }
    }

    public class Address
    {
        public string FullAddress { get; set; }
    }
}
