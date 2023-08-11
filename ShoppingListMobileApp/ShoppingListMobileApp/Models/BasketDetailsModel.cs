using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShoppingListMobileApp.Models
{
    public class BasketDetailsModel
    {
        public int BasketId { get; set; }
        public string BasketName { get; set; }
        public ObservableCollection<ProductItem> ProductItems { get; set; }
    }

    public class ProductItem
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public string ProductImage { get; set; }
    }
}
