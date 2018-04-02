using System.Linq;
using System.Reflection;

namespace P02_BlackBoxInteger
{
    using System;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var instance = Activator.CreateInstance(type, true);

            while (true)
            {
                var command = Console.ReadLine().Split('_');
                if (command[0].Equals("END")) break;

                var methodCommand = command[0];
                int value = int.Parse(command[1]);

                MethodInfo method = methods.First(x => x.Name == methodCommand);

                method.Invoke(instance, new object[] {value});
                Console.WriteLine(innerValue.GetValue(instance));
            }
        }
    }
}
