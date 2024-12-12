using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Repositories
{
    public interface IProductRepository
    {
        void Create(Product product);          // Додавання нового продукту
        Product ReadById(int id);              // Отримати продукт за ID
        List<Product> ReadAll();               // Отримати всі продукти
        void Update(Product product);          // Оновити продукт
        void Delete(int id);                   // Видалити продукт
    }
}
