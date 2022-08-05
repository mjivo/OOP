namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Models.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Interpreter(string args)
        {
            string[] input = args
                .Split();
            string commandName = input[0];
            string[] commandArgs = input
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly
                .GetCallingAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == $"{commandName}Command" &&
                    c.GetInterfaces()
                    .Any(i => i == typeof(ICommand)));
            if (commandType == null)
                throw new FormatException($"Try diffrent command than {commandName}");
            ICommand command = Activator.CreateInstance(commandType) as ICommand;
            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
