using NUnit.Framework;

[TestFixture]
public class _01_Database_Test
{
    private Database db;
    private int[] integers;
    private int elementToAdd = 1;
    
    [Test]
    public void ConstructorShouldNotInitilizeMoreThan16Elements()
    {
        integers = new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        
        Assert.That(() => new Database(integers),
            Throws.InvalidOperationException.With.Message.EqualTo("Integers should be 16."));
    }

    [Test]
    public void AddMethodShouldThrowExceptionIfArrayIsFull()
    {
        integers = new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        db = new Database(integers);

        Assert.That(() => db.AddElement(elementToAdd), 
            Throws.InvalidOperationException.With.Message.EqualTo("Database is full, cannot add element."));
    }

    [Test]
    public void AddMethodShouldAddOneElementToTheArray()
    {
        integers = new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
        db = new Database(integers);

        var lenghtBeforeAdding = db.GetLenghtOfArray();
        db.AddElement(elementToAdd);
        var lenghtAfterAdding = db.GetLenghtOfArray();

        Assert.AreEqual(lenghtAfterAdding - 1, lenghtBeforeAdding);
    }

    [Test]
    public void RemoveMethodFromEmptyDbThrowsException()
    {
        integers = new int[0];
        db = new Database(integers);

        Assert.That(() => db.RemoveLastElement(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Empty database."));
    }

    [Test]
    public void RemoveMethodShoudRemoveLastElement()
    {
        integers = new[] {1, 1, 1};
        db = new Database(integers);

        var lengthBeforeRemoving = db.GetLenghtOfArray();
        db.RemoveLastElement();
        var lenghtAfterRemoving = db.GetLenghtOfArray();

        Assert.AreEqual(lenghtAfterRemoving + 1, lengthBeforeRemoving);
    }

    [Test]
    public void FetchMethodReturnsTheArray()
    {
        integers = new[] {1, 1, 1};
        db = new Database(integers);

        var returnedIntegers = db.Fetch();

        Assert.AreEqual(returnedIntegers, integers);
    }
}
