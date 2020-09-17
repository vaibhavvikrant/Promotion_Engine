using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Contracts;

namespace PromotionEngineTest
{
    [TestFixture]
    public class PromotionEngineTest
    {
        [Test]
        public void FixedPriceTest()
        {
            var product = new ProductToBuy { Product = Products.ProductA, count = 5 };
            var product1 = new ProductToBuy { Product = Products.ProductB, count = 5 };
            var product2 = new ProductToBuy { Product = Products.ProductC, count = 1 };
            var obj = new SKU(new List<ProductToBuy> { product, product1, product2 });
            var finalPrice = obj.PromotionalPrice;
            Assert.AreEqual(0, finalPrice);
        }
    }
}
