using OnlineStore.Data;

namespace OnlineStore.Commands;

public interface ICommand
{
    void Execute();
    string ShowInfo();
}

public class ExitCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Exiting the application. Goodbye!");
        Environment.Exit(0);
    }

    public string ShowInfo()
    {
        return "Exit the application.";
    }
}
