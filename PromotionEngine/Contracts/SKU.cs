using PromotionEngine.Interface;
using System.Collections.Generic;

namespace PromotionEngine.Contracts
{
    public class SKU
    {
        private readonly List<IPromotion> _appliedPromotion = new List<IPromotion>();
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }

        public decimal PromotionalPrice
        {
            get 
            {
                decimal promotionalPrice = OriginalPrice;
                foreach (IPromotion promotion in _appliedPromotion)
                {
                    promotionalPrice = promotion.ApplyPromotion(promotionalPrice, OriginalItemCount);
                }
                return promotionalPrice;
            }
        }
        public SKU(string name, decimal price)
        {
            Name = name;
            OriginalPrice = price;
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
