using FawryAssesment.Interfaces;

namespace FawryAssesment.Models;

public class ShippableCartItem : CartItem, IShippableProduct
{
    public double Weight { get; set; }
    public ShippableCartItem(ShippableProduct product, int quantity) : base(product, quantity)
    {
        Weight = product.GetWeight() * quantity;
    }

    public double GetWeight()
    {
        return Weight;
    }

    public string GetName()
    {
        return Product.Name;
    }
}
