using NUnit.Framework;
using System.Collections.Generic;
using PromotionEngine.Contracts;
using PromotionEngine.Constants;

namespace PromotionEngineTest
{
    [TestFixture]
    public class PromotionEngineTest
    {
        [Test]
        public void FixedPriceTest()
        {
            var product = new ProductToBuy { Product = Products.ProductA, count = 5 };
            SKU obj = new SKU(new List<ProductToBuy> { product });
            var finalPrice = obj.PromotionalPrice;

        }
    }
}
