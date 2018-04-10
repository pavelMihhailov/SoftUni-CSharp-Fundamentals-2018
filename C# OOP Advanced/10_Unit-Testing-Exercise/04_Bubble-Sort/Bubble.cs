using System.Collections.Generic;

public class Bubble
{
    public List<int> List;

    public Bubble(IEnumerable<int> numbers)
    {
        List = new List<int>(numbers);
    }

    public void Sort()
    {
        bool sorted;
        do
        {
            sorted = true;
            for (int i = 0; i < List.Count - 1; i++)
            {
                if (List[i] > List[i + 1])
                {
                    var temp = List[i + 1];
                    List[i + 1] = List[i];
                    List[i] = temp;
                    sorted = false;
                }
            }
        } while (!sorted);
    }
}
