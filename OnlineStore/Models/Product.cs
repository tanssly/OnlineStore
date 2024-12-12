using OnlineStore.Models;

namespace OnlineStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        private static int _globalId = 1;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
       


        public Product(string name, decimal price, int quantity)
        {

            Id = _globalId++;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        // Метод для зменшення кількості товару після покупки
        public void ReduceQuantity()
        {
            if (Quantity > 0)
            {
                Quantity--;
            }
        }
    }
}

public class CartItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalPrice => Product.Price * Quantity;
}

public class Cart
{
    private readonly List<CartItem> _items = new List<CartItem>();

    public void AddItem(Product product, int quantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Id == product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new CartItem(product, quantity));
        }
    }

    public void UpdateItem(int productId, int quantity)
    {
        var existingItem = _items.FirstOrDefault(item => item.Product.Id == productId);

        if (existingItem != null)
        {
            if (quantity <= 0)
            {
                _items.Remove(existingItem);
            }
            else
            {
                existingItem.Quantity = quantity;
            }
        }
    }

    public void ViewCart()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Cart is empty.");
            return;
        }

        Console.WriteLine("Your cart items:");
        foreach (var item in _items)
        {
            Console.WriteLine($"{item.Product.Name} - {item.Quantity} x {item.Product.Price:C} = {item.TotalPrice:C}");
        }

        Console.WriteLine($"Total: {GetTotalPrice():C}");
    }

    public decimal GetTotalPrice()
    {
        return _items.Sum(item => item.TotalPrice);
    }

    public void Checkout()
    {
        if (_items.Count == 0)
        {
            Console.WriteLine("Your cart is empty. Add some items before checkout.");
            return;
        }

        Console.WriteLine("Processing your order...");
        Console.WriteLine($"Total amount to pay: {GetTotalPrice():C}");
        _items.Clear();
        Console.WriteLine("Order completed successfully!");
    }
}
