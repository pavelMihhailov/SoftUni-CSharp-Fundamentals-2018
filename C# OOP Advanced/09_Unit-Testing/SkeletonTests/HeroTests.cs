using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsXpWhenTargetDies()
    {
        var fakeWeapon = new Mock<IWeapon>();
        var fakeTarget = new Mock<ITarget>();
        var hero = new Hero("Pesho", fakeWeapon.Object);
        var xpToGive = fakeTarget.Object.GiveExperience();
        var attackingPoints = fakeWeapon.Object.AttackPoints;

        fakeTarget.Setup(t => t.TakeAttack(attackingPoints));
        fakeTarget.Setup(t => t.IsDead());
        fakeTarget.Setup(t => t.GiveExperience());

        Assert.That(hero.Experience, Is.EqualTo(xpToGive));
    }
}