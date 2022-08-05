namespace CommandPattern.Core.Contracts
{
    public interface ICommandInterpreter
    {
        string Interpreter(string args);
    }
}
