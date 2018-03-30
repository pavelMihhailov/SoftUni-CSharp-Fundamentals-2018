using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] testClassFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        Object instanceOfClass = Activator.CreateInstance(classType, new object[] {});

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {classType}");
        foreach (var field in testClassFields)
        {
            if (fieldsNames.Contains(field.Name))
                sb.AppendLine($"{field.Name} = {field.GetValue(instanceOfClass)}");
        }
        
        return sb.ToString().TrimEnd();
    }
}
