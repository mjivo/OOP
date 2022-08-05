namespace CommandPattern
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IReader consoleReader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            IEngine engine = new Engine(commandInterpreter, consoleReader, consoleWriter);
            engine.Run();
        }
    }
}
