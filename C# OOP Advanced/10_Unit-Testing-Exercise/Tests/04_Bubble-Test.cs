using NUnit.Framework;

[TestFixture]
public class Bubble_Test
{
    private int[] collection = {2, 4, 1, 3};

    [Test]
    public void SortMethodIsSortingRight()
    {
        Bubble bubble = new Bubble(collection);
        bubble.Sort();

        Assert.That(bubble.List, Is.Ordered.Ascending);
    }
}