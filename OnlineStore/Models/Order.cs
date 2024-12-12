using System.Formats.Tar;

namespace OnlineStore.Models
{
    public class Order
    {
        private static int _globalID = 1;
        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public decimal OrderPrice { get; private set; }
        public string OrderDate { get; private set; }
        public string OrderTime { get; private set; }
        public int OrderStatus { get; set; }
        public List<CartEntry> Products { get; private set; }

        public Order(int customerId, List<Product> products)
        {
            if (products == null || products.Count == 0)
                throw new ArgumentException("Products cannot be null or empty.", nameof(products));

            OrderId = GetNextId();
            CustomerId = customerId;
            Products = products.Select(p => new CartEntry(p, 1)).ToList(); // За замовчуванням 1 шт. кожного продукту.
            OrderPrice = CalculateOrderPrice();
            OrderDate = DateTime.Now.ToString("yyyy-MM-dd");
            OrderTime = DateTime.Now.ToString("HH:mm:ss");
            OrderStatus = 0; // 0 означає "Очікування".
        }

        private static int GetNextId()
        {
            return _globalID++;
        }

        private decimal CalculateOrderPrice()
        {
            return Products.Sum(p => p.Item.Price * p.Quantity);
        }
    }
}
