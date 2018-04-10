using NUnit.Framework;

[TestFixture]
public class _02_Extended_Database_Test
{
    private static ExtDatabase db;
    private static People person;
    private const string username = "pavel";
    private const long id = 11;
    private const long negativeId = -10;
    private const long nonExistId = 9999;

    [SetUp]
    public void InitilizeDb()
    {
        db = new ExtDatabase();
        person = new People(id, username);
        db.AddPeople(person);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.DoesNotThrow(() => new ExtDatabase(), "Exception occured!");
    }

    [Test]
    public void AddPersonWithSameUsernameThrowsException()
    {
        Assert.That(() => db.AddPeople(person), 
            Throws.InvalidOperationException.With.Message.EqualTo("Already has user with that username."));
    }

    [Test]
    public void AddPersonWithSameIdThrowsException()
    {
        person = new People(11, "ivo");
        Assert.That(() => db.AddPeople(person), 
            Throws.InvalidOperationException.With.Message.EqualTo("Already has user with that id."));
    }

    [Test]
    public void AddPersonAddsThePersonToDb()
    {
        var countBeforeAdding = db.GetCurrentDatabaseCount();

        person = new People(3, "pesho");
        db.AddPeople(person);

        var countAfterAdding = db.GetCurrentDatabaseCount();

        Assert.AreEqual(countAfterAdding - 1, countBeforeAdding);
    }

    [Test]
    public void RemoveMethodRemovesThePerson()
    {
        var cntBeforeRemoving = db.GetCurrentDatabaseCount();
        db.RemovePeople(person);
        var cntAfterRemoving = db.GetCurrentDatabaseCount();

        Assert.AreEqual(cntAfterRemoving + 1, cntBeforeRemoving);
    }

    [Test]
    public void FindByUsernameHandlesExceptions()
    {
        Assert.That(() => db.FindByUsername("niki"), 
            Throws.InvalidOperationException.With.Message.EqualTo("No user with that username"));
        Assert.That(() => db.FindByUsername(null),
            Throws.ArgumentException.With.Message.EqualTo("Username cannot be null."));
    }

    [Test]
    public void FindByUsernameReturnsThePersonWithThatUsername()
    {
        var returnedPerson = db.FindByUsername(username);
        
        Assert.AreEqual(returnedPerson, person);
    }

    [Test]
    public void FindByIdHandlesExceptions()
    {
        Assert.That(() => db.FindById(nonExistId),
            Throws.InvalidOperationException.With.Message.EqualTo("No user with that id."));
        Assert.That(() => db.FindById(negativeId), Throws.Exception);
    }

    [Test]
    public void FindByIdReturnsThePersonWithThatId()
    {
        var returnedPerson = db.FindById(id);

        Assert.AreEqual(returnedPerson, person);
    }
}
