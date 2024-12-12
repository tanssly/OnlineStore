using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public class DatabaseContext
    {
        public List<UserAccount> Users { get; set; } = new List<UserAccount>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();

        public DatabaseContext()
        {
            Products.Add(new Product("Laptop", 1200.00m, 10));
            Products.Add(new Product("Smartphone", 800.00m, 15));
            Products.Add(new Product("Headphones", 150.00m, 30));
            Products.Add(new Product("Tablet", 400.00m, 20));
            Products.Add(new Product("Smartwatch", 250.00m, 25));
            Products.Add(new Product("Gaming Console", 500.00m, 12));
            Products.Add(new Product("Wireless Mouse", 50.00m, 50));
            Products.Add(new Product("Keyboard", 75.00m, 40));
            Products.Add(new Product("External Hard Drive", 100.00m, 30));
            Products.Add(new Product("Monitor", 300.00m, 18));
            Products.Add(new Product("Printer", 200.00m, 8));
            Products.Add(new Product("Camera", 900.00m, 5));
            Users.Add(new AdminAccount("Tetyana", 50000.00m, "2501tsaul@gmail.com", "admin", new Cart(new List<CartItem>())));

          
        }
    }
}
