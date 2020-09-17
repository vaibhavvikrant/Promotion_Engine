using PromotionEngine.Constants;
using PromotionEngine.Contracts;
using System.Collections.Generic;

namespace PromotionEngine.Constants
{
    public class Promotions
    {
        public static List<Promotion> FixedPricePromotions { get; } = new List<Promotion>
        {
            {new Promotion{ Product= Products.ProductA, PromoItemCount = 3, PromoPrice= 130} },
            {new Promotion{ Product= Products.ProductB, PromoItemCount =23, PromoPrice= 45} },
        };
    }
}
