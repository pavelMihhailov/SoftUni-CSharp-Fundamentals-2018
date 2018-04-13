using System;
using Forum.App.Contracts;

public class LogInCommand : ICommand
{
    private IUserService userService;
    private IMenuFactory menuFactory;

    public IMenu Execute(params string[] args)
    {
        string username = args[0];
        string password = args[1];

        bool success = userService.TryLogInUser(username, password);

        if (!success)
            throw new InvalidOperationException("Invalid login!");

        return menuFactory.CreateMenu("MainMenu");
    }
}
