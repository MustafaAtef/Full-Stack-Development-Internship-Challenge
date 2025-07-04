using FawryAssesment.Models;
using FawryAssesment.Services;

namespace FawryAssesment;

public class Program
{
    public static void Main(string[] args)
    {
        // Initialize the e-commerce platform with a shipping cost per kg and shipping service
        ECommercePlatform platform = new ECommercePlatform(12.5, new ShippingService());

        // Initializing products
        Product tv = new Product("TV", 1000.0, 10);
        Product mobileScratchCards = new Product("Mobile Scratch Card", 15.0, 20);
        ShippableProduct cheese = new ShippableProduct("Cheese", 50.0, 30, 200.0, DateTime.Now.AddDays(5));
        ShippableProduct biscuits = new ShippableProduct("Biscuits", 20.0, 50, 350.0);

        // Create a customer
        Customer customer = new Customer("Mostafa Atef", "01122334455", "Cairo, Egypt", 5000.0);

        // Create a cart
        Cart cart = new Cart();

        try
        {
            /*
                cart.AddProduct(tv, 1000);
                platform.Checkout(customer, cart);

                CONSOLE OUTPUT:
                Not enough stock for TV.
            */

            /*
                cart.AddProduct(tv, 7);
                platform.Checkout(customer, cart);
                
                CONSOLE OUTPUT:
                Insufficient balance for checkout.
            */

            /*
                platform.Checkout(customer, cart);
                
                CONSOLE OUTPUT:
                Cart is empty.
            */

            /*
                CART WITHOUT SHIPPABLE PRODUCTS

                cart.AddProduct(tv, 1);
                cart.AddProduct(mobileScratchCards, 3);
                platform.Checkout(customer, cart);
                
                CONSOLE OUTPUT:
                ** Checkout Receipt **
                1x TV                                               $1,000.00
                3x Mobile Scratch Card                              $45.00
                ----------------------------------------------------------------------------------------------------
                Subtotal                                          : $1,045.00
                Shipping                                          : $0.00
                Amount                                            : $1,045.00

                ** Customer Information **
                Name: Mostafa Atef
                Phone: 01122334455
                Address: Cairo, Egypt
                $3,955.00 remaining in balance
            */

            /*
                CART WITH SHIPPABLE PRODUCTS

                cart.AddProduct(tv, 1);
                cart.AddProduct(mobileScratchCards, 3);
                cart.AddProduct(cheese, 2);
                cart.AddProduct(biscuits, 1);
                platform.Checkout(customer, cart);

                CONSOLE OUTPUT:
                ** Shipment Notice **
                2x Cheese                                          400g
                1x Biscuits                                        350g
                Total Package Weight: 0.75 kg

                ** Checkout Receipt **
                1x TV                                               $1,000.00
                3x Mobile Scratch Card                              $45.00
                2x Cheese                                           $100.00
                1x Biscuits                                         $20.00
                ----------------------------------------------------------------------------------------------------
                Subtotal                                          : $1,165.00
                Shipping                                          : $9.38
                Amount                                            : $1,174.38

                ** Customer Information **
                Name: Mostafa Atef
                Phone: 01122334455
                Address: Cairo, Egypt
                $3,825.62 remaining in balance

                ** Shipping the following products: **
                - Cheese (Weight: 400g)
                - Biscuits (Weight: 350g)
            */

            cart.AddProduct(tv, 1);
            cart.AddProduct(mobileScratchCards, 3);
            cart.AddProduct(cheese, 2);
            cart.AddProduct(biscuits, 1);
            platform.Checkout(customer, cart);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
