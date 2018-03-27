using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    public Lake(IEnumerable<int> stones)
    {
        this.stones = new List<int>(stones);
    }

    private List<int> stones;

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < stones.Count; i += 2)
        {
            yield return stones[i];
        }

        int lastOddIndex = stones.Count - 1;
        if (lastOddIndex % 2 == 0) lastOddIndex--;

        for (int i = lastOddIndex; i > 0; i -= 2)
        {
            yield return stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
