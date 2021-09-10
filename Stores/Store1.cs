using ShoppingBasket;
using Stores.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stores
{
    public class Store1
    {
        private readonly IShoppingBasket _basket;

        public Store1(IShoppingBasket basket)
        {
            _basket = basket ?? throw new ArgumentNullException(nameof(basket));
            _basket.RegisterDiscountMethod(Buy2ButtersGet1Bread50PercentOffDiscount);
        }

        public decimal Buy2ButtersGet1Bread50PercentOffDiscount(ICollection<IProduct> products, decimal total)
        {
            int numberOfButter = products.Count(x => x.Name.Equals("Butter"));
            int numberOfBread = products.Count(x => x.Name.Equals("Bread"));
            int numberOfDiscountedBreads = numberOfButter / 2;
            decimal breadPrice = products.FirstOrDefault(x => x.Name.Equals("Bread")).Price;

            if (numberOfDiscountedBreads >= numberOfBread)
            {
                return total - (numberOfBread * breadPrice * 0.5M);
            }
            else
            {
                return total - (numberOfDiscountedBreads * breadPrice * 0.5M);
            }
        }

        // pomoćna metoda
        public void PrepareBasket()
        {
            _basket.Add(new Store1Product() { Id = 1, Name = "Butter", Price = 0.8M, Description = "Margo" });
            _basket.Add(new Store1Product() { Id = 2, Name = "Butter", Price = 0.8M, Description = "Margo" });
            _basket.Add(new Store1Product() { Id = 3, Name = "Bread", Price = 1M, Description = "Kukuruzni kruh" });
            _basket.Add(new Store1Product() { Id = 4, Name = "Bread", Price = 1M, Description = "Kukuruzni kruh" });
        }
    }
}
