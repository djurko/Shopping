using System.Collections.Generic;

namespace ShoppingBasket
{
    public interface IShoppingBasket
    {
        void Add(IProduct product);
        decimal CalculateTotal();
        void RegisterDiscountMethod(DiscountMethod discount);
    }
}
