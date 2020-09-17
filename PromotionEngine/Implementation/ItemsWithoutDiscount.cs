using PromotionEngine.Contracts;
using PromotionEngine.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Implementation
{
    public static class ItemsWithoutDiscount 
    {
        public static decimal ApplyPromotion(List<ProductToBuy> productsToBuy, decimal finalPrice)
        {
            productsToBuy.ForEach(obj =>
            finalPrice += (obj.Product.Price * obj.count)
            );
            return finalPrice;
        }
    }
}
