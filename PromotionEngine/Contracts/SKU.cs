using PromotionEngine.Implementation;
using PromotionEngine.Interface;
using System.Collections.Generic;

namespace PromotionEngine.Contracts
{
    public class SKU
    {
        public decimal finalPrice { get; set; }
        List<ProductToBuy> ProductsToBuy { get; set; }
        public decimal PromotionalPrice
        {
            get
            {
                // All the classes implementing IPromotion, their Applypromotion method will be called from here.
                foreach (IPromotion promotion in ApplyPromotion)
                {
                    var response= promotion.ApplyPromotion(ProductsToBuy, finalPrice);
                    ProductsToBuy = response.productsToBuy;
                    finalPrice = response.finalPrice;
                }
                finalPrice = ItemsWithoutDiscount.ApplyPromotion(ProductsToBuy, finalPrice);
                return finalPrice;
            }
        }
        public SKU(List<ProductToBuy> productsToBuy)
        {
            ProductsToBuy = productsToBuy;
        }

        public List<IPromotion> ApplyPromotion
        {
            //Add all the new implementation of IPromotion
            get
            {
                IPromotion fixedPricePromotion = new FixedPricePromotion();
                IPromotion fixedPricePromotionType2 = new FixedPricePromotionaType2();
                return new List<IPromotion> { fixedPricePromotion, fixedPricePromotionType2 };
            }
        }
    }
}
