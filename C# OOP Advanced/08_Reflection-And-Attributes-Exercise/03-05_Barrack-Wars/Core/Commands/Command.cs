using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            Data = data;
        }

        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }
        
        public abstract string Execute();
    }
}
