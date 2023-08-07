using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShoppingListMobileApp.Models; // Bu namespace'i uygun şekilde güncellemelisiniz.

namespace ShoppingListMobileApp.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        // ViewModel'deki özellikleri burada tanımlayabilirsiniz.
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<RecommendedItem> _recommendedItems;
        public ObservableCollection<RecommendedItem> RecommendedItems
        {
            get { return _recommendedItems; }
            set
            {
                _recommendedItems = value;
                OnPropertyChanged();
            }
        }

        public HomePageViewModel()
        {
            // ViewModel başlatma kodlarını burada ekleyebilirsiniz.
            UserName = "Hi Batuhan!";
            Categories = new ObservableCollection<Category>
            {
                new Category { Name = "Technology", Icon = "smartphone.png" },
                new Category { Name = "Clothes", Icon = "clothes2.png" },
                new Category { Name = "Food and Beverage", Icon = "food.png" },
                new Category { Name = "Cosmetics", Icon = "cosmetics.png" }
            };

            RecommendedItems = new ObservableCollection<RecommendedItem>
            {
                new RecommendedItem { Image = "item1.png" },
                new RecommendedItem { Image = "item2.png" },
                new RecommendedItem { Image = "item3.png" }
                // Burada önerilen öğeleri eklemeye devam edebilirsiniz.
            };
        }

        // INotifyPropertyChanged arabirimini uygulamak için gerekli kodlar.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
