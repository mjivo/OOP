namespace Football_Team_Generator
{
    using Core;
    using Football_Team_Generator.IO;
    using Football_Team_Generator.IO.Contracts;

    public class StartUp
    {
        static void Main()
        {
            IReader consoleReader = new ConsoleReader();
            IWriter consoleWriter = new ConsoleWriter();
            Engine engine = new Engine(consoleReader, consoleWriter);
            engine.Run();
        }
    }
}
