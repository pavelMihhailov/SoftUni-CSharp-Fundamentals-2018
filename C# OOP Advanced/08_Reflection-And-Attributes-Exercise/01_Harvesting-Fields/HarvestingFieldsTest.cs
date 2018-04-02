 using System.Collections.Generic;
 using System.Linq;
 using System.Reflection;

namespace P01_HarvestingFields
{
    using System;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var type = typeof(HarvestingFields);
            var allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            while (true)
            {
                var command = Console.ReadLine();
                if (command.Equals("HARVEST")) break;

                IEnumerable<FieldInfo> fieldsToPrint = null;

                switch (command)
                {
                    case "public":
                        fieldsToPrint = allFields.Where(x => x.IsPublic);
                        break;
                    case "private":
                        fieldsToPrint = allFields.Where(x => x.IsPrivate);
                        break;
                    case "protected":
                        fieldsToPrint = allFields.Where(x => x.IsFamily);
                        break;
                    case "all":
                        fieldsToPrint = allFields;
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    Print(field);
                }
            }
        }

        public static void Print(FieldInfo field)
        {
            if (field.IsPublic) Console.WriteLine($"public {field.FieldType.Name} {field.Name}");
            if (field.IsFamily) Console.WriteLine($"protected {field.FieldType.Name} {field.Name}");
            if (field.IsPrivate) Console.WriteLine($"private {field.FieldType.Name} {field.Name}");
        }
    }
}
