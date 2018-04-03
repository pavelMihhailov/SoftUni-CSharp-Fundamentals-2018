using NUnit.Framework;

public class AxeTests
{
    private const int AxeAttack = 2;
    private const int AxeDurability = 2;
    private const int BrokenAxe = 0;
    private const int DummyHealth = 20;
    private const int DummyXP = 20;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void TestInit()
    {
        axe = new Axe(AxeAttack, AxeDurability);
        dummy = new Dummy(DummyHealth, DummyXP);
    }

    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe Durability doesn't change after attack");
    }

    [Test]
    public void AttackingWithBrokenWeapon()
    {
        axe = new Axe(10, BrokenAxe);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }
}