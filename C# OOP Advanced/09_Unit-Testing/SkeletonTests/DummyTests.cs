using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private const int AttackPoints = 1;
    private const int DummyHealth = 10;
    private const int DummyXP = 10;
    private const int DeadDummyHealth = 0;
    private const string DummyNotDeadEx = "Target is not dead.";
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        var dummyHealthBeforeAttack = dummy.Health;

        dummy.TakeAttack(AttackPoints);

        var dummyHealthAfterAttack = dummy.Health;

        Assert.AreNotEqual(dummyHealthAfterAttack, dummyHealthBeforeAttack,
            "Dummy doesn`t loose health after attack.");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        dummy = new Dummy(DeadDummyHealth + 1, DummyXP);

        dummy.TakeAttack(AttackPoints);

        Assert.That(() => dummy.TakeAttack(AttackPoints),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), DummyNotDeadEx);
    }

    [Test]
    public void DeadDummyCanGiveXp()
    {
        dummy = new Dummy(DeadDummyHealth, DummyXP);

        Assert.That(() => dummy.GiveExperience(), Is.Positive);
    }

    [Test]
    public void AliveDummyCantGiveXp()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException, "Target is not dead.");
    }
}