namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        private const string namespacePath = "_03BarracksFactory.Models.Units.";

        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(namespacePath + unitType);

            IUnit unit = (IUnit)Activator.CreateInstance(typeUnit);

            return unit;
        }
    }
}
