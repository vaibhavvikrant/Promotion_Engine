using PromotionEngine.Interface;
using System.Collections.Generic;

namespace PromotionEngine.Contracts
{
    public class SKU
    {
        public List<IPromotion> _appliedPromotion = new List<IPromotion>();
        public decimal finalPrice { get; set; }
        List<ProductToBuy> ProductsToBuy { get; set; }
        public decimal PromotionalPrice
        {
            get
            {
                 
                foreach (IPromotion promotion in _appliedPromotion)
                {
                    var response= promotion.ApplyPromotion(ProductsToBuy, finalPrice);
                    ProductsToBuy = response.productsToBuy;
                    finalPrice = response.finalPrice;
                }
                return finalPrice;
            }
        }
        public SKU(List<ProductToBuy> productsToBuy)
        {
            ProductsToBuy = productsToBuy;
        }

        public List<IPromotion> ApplyPromotion
        {
            get
            {
                return _appliedPromotion;
            }
        }
    }
}
