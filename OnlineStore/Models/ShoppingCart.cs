namespace OnlineStore.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public List<CartEntry> Items { get; set; } = new List<CartEntry>();

        public ShoppingCart(List<CartEntry> cartEntries)
        {
            Items = cartEntries ?? new List<CartEntry>();
        }

        public void AddToShoppingCart(Item item, int quantity)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "Item cannot be null.");

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
    }

    public class CartEntry
    {
        public Item Item { get; set; }
        public int Quantity { get; private set; }

        public CartEntry(Item item, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be greater than zero.");
        }

        public decimal CalculateEntryPrice()
        {
            return Item.Price * Quantity;
        }

        public void IncreaseQuantity(int additionalQuantity)
        {
            if (additionalQuantity > 0)
                Quantity += additionalQuantity;
            else
                throw new ArgumentException("Additional quantity must be positive.");
        }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity > 0)
            {
                Quantity = Math.Max(0, Quantity - quantity); 
            }
            else
            {
                throw new ArgumentException("Quantity must be positive.");
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
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            Price = price >= 0 ? price : throw new ArgumentException("Price must be non-negative", nameof(price));
        }
    }
}
