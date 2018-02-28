using System;

public class StartUp
{
    public static void Main()
    {
        IAddCollection addCollection = new AddCollection();
        IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
        MyList myList = new MyList();

        string addCollectionResult = String.Empty;
        string addRemoveCollectionResult = String.Empty;
        string myListResult = String.Empty;

        string[] items = Console.ReadLine().Split();

        foreach (var item in items)
        {
            addCollectionResult += addCollection.Add(item) + " ";
            addRemoveCollectionResult += addRemoveCollection.Add(item) + " ";
            myListResult += myList.Add(item) + " ";
        }

        Console.WriteLine(addCollectionResult.Trim());
        Console.WriteLine(addRemoveCollectionResult.Trim());
        Console.WriteLine(myListResult.Trim());
        
        addRemoveCollectionResult = String.Empty;
        myListResult = String.Empty;
        
        int removeCnt = int.Parse(Console.ReadLine());

        for (int i = 0; i < removeCnt; i++)
        {
            addRemoveCollectionResult += addRemoveCollection.Remove() + " ";
            myListResult += myList.Remove() + " ";
        }

        Console.WriteLine(addRemoveCollectionResult.Trim());
        Console.WriteLine(myListResult.Trim());
    }
}
