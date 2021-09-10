using ShoppingBasket;
using Stores.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stores
{
    public class Store3
    {
        private readonly IShoppingBasket _basket;

        public Store3(IShoppingBasket basket)
        {
            _basket = basket ?? throw new ArgumentNullException(nameof(basket));
            _basket.RegisterDiscountMethod(Buy2ButtersGet1Bread50PercentOffDiscount);
            _basket.RegisterDiscountMethod(Buy3MilkGet1MilkFreeDiscount);
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

        // pomoćne metode
        public void PrepareBasket()
        {
            _basket.Add(new Store3Product() { Id = 1, Name = "Butter", Price = 0.8M, Description = "Margo", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 2, Name = "Butter", Price = 0.8M, Description = "Margo", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 3, Name = "Bread", Price = 1M, Description = "Kukuruzni kruh", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 4, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 5, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 6, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 7, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 8, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 9, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 10, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 11, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
        }

        public void PrepareBasketWithoutDiscounts()
        {
            _basket.Add(new Store3Product() { Id = 1, Name = "Butter", Price = 0.8M, Description = "Margo", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 2, Name = "Bread", Price = 1M, Description = "Kukuruzni kruh", Type = Category.Food });
            _basket.Add(new Store3Product() { Id = 3, Name = "Milk", Price = 1.15M, Description = "Dukat", Type = Category.Food });
        }
    }
}
