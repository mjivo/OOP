namespace Football_Team_Generator.IO
{
    using System;
    using Contracts;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}   
