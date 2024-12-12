using OnlineStore.Services;
using System;
using System.Collections.Generic;
using System.Data;

namespace OnlineStore.Models
{
    public abstract class UserAccount
    {
        public int Id { get; protected set; }
        private static int _globalId = 1;
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public DateTime DateRegistred { get; set; }
        public DateTime LastLoginDate { get; set; }
        public List<PurchaseHistory> PurchaseHistory { get; set; }
        public bool IsAdmin => Role == "Admin";
        public bool IsRegularUser => Role == "Tanya";


        public UserAccount(string username, string password, string role, string email, decimal initialBalance)
        {
            Id = _globalId++;
            Username = username;
            Password = password;
            Balance = initialBalance;
            Role = "User";
            PurchaseHistory = new List<PurchaseHistory>();
            DateRegistred = DateTime.Now;
            Email = Email;
        }

        public abstract Dictionary<string, ICommand> CreateCommands(
          ProductService productService,
          UserAccountService accountService,
          OrderService orderService);
    }
}
