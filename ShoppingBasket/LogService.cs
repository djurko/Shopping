using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class LogService
    {
        public void LogBasketInfo(ICollection<IProduct> products, ICollection<DiscountMethod> discounts)
        {
            Console.WriteLine();
            Console.WriteLine("//    LOG SERVICE INFO BEGIN   //");
            foreach (var product in products)
            {
                Console.WriteLine($"Product name: {product.Name}, Product price: {product.Price:C2}");
            }
            foreach (var discount in discounts)
            {
                Console.WriteLine($"Discount name: {discount.Method.Name}");
            }
            Console.WriteLine($"Total sum of the basket before discounts: {products.Sum(x => x.Price):C2}");
            Console.WriteLine("//    LOG SERVICE INFO END   //");
            Console.WriteLine();
        }
    }
}
