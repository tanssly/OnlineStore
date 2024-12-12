﻿using OnlineStore.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Commands

namespace OnlineStore.Models;

public class AdminAccount : UserAccount
{
    public override Dictionary<string, ICommand> Commands { get; protected set; }

    public AdminAccount(
        string name,
        int balance,
        string email,
        string password,
        Cart cart
    ) : base(name, balance, email, password, cart)
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
            { "1", new AddProductCommand(productService) },
            { "2", new DeleteProductCommand(productService) },
            { "3", new UpdateProductCommand(productService) },
            { "4", new ViewProductsCommand(productService) },
            { "5", new ViewAllOrderHistoryCommand(orderService) },
            { "6", new ViewAllAccountsCommand(accountService)},
            { "7", new DeleteUserAccountCommand(accountService) },
            { "8", new LogoutCommand() },
            { "9", new ExitCommand() }
        };
    }
}