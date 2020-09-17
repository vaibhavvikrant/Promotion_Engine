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
            var product = new ProductToBuy { Product = Products.ProductA, count = 1 };
            var product1 = new ProductToBuy { Product = Products.ProductB, count = 1 };
            var product2 = new ProductToBuy { Product = Products.ProductC, count = 1 };
            var obj = new SKU(new List<ProductToBuy> { product, product1, product2 });
            var finalPrice = obj.PromotionalPrice;
            Assert.AreEqual(100, finalPrice);

             product = new ProductToBuy { Product = Products.ProductA, count = 5 };
            product1 = new ProductToBuy { Product = Products.ProductB, count = 5 };
            product2 = new ProductToBuy { Product = Products.ProductC, count = 1 };
             obj = new SKU(new List<ProductToBuy> { product, product1, product2 });
             finalPrice = obj.PromotionalPrice;
            Assert.AreEqual(370, finalPrice);

            product = new ProductToBuy { Product = Products.ProductA, count = 3 };
            product1 = new ProductToBuy { Product = Products.ProductB, count = 5 };
            product2 = new ProductToBuy { Product = Products.ProductC, count = 1 };
            var product3 = new ProductToBuy { Product = Products.ProductD, count = 1 };
            obj = new SKU(new List<ProductToBuy> { product, product1, product2, product3 });
            finalPrice = obj.PromotionalPrice;
            Assert.AreEqual(280, finalPrice);
        }
    }
}
