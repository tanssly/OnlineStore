﻿
using OnlineStore.Data;
using OnlineStore.Repositories;
using OnlineStore.Services;
using shop;
using shop.commands;
using shop.DB;
using System.Security.Principal;

public class Program
{
    public static Account currentAccount;

    public static void Main(string[] args)
    {
        DbContext db = new DbContext();
        db.Seed();
        AccountRepository accountRepository = new AccountRepository(db);
        ProductRepository productRepository = new ProductRepository(db);
        OrderRepository orderRepository = new OrderRepository(db);

        AccountService accountService = new AccountService(accountRepository);
        ProductService productService = new ProductService(productRepository);
        OrderService orderService = new OrderService(orderRepository);

        var commandUnlogged = new Dictionary<string, ICommand>
        {
            { "1", new CommandRegister(accountService) },
            { "2", new LoginCommand(accountService) },
            { "3", new ExitCommand() }
        };

        Console.WriteLine("Welcome to the Shop Application!");
        Console.WriteLine("Please log in or register to continue.");

        while (true)
        {
            if (currentAccount == null)
            {
                ShowMenu(commandUnlogged);
            }
            else
            {
                Dictionary<string, ICommand> commands = currentAccount.CreateCommands(productService, accountService, orderService);

                ShowMenu(commands);

                if (currentAccount == null)
                {
                    Console.WriteLine("You have logged out.");
                }
            }
        }
    }

    private static void ShowMenu(Dictionary<string, ICommand> commands)
    {
        Console.Clear();

        Console.WriteLine("\nChoose an option:");
        foreach (var entry in commands)
        {
            Console.WriteLine($"{entry.Key}. {entry.Value.ShowInfo()}");
        }

        string input = Console.ReadLine();
        Console.Clear();
        if (commands.TryGetValue(input, out ICommand command))
        {
            try
            {
                command.Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Invalid option, please try again.");
        }
    }
}