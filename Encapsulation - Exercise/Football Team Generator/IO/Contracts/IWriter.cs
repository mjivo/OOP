﻿namespace Football_Team_Generator.IO.Contracts
{
    public interface IWriter
    {
        void Write (string value);

        void WriteLine (string value);
    }
}