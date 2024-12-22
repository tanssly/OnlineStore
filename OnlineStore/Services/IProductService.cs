using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        void Create(Product product);          
        Product ReadById(int id);             
        List<Product> ReadAll();             
        void Update(Product product);   
        void Delete(int id);            
        void DecreaseQuantity(int productId, int quantityToDecrease); 
    }
}
