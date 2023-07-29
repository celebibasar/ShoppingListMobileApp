using ShoppingListMobileApp.Models;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp;

public partial class HomePage : ContentPage
{
    public ObservableCollection<FairyTale> FairyTales { get; set; }
    public ObservableCollection<FairyTale> FairyTales2 { get; set; }
    public HomePage()
    {
        InitializeComponent();
        InitializeTales();
        BindingContext = this;
    }
    private void InitializeTales()
    {
        FairyTales = new ObservableCollection<FairyTale>
               {
                   new FairyTale { Name = "Cinderella", ReadTime = new TimeSpan(0, 30, 0), Image = "cinderella.jpg" },
                   new FairyTale { Name = "Snow White", ReadTime = new TimeSpan(0, 25, 0),  Image = "snow.jpg" },
                   new FairyTale { Name = "Rapunzel", ReadTime = new TimeSpan(0, 20, 0),  Image = "rapunzel.jpg" },
                   new FairyTale { Name = "Little Red Riding Hood", ReadTime = new TimeSpan(0, 15, 0),  Image = "hood.jpg" },
                   new FairyTale { Name = "Beauty and the Beast", ReadTime = new TimeSpan(0, 35, 0),  Image = "beauty.jpg" }
               };
        FairyTales2 = new ObservableCollection<FairyTale>
               {
                   new FairyTale { Name = "Snow White", ReadTime = new TimeSpan(0, 25, 0),  Image = "snow.jpg" },
                   new FairyTale { Name = "Rapunzel", ReadTime = new TimeSpan(0, 20, 0),  Image = "rapunzel.jpg" },
                   new FairyTale { Name = "Little Red Riding Hood", ReadTime = new TimeSpan(0, 15, 0),  Image = "hood.jpg" },
                   new FairyTale { Name = "Beauty and the Beast", ReadTime = new TimeSpan(0, 35, 0),  Image = "beauty.jpg" },
                   new FairyTale { Name = "Cinderella", ReadTime = new TimeSpan(0, 30, 0),  Image = "cinderella.jpg" }
               };
    }

    private void Button_Clicked_Profile(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ProfilePage());
    }
    private void Button_Clicked_Search(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }
    private void Button_Clicked_Cart(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CartPageView());
    }

    private void Button_Clicked_Technology(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TechnologyPage());
    }
}