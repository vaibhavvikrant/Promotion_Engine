using PromotionEngine.Interface;
using System.Collections.Generic;

namespace PromotionEngine.Contracts
{
    public class SKU
    {
        private readonly List<IPromotion> _appliedPromotion = new List<IPromotion>();
        public string Id { get; set; }
        public decimal OriginalPrice { get; set; }

        public decimal PromotionalPrice
        {
            get 
            {
                decimal promotionalPrice = OriginalPrice;
                return promotionalPrice;
            }
        }
        public SKU(string id, decimal price)
        {
            Id = id;
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
