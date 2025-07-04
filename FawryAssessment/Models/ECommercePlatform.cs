

using FawryAssesment.Interfaces;
using FawryAssesment.Services;

namespace FawryAssesment.Models;

class ECommercePlatform
{
    public double ShippingCostPerKg { get; set; }
    private readonly ShippingService? _shippingService;
    public ECommercePlatform(double shippingCostPerKg, ShippingService? shippingService)
    {
        ShippingCostPerKg = shippingCostPerKg;
        _shippingService = shippingService;
    }
    public void Checkout(Customer customer, Cart cart)
    {
        if (cart.Items.Count == 0)
        {
            throw new Exception("Cart is empty.");
        }

        double shippingCost = cart.TotalWeight / 1000 * ShippingCostPerKg;
        double totalAmount = cart.SubTotal + shippingCost;
        if (totalAmount > customer.Balance)
        {
            throw new Exception("Insufficient balance for checkout.");
        }
        customer.Balance -= totalAmount;
        List<IShippableProduct> shippableProducts = new List<IShippableProduct>();
        if (cart.HasShippableProducts)
        {
            Console.WriteLine("** Shipment Notice **");
            foreach (var item in cart.Items)
            {
                if (item is IShippableProduct shippableProduct)
                {
                    shippableProducts.Add(shippableProduct);
                    Console.WriteLine($"{item.Quantity + "x " + shippableProduct.GetName(),-50} {shippableProduct.GetWeight()}g");
                }
            }
            Console.WriteLine($"Total Package Weight: {cart.TotalWeight / 1000} kg");
            Console.WriteLine();
        }

        Console.WriteLine("** Checkout Receipt **");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"{item.Quantity + "x " + item.Product.Name,-50}  {item.Product.Price * item.Quantity:C}");
        }
        for (int i = 0; i < 100; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
        Console.WriteLine($"{"Subtotal",-50}: {cart.SubTotal:C}");
        Console.WriteLine($"{"Shipping",-50}: {shippingCost:C}");
        Console.WriteLine($"{"Amount",-50}: {totalAmount:C}");
        Console.WriteLine();
        Console.WriteLine("** Customer Information **");
        Console.WriteLine($"Name: {customer.Name}");
        Console.WriteLine($"Phone: {customer.Phone}");
        Console.WriteLine($"Address: {customer.Address}");
        Console.WriteLine($"{customer.Balance:C} remaining in balance");
        if (cart.HasShippableProducts)
            _shippingService?.Ship(shippableProducts);
    }
}

