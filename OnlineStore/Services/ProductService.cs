using System.Collections.Generic;
using OnlineStore.Models;
using OnlineStore.Repositories;

namespace OnlineStore.Services
{
    public class ProductService
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

        public Product ReadtById(int id)
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
        public void DecreaseQuantity (int productId, int quantityToDecrease)
        {
            ProductRepository.DecreaseQuantity(productId, quantityToDecrease);
        }
    }
}
