using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        void Create(Product product);          // Додавання нового продукту
        Product ReadtById(int id);            // Отримання продукту за ID
        List<Product> ReadAll();            // Отримання всіх продуктів
        void Update(Product product);       // Оновлення продукту
        void Delete(int id);                // Видалення продукту
    }
}
