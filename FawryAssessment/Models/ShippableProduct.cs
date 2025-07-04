using FawryAssesment.Interfaces;

namespace FawryAssesment.Models;

public class ShippableProduct : Product, IShippableProduct
{
    public double Weight { get; set; }
    public ShippableProduct(string name, double price, int quantity, double weight, DateTime? expirationDate = null)
        : base(name, price, quantity, expirationDate)
    {
        Weight = weight;
    }

    public double GetWeight()
    {
        return Weight;
    }

    public string GetName()
    {
        return Name;
    }
}
