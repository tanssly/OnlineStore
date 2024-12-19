using System;
using System.Collections.Generic;
using System.Linq;

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
        public string OrderStatus { get; set; }
        public List<CartEntry> Products { get; private set; }

        public Order(int customerId, List<CartEntry> cartEntries)
        {
            if (cartEntries == null || !cartEntries.Any())
                throw new ArgumentException("Cart entries cannot be null or empty.", nameof(cartEntries));

            OrderId = GetNextId();
            CustomerId = customerId;
            Products = cartEntries;
            OrderPrice = CalculateOrderPrice();
            OrderDate = DateTime.Now.ToString("yyyy-MM-dd");
            OrderTime = DateTime.Now.ToString("HH:mm:ss");
            OrderStatus = "Pending";
        }

        private static int GetNextId()
        {
            return _globalID++;
        }

        public decimal CalculateOrderPrice()
        {
            return Products.Sum(p => p.Item.Price * p.Quantity);
        }
    }
}
