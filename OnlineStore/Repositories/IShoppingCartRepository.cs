using System.Collections.Generic;
using OnlineStore.Models;

namespace OnlineStore.Repositories
{
    public interface IShoppingCartRepository
    {
        void Create(Cart cart);          // Додавання нового продукту
        List<CartItem> ReadAll();               // Отримати всі продукти
        void Update(Product product);          // Оновити продукт
        void Delete(int id);                   // Видалити продукт
    }
}
