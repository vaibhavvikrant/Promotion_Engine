namespace PromotionEngine.Interface
{
    public interface IPromotion
    {
        decimal ApplyPromotion(decimal originalPrice, int originalItemCount);
    }
}
