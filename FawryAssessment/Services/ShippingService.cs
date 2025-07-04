
using FawryAssesment.Interfaces;

namespace FawryAssesment.Services;

public class ShippingService
{
    public void Ship(List<IShippableProduct> shippableProducts)
    {
        Console.WriteLine();
        Console.WriteLine("** Shipping the following products: **");
        foreach (var product in shippableProducts)
        {
            Console.WriteLine($"- {product.GetName()} (Weight: {product.GetWeight()}g)");
        }
    }
}
