using PromotionEngine.Contracts;
using System.Collections.Generic;

namespace PromotionEngine.Interface
{
    public interface IPromotion
    {
        (decimal finalPrice, List<ProductToBuy> productsToBuy) ApplyPromotion(List<ProductToBuy> productsToBuy, decimal finalPrice);
    }
}
