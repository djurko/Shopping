using ShoppingBasket;

namespace Stores.Models
{
    public class Store1Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
