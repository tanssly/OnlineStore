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
        public void ReduceQuantity(int amount)
        {
            if (Quantity >= amount)
            {
                Quantity -= amount;
            }
            else
            {
                throw new ArgumentException("Not enough stock to decrease.");
            }
        }
    }
}
