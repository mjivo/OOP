﻿namespace CommandPattern.Core.Models.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
