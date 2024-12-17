using System.Collections.Generic;
using OnlineStore.Models;
using OnlineStore.Repositories;

namespace OnlineStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Create(Product product)
        {
            _productRepository.Create(product);
        }

        public Product ReadById(int id)
        {
            return _productRepository.ReadById(id);
        }

        public List<Product> ReadAll()
        {
            return _productRepository.ReadAll();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public void DecreaseQuantity(int productId, int quantityToDecrease)
        {
            var product = _productRepository.ReadById(productId);
            if (product == null)
            {
                throw new ArgumentException("Product not found.");
            }

            product.ReduceQuantity(quantityToDecrease);
            _productRepository.Update(product);
        }
    }
}
