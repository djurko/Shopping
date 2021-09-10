using ShoppingBasket;

namespace Stores.Models
{
    public class Store2Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Category Type { get; set; }
    }

    public enum Category
    {
        Food,
        Tools,
        Toys
    }
}
