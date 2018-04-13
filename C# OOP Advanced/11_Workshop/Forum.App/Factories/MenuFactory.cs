using System;
using System.Linq;
using System.Reflection;
using Forum.App.Contracts;

public class MenuFactory : IMenuFactory
{
    public MenuFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    private IServiceProvider serviceProvider;

    public IMenu CreateMenu(string menuName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type menuType = assembly.GetTypes().First(x => x.Name.Equals(menuName + "Menu"));

        if (menuType == null)
            throw new InvalidOperationException("Menu not found!");
        if (!typeof(IMenu).IsAssignableFrom(menuType))
            throw new InvalidOperationException($"{menuType} is not a menu!");

        ParameterInfo[] ctorParams = menuType.GetConstructors().First().GetParameters();
        object[] args = new object[ctorParams.Length];

        for (int i = 0; i < args.Length; i++)
        {
            args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
        }

        IMenu menu = (IMenu)Activator.CreateInstance(menuType, args);
        return menu;
    }
}
