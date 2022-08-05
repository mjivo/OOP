namespace CommandPattern.Core.Commands
{
    using System;
    using CommandPattern.Core.Models.Contracts;
    using Contracts;
    public class ExitCommand : ICommand
    {
        private const int SuccessfulExiteCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(SuccessfulExiteCode);
            return null;
        }
    }
}
