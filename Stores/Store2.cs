using ShoppingBasket;
using Stores.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stores
{
    public class Store2
    {
        private readonly IShoppingBasket _basket;

        public Store2(IShoppingBasket basket)
        {
            _basket = basket ?? throw new ArgumentNullException(nameof(basket));
            _basket.RegisterDiscountMethod(Buy3MilkGet1MilkFreeDiscount);
        }

        public decimal Buy3MilkGet1MilkFreeDiscount(ICollection<IProduct> products, decimal total)
        {
            int numberOfMilk = products.Count(x => x.Name.Equals("Milk"));
            int numberOfFreeMilk = numberOfMilk / 3;
            decimal milkPrice = products.FirstOrDefault(x => x.Name.Equals("Milk")).Price;

            if (numberOfMilk >= 4)
            {
                return total - (numberOfFreeMilk * milkPrice);
            }

            return total;
        }

        // pomoćna metoda
        public void PrepareBasket()
        {
            _basket.Add(new Store2Product() { Id = 1, Name = "Milk", Price = 1.15M, Type = Category.Food });
            _basket.Add(new Store2Product() { Id = 2, Name = "Milk", Price = 1.15M, Type = Category.Food });
            _basket.Add(new Store2Product() { Id = 3, Name = "Milk", Price = 1.15M, Type = Category.Food });
            _basket.Add(new Store2Product() { Id = 4, Name = "Milk", Price = 1.15M, Type = Category.Food });
        }
    }
}
