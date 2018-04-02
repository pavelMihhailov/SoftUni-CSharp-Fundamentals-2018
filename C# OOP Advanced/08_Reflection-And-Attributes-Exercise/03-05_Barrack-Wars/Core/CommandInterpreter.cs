using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandEnding = "Command";
        private const string Namespace = "_03BarracksFactory.Core.Commands.";
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandCompleteName = Namespace + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandEnding;

            //var commandType = Assembly.GetExecutingAssembly().GetTypes()
            //    .FirstOrDefault(t => t.Name == commandCompleteName);
            //
            //if (commandType == null) throw new InvalidOperationException("Invalid command!");

            object[] commandParams =
            {
                data
            };

            IExecutable command = (IExecutable)Activator.CreateInstance(Type.GetType(commandCompleteName), commandParams);

            return InjectDependencies(command);
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] fieldsOfCommand = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo[] fieldsOfInterpreter = typeof(CommandInterpreter).GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldsOfCommand.Where(f => f.GetCustomAttribute<InjectAttribute>() != null))
            {
                if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                {
                    field.SetValue(command,fieldsOfInterpreter.First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                }
            }

            return command;
        }
    }
}
