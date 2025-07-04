namespace FawryAssesment.Models;

class Customer
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public double Balance { get; set; }
    public Customer(string name, string phone, string address, double balance)
    {
        Name = name;
        Phone = phone;
        Address = address;
        Balance = balance;
    }
}

