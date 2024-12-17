using OnlineStore.Services;
using OnlineStore.Commands;
using OnlineStore.Data;

namespace OnlineStore.Models
{
    public abstract class UserAccount
    {
        private static int _globalId = 1;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
     
        public ShoppingCart Cart { get; set; }
        public abstract Dictionary<string, ICommand> Commands { get; protected set; }

        public UserAccount(string username, string password, string email, int balance, ShoppingCart cart)
        {
            Id = _globalId++;
            Username = username;
            Password = password;
            Email = email;
            Balance = balance;
            Cart = cart;
        }

        public abstract Dictionary<string, ICommand> CreateCommands(
          ProductService productService,
          UserAccountService accountService,
          OrderService orderService);
    }
}
