using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject] private IRepository repository;

        public RetireCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            var unitToRemove = this.Data[1];
            this.repository.RemoveUnit(unitToRemove);
            return $"{unitToRemove} retired!";
        }
    }
}
