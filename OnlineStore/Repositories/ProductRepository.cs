using System.Collections.Generic;
using OnlineStore.Models;
using OnlineStore.Data;

namespace OnlineStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Create(Product product)
        {
            _databaseContext.Products.Add(product);
        }

        public Product ReadById(int id)
        {
            return _databaseContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> ReadAll()
        {
            return _databaseContext.Products.Count == 0? null : _databaseContext.Products.ToList();
        }

        public void Update(Product product)
        {
            var existingProduct = _databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
            }
            else
            {
                {
                    throw new ArgumentException("Product not fpund.");
                }
            }
        }

        public void Delete(int id)
        {
            var product = ReadById(productId);

            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            if (product.quantity < quantityToDecrease)
            {
                throw new ArgumentException("Not enough stock to decrease.");
            }

            product.quantity -= quantityToDecrease;
            Update(product);
        }
    }
}
