using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);          // Adding a new product
        Product ReadById(int id);              // Get product by ID
        List<Product> ReadAll();               // Get all products
        void Update(Product product);          // Update product
        void Delete(int id);
        void DecreaseQuantity(Product product, int quantityToDecrease);
    }
}
