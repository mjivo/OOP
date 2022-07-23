namespace P04_Sum
{
    using System;
    using System.Collections.Generic;

    internal class P04_Sum
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> numbers = new Queue<string>(input);

            int sum = 0;
            while (numbers.Count > 0)
            {
                string num = numbers.Dequeue();
                try
                {
                    sum += int.Parse(num);
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{num}' is out of range!");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{num}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{num}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}