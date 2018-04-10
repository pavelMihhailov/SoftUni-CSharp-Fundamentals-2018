using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class _03_Iterator_Test_Test
{
    private static readonly List<string> CollectionWithOneItem = new List<string>() { "test1" };
    private static readonly List<string> CollectionWithManyItems = new List<string>() { "test1", "test2", "test3" };
    private static readonly List<string> EmptyCollection = new List<string>();
    private static ListyIterator<string> _listyIterator;
    private static bool _result;

    [SetUp]
    public void InitlizeIterator()
    {
        _listyIterator = new ListyIterator<string>(CollectionWithManyItems);
    }

    [Test]
    public void ConstructorTest()
    {
        Assert.That(() => new ListyIterator<string>(null), Throws.ArgumentException);
    }

    [Test]
    public void MoveReturnsFalseIfThereIsNoNextIndex()
    {
        _listyIterator = new ListyIterator<string>(CollectionWithOneItem);
        _result = _listyIterator.Move();

        Assert.AreEqual(_result, false);
    }

    [Test]
    public void MoveReturnsTrueIfSuccessfullyMoved()
    {
        _result = _listyIterator.Move();
        Assert.AreEqual(_result, true);
    }

    [Test]
    public void HasNextReturnsFalseIfTheCurrIndexIsTheLastIndex()
    {
        _listyIterator = new ListyIterator<string>(CollectionWithOneItem);
        _result = _listyIterator.HasNext();

        Assert.AreEqual(_result, false);
    }

    [Test]
    public void HasNextReturnsTrueIfThereIsANextIndex()
    {
        _result = _listyIterator.HasNext();
        Assert.AreEqual(_result, true);
    }

    [Test]
    public void PrintReturnsExceptionIfCollectionIsEmpty()
    {
        _listyIterator = new ListyIterator<string>(EmptyCollection);

        Assert.That(() => _listyIterator.Print(), 
            Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
    }
}
