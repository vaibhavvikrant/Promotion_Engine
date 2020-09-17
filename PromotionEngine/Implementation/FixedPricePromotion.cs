using PromotionEngine.Interface;

namespace PromotionEngine.Implementation
{
    public class FixedPricePromotion : IPromotion
    {
        public decimal PromoPrice { get; set; }
        public decimal PromoItemCount { get; set; }
        public FixedPricePromotion(decimal promoPrice, int itemCount)
        {
            PromoPrice = promoPrice;
            PromoItemCount = PromoItemCount;
        }
       
        public decimal ApplyPromotion(decimal originalPrice, int originalItemCount)
        {
            decimal finalPrice=0;
            // Calulate no of items in batch for discount
            var batchesOnDiscount = originalItemCount /  PromoItemCount;
            if (batchesOnDiscount > 0)
            {
                finalPrice = batchesOnDiscount * PromoPrice;
            }
            // Calulate no of items in batch for discount
            var itemsNotInDiscount = originalItemCount % PromoItemCount;
            if (itemsNotInDiscount > 0)
            {
                finalPrice += batchesOnDiscount * PromoPrice;
            }
            return finalPrice;
        }
    }
}
