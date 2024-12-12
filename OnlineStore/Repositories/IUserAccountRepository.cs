using OnlineStore.Models;

public interface IUserAccountRepository
{
    void Create(UserAccount account);          // Реєстрація нового користувача
    UserAccount ReadById(int id);              // Отримання користувача за ID
    List<UserAccount> ReadAll();               // Отримання всіх користувачів
    UserAccount ReadByUsername(string username); // Отримання користувача за ім'ям користувача
    void Update(UserAccount updatedAccount);  // Оновлення даних користувача
    void Delete(int id);                      // Видалення користувача
}
