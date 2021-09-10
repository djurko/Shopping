using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket
{
    public class ShoppingBasket : IShoppingBasket
    {
        private readonly LogService _logService = null;

        private ICollection<IProduct> _products;
        private ICollection<DiscountMethod> _discounts;

        public ICollection<IProduct> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public ICollection<DiscountMethod> Discounts
        {
            get { return _discounts; }
            set { _discounts = value; }
        }

        public ShoppingBasket()
        {
            Products = new List<IProduct>();
            Discounts = new List<DiscountMethod>();
            _logService = new LogService();
        }

        // prva ideja je bila da je moguće izvana kroz konstuktor poslati različite implementacije popusta
        // ali onda sam dodao implementaciju metode RegisterDiscountMethod
        //public ShoppingBasket(ICollection<DiscountMethod> discounts) : this()
        //{
        //    Discounts = discounts;
        //}

        public void Add(IProduct product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotal()
        {
            decimal total = Products.Sum(x => x.Price);
            _logService.LogBasketInfo(Products, Discounts);
            return ApplyDiscounts(Products, total);
        }

        public void RegisterDiscountMethod(DiscountMethod discount)
        {
            Discounts.Add(discount);
        }

        private decimal ApplyDiscounts(ICollection<IProduct> products, decimal total)
        {
            if (Discounts != null)
            {
                foreach (var discount in Discounts)
                {
                    total = discount(products, total);
                }
            }

            return total;
        }
    }

    public delegate decimal DiscountMethod(ICollection<IProduct> products, decimal total);
}
