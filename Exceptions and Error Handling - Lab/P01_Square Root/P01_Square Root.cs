namespace Square_Root_1
{
    using System;
    public class P01_Square_Root
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            try
            {
                if (num < 0)
                {
                    Console.WriteLine("Invalid number.");
                    return;
                }
                Console.WriteLine(Math.Round(Math.Sqrt(num), 2));
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}