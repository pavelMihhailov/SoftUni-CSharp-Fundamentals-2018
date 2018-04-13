using Forum.App.Contracts;

public class CategoriesMenuCommand : ICommand
{
    public CategoriesMenuCommand(IMenuFactory menuFactory)
    {
        this.menuFactory = menuFactory;
    }

    private IMenuFactory menuFactory;

    public IMenu Execute(params string[] args)
    {
        string commandName = this.GetType().Name;
        string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

        IMenu menu = this.menuFactory.CreateMenu(menuName);

        return menu;
        
    }
}