namespace FawryAssesment.Models;

class Cart
{
    public double SubTotal { get; set; }
    public bool HasShippableProducts { get; set; } = false;
    public double TotalWeight { get; set; }
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    public void AddProduct(Product product, int quantity)
    {
        if (product.ExpirationDate.HasValue && product.ExpirationDate.Value < DateTime.Now)
        {
            throw new Exception($"{product.Name} is expired and cannot be added to the cart.");
        }
        if (product.Quantity < quantity)
        {
            throw new Exception($"Not enough stock for {product.Name}.");
        }
        SubTotal += product.Price * quantity;
        product.Quantity -= quantity;
        if (product is ShippableProduct shippableProduct)
        {
            HasShippableProducts = true;
            TotalWeight += shippableProduct.GetWeight() * quantity;
            Items.Add(new ShippableCartItem(shippableProduct, quantity));
        }
        else
            Items.Add(new CartItem(product, quantity));
    }
}
