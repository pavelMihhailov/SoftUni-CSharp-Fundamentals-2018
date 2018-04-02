using System;

public class StartUp
{
    static void Main()
    {
        Type typeWeapon = typeof(Weapon);

        while (true)
        {
            string input = Console.ReadLine();
            if (input.Equals("END")) break;

            CustomAttribute attribute = (CustomAttribute) Attribute.GetCustomAttribute(typeWeapon, typeof(CustomAttribute));
            string result = Print(input, attribute);
            Console.WriteLine(result);
        }
    }

    private static string Print(string input, CustomAttribute attribute)
    {
        switch (input)
        {
            case "Author":
                return $"Author: {attribute.Author}";
            case "Revision":
                return $"Revision: {attribute.Revision}";
            case "Description":
                return $"Description: {attribute.Description}";
            case "Reviewers":
                return "Reviewers: " + string.Join(", ", attribute.Reviewers);
        }
        return null;
    }
}
