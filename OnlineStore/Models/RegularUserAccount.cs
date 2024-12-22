using OnlineStore.Services;
using OnlineStore.Commands;
using OnlineStore.Data;

namespace OnlineStore.Models;

public class RegularUserAccount : UserAccount
{
    public override Dictionary<string, ICommand> Commands { get; protected set; }

    public RegularUserAccount(
        string name,
        int balance,
        string email,
        string password,
        ShoppingCart cart
    ) : base(name, email, password, balance, cart)
    {
        Commands = new Dictionary<string, ICommand>();
    }
    public override Dictionary<string, ICommand> CreateCommands(
        ProductService productService,
        UserAccountService accountService,
        OrderService orderService)
    {
        return new Dictionary<string, ICommand>
        {
           { "1", new AddBalanceCommand() },
            { "2", new CheckBalanceCommand()},
            { "3", new ViewProductsCommand(productService) },
            { "4", new AddProductToCartCommand(productService, accountService) },
            { "5", new DeleteProductFromCartCommand(accountService)},
            { "6", new ViewCartCommand() },
            { "7", new CreateOrderCommand(orderService, productService) },
            { "8", new ViewOrderHistoryCommand(orderService) },
            { "9", new ExitCommand() }
        };
    }
}