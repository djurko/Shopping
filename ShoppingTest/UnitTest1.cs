using NUnit.Framework;
using ShoppingBasket;
using Stores;

namespace ShoppingTest
{
    public class Tests
    {
        private IShoppingBasket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new ShoppingBasket.ShoppingBasket();
        }

        [Test]
        public void TestCalculateTotalWhenBasketEmpty()
        {
            Assert.AreEqual(0M, _basket.CalculateTotal());
        }

        [Test]
        public void TestCalculateTotal()
        {
            Store3 store = new Store3(_basket);
            store.PrepareBasket();
            Assert.AreEqual(9M, _basket.CalculateTotal());
        }
    }
}