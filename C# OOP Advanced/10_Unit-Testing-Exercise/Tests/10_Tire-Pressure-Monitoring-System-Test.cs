using System;
using System.Reflection;
using Moq;
using NUnit.Framework;

[TestFixture]
public class _10_Tire_Pressure_Monitoring_System_Test
{
    [Test]
    [TestCase(-1000)]
    [TestCase(22)]
    [TestCase(16)]
    public void AlarmCheckMethodWithOutOfRangeValuesReturnsAlarmOn(double oorValue)
    {
        Mock<ISensor> mockSensor = new Mock<ISensor>();
        mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(oorValue);

        Type alarmType = typeof(Alarm);

        Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
        FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

        sensor.SetValue(classInstance, mockSensor.Object);
        classInstance.Check();

        Assert.That(classInstance.AlarmOn, Is.True);
    }

    [Test]
    [TestCase(18)]
    [TestCase(20)]
    public void AlarmCheckMethodWithValidValuesReturnsAlarmOff(double valValue)
    {
        Mock<ISensor> mockSensor = new Mock<ISensor>();
        mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(valValue);

        Type alarmType = typeof(Alarm);

        Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
        FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

        sensor.SetValue(classInstance, mockSensor.Object);
        classInstance.Check();

        Assert.That(classInstance.AlarmOn, Is.False);
    }
}
