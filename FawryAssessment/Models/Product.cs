namespace FawryAssesment.Models;

public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public Product(string name, double price, int quantity, DateTime? expirationDate = null)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
}

