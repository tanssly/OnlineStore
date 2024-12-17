using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        void Create(Product product);          // Adding a new product
        Product ReadById(int id);              // Get product by ID
        List<Product> ReadAll();               // Get all products
        void Update(Product product);          // Update product
        void Delete(int id);                   // Delete product
        void DecreaseQuantity(int productId, int quantityToDecrease); // Decrease product quantity
    }
}
