namespace CommandPattern.Core
{
    using IO.Contracts;
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader _reader;
        private IWriter _writer;
        private ICommandInterpreter _commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this._commandInterpreter = commandInterpreter;
            this._reader = reader;
            this._writer = writer;
        }
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = this._reader.ReadLine();
                    string output = this._commandInterpreter.Read(input);
                    this._writer.WriteLine(output);
                }
                catch (FormatException formatExc)
                {
                    this._writer.WriteLine(formatExc.Message);
                }
                catch (Exception exc)
                {
                    this._writer.WriteLine(exc.Message);
                }
            }
        }
    }
}
