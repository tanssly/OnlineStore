
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Formats.Tar;

namespace Store
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public List<CartEntry> Items { get; set; } = new();

        public ShoppingCart(List<CartEntry> cartEntries)
        {
            Items = cartEntries;
        }

        public void AddItem(Item item, int quantity)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null");

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            var existingEntry = Items.FirstOrDefault(e => e.Item.Id == item.Id);

            if (existingEntry != null)
            {
                existingEntry.IncreaseQuantity(quantity);
            }
            else
            {
                Items.Add(new CartEntry(item, quantity));
            }
        }

        public void RemoveItem(int itemId)
        {
            var entry = Items.FirstOrDefault(e => e.Item.Id == itemId);
            if (entry != null)
            {
                Items.Remove(entry);
            }
            else
            {
                throw new ArgumentException("Item not found in the cart.", nameof(itemId));
            }
        }

        public void ClearAll()
        {
            Items.Clear();
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(e => e.CalculateEntryPrice());
        }

        public Order CreateOrder(int customerId)
        {
            if (Items == null || Items.Count == 0)
                throw new InvalidOperationException("Shopping cart is empty. Cannot create an order.");

            var products = Items.Select(e => new Product(e.Item.Id, e.Item.Name, e.Item.Price)).ToList();
            var order = new Order(customerId, products);
            return order;
        }
    }
}


public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Item(int id, string name, decimal price)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null");
            Price = price >= 0 ? price : throw new ArgumentException("Price must be non-negative", nameof(price));
        }
    }
}
