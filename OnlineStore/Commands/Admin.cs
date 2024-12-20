using OnlineStore.Models;
using OnlineStore.Services;
using OnlineStore.Data;

namespace OnlineStore.Commands
{
    public class AddProductCommand : ICommand
    {
        private ProductService _productService;

        public AddProductCommand(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter product description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter product price: ");
            if (!int.TryParse(Console.ReadLine(), out int price) || price <= 0)
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            Console.WriteLine("Enter product quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            Product newProduct = new Product(name, price, quantity); 
            _productService.Create(newProduct);
            Console.WriteLine("Product added successfully.");
        }

        public string ShowInfo()
        {
            return "Add Product";
        }
    }

    public class DeleteProductCommand : ICommand
    {
        private ProductService _productService;

        public DeleteProductCommand(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter product ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _productService.ReadById(productId);
                if (product != null)
                {
                    _productService.Delete(productId);
                    Console.WriteLine($"Product {product.Name} deleted successfully."); 
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID.");
            }
        }

        public string ShowInfo()
        {
            return "Delete Product";
        }
    }

    public class UpdateProductCommand : ICommand
    {
        private ProductService _productService;

        public UpdateProductCommand(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter product ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                var product = _productService.ReadById(productId);
                if (product != null)
                {
                    Console.WriteLine($"Updating product {product.Name}");

                    Console.WriteLine("Enter new product name (leave blank to keep current): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        product.Name = newName; 
                    }

                    Console.WriteLine("Enter new price (leave blank to keep current): ");
                    string priceInput = Console.ReadLine();
                    if (int.TryParse(priceInput, out int newPrice) && newPrice > 0)
                    {
                        product.Price = newPrice; 
                    }

                    Console.WriteLine("Enter new quantity (leave blank to keep current): ");
                    string quantityInput = Console.ReadLine();
                    if (int.TryParse(quantityInput, out int newQuantity) && newQuantity >= 0)
                    {
                        product.Quantity = newQuantity; 
                    }

                    _productService.Update(product);
                    Console.WriteLine("Product updated successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid product ID.");
            }
        }

        public string ShowInfo()
        {
            return "Update Product";
        }
    }

    public class ViewAllOrderHistoryCommand : ICommand
    {
        private readonly OrderService _orderService;

        public ViewAllOrderHistoryCommand(OrderService orderService)
        {
            _orderService = orderService;
        }

        public void Execute()
        {
            var orders = _orderService.ReadAll();
            if (orders.Count == 0)
            {
                Console.WriteLine("No orders found.");
                return;
            }

            Console.WriteLine("All orders:");
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId} | Account ID: {order.CustomerId} | Date: {order.OrderDate} | Status: {order.OrderStatus}");
                foreach (var item in order.Products)
                {
                    Console.WriteLine($"  - Product: {item.Item.Name} | Price: {item.Item.Price}");
                }
            }
        }

        public string ShowInfo()
        {
            return "View All Orders";
        }
    }

    public class DeleteUserAccountCommand : ICommand
    {
        private UserAccountService _accountService;

        public DeleteUserAccountCommand(UserAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Execute()
        {
            Console.WriteLine("Enter the username of the account to delete: ");
            string username = Console.ReadLine();

            var account = _accountService.GetUserByUsername(username);
            if (account != null && !(account is AdminAccount))
            {
                _accountService.DeleteUser(account.Id); 
                Console.WriteLine($"Account for {username} deleted successfully.");
            }
            else if (account is AdminAccount)
            {
                Console.WriteLine("Cannot delete admin account.");
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public string ShowInfo()
        {
            return "Delete User Account";
        }
    }

    public class ViewAllAccountsCommand : ICommand
    {
        private UserAccountService _accountService;

        public ViewAllAccountsCommand(UserAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Execute()
        {
            var accounts = _accountService.GetAllUsers();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
            }
            else
            {
                Console.WriteLine("List of all accounts:");
                foreach (var account in accounts)
                {
                    Console.WriteLine($"ID: {account.Id}, Name: {account.Username}, Email: {account.Email}, Balance: {account.Balance}");
                }
            }
        }

        public string ShowInfo()
        {
            return "View all accounts.";
        }
    }
}
