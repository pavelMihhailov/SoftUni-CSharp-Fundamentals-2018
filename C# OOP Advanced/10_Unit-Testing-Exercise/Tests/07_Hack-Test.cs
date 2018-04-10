using System;
using Moq;
using NUnit.Framework;

[TestFixture]
public class _07_Hack
{
    [Test]
    [TestCase(-300)]
    [TestCase(300)]
    [TestCase(0)]
    public void MathAbsValid(double value)
    {
        Mock<IMathAbs> intMock = new Mock<IMathAbs>();
        intMock.Setup(x => x.MathAbs(value)).Returns(Math.Abs(value));
        var expected = Math.Abs(value);
        var actual = intMock.Object.MathAbs(value);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(0)]
    [TestCase(-33.33)]
    [TestCase(-27.293943)]
    public void TestMathFloorValid(double value)
    {
        Mock<MathInt> intMock = new Mock<MathInt>();

        var actual = intMock.Object.MathFloor(value);
        var expected = Math.Floor(value);

        Assert.That(actual, Is.EqualTo(expected));
    }
}
