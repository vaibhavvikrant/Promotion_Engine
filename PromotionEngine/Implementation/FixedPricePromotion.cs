using PromotionEngine.Constants;
using PromotionEngine.Contracts;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PromotionEngine.Implementation
{
    public class FixedPricePromotion : IPromotion
    {
        public decimal PromoPrice { get; set; }
        public decimal PromoItemCount { get; set; }
        public Product Product { get; set; }
        public FixedPricePromotion(Product product, decimal promoPrice, int itemCount)
        {
            Product = product;
            PromoPrice = promoPrice;
            PromoItemCount = itemCount;
        }
       
        public (decimal finalPrice, List<ProductToBuy> productsToBuy) ApplyPromotion(List<ProductToBuy> productsToBuy, decimal finalPrice)
        {
            foreach (var fixedPromotion in Promotions.FixedPricePromotions)
            {
                var fixedPriceApplicableProducts = productsToBuy.Where(obj => obj.Product.Name == fixedPromotion.Product.Name);
                // Calulate no of items in batch for discount
                var batchesOnDiscount = fixedPriceApplicableProducts.Count() / fixedPromotion.PromoItemCount;
                if (batchesOnDiscount > 0)
                {
                    finalPrice = batchesOnDiscount * fixedPromotion.PromoPrice;
                }
                // Calulate no of items in batch for discount
                var itemsNotInDiscount = fixedPromotion.Product.Price % PromoItemCount;
                if (itemsNotInDiscount > 0)
                {
                    finalPrice += batchesOnDiscount * PromoPrice;
                }
                productsToBuy.RemoveAll(obj => fixedPriceApplicableProducts.Select(obj => obj.Product.Name).Contains(obj.Product.Name));
            }
            return (finalPrice, productsToBuy);

        }
    }
}
