namespace Square_Root
{
    using System;
    using Engines;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            //Read input
            int number = int.Parse(Console.ReadLine());

            IEngine engine = new Engine(number);


        }
    }
}