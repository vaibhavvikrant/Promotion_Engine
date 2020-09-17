using PromotionEngine.Constants;
using PromotionEngine.Contracts;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Implementation
{
    public class FixedPricePromotionaType2 : IPromotion
    {
        public (decimal finalPrice, List<ProductToBuy> productsToBuy) ApplyPromotion(List<ProductToBuy> productsToBuy, decimal finalPrice)
        {
            foreach (var fixedPromotion in Promotions.FixedPricePromotionsType2)
            {

                //find all eleigible records in loop
                var allProducts = fixedPromotion.Products;
                var eligibleProducts = new List<ProductToBuy>();
                foreach (var prod  in productsToBuy)
                {
                    if (allProducts.Any(obj => obj.Name == prod.Product.Name))
                    {
                        allProducts.Remove(prod.Product);
                        eligibleProducts.Add(prod);
                    }
                }

                if (allProducts == null || allProducts.Count==0)
                {
                    // Calulate no of items in batch for discount
                    var batchesOnDiscount = eligibleProducts.GroupBy(obj => obj.Product).Select(obj=> new { obj.Key, count = obj.Count(), obj });
                    var minBatch = batchesOnDiscount.OrderBy(obj => obj.count).FirstOrDefault();
                    finalPrice += fixedPromotion.PromoPrice * minBatch.count;


                    //// Calulate price of remaining items of eleible products
                    eligibleProducts.ForEach(
                       obj => finalPrice +=  obj.Product.Price * (obj.count - minBatch.count)
                    );

                    productsToBuy.RemoveAll(obj => eligibleProducts.Select(obj => obj.Product.Name).Contains(obj.Product.Name));
                }
            }
            return (finalPrice, productsToBuy);
        }
    }
}
