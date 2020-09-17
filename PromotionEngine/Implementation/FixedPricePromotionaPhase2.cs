using PromotionEngine.Constants;
using PromotionEngine.Contracts;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Implementation
{
    public class FixedPricePromotionaPhase2 : IPromotion
    {
        public (decimal finalPrice, List<ProductToBuy> productsToBuy) ApplyPromotion(List<ProductToBuy> productsToBuy, decimal finalPrice)
        {
            foreach (var fixedPromotion in Promotions.FixedPricePromotionsPhase2)
            {
                var fixedPriceApplicableProducts = productsToBuy.Where(obj => obj.Product.Name == fixedPromotion.Product.Name);
                if (fixedPriceApplicableProducts != null && fixedPriceApplicableProducts.Any())
                {
                    // Calulate no of items in batch for discount
                    var batchesOnDiscount = fixedPriceApplicableProducts.FirstOrDefault()?.count / fixedPromotion.PromoItemCount;
                    if (batchesOnDiscount > 0)
                    {
                        finalPrice += batchesOnDiscount.Value * fixedPromotion.PromoPrice;
                    }
                    // Calulate no of items in batch for discount
                    var itemsNotInDiscount = fixedPriceApplicableProducts.FirstOrDefault()?.count % fixedPromotion.PromoItemCount;
                    if (itemsNotInDiscount > 0)
                    {
                        finalPrice += itemsNotInDiscount.Value * fixedPromotion.Product.Price;
                    }
                    productsToBuy.RemoveAll(obj => fixedPriceApplicableProducts.Select(obj => obj.Product.Name).Contains(obj.Product.Name));
                }
            }
            return (finalPrice, productsToBuy);
        }
    }
}
