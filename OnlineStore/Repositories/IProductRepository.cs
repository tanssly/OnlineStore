using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);   
        Product ReadById(int id);           
        List<Product> ReadAll();              
        void Update(Product product);         
        void Delete(int id);
        void DecreaseQuantity(Product product, int quantityToDecrease);
    }
}
