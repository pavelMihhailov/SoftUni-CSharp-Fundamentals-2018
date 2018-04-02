using System;

namespace _03BarracksFactory.Core.Commands
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {

    }
}
