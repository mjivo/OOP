namespace P02_Numbers
{
    using System;
    using System.Linq;

    internal class P02_Numbers
    {
        static void Main()
        {
            //try
            //{
            int[] arr = ReadNumbers(100);
            Console.WriteLine(string.Join(", ", arr));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }
        private static int[] ReadNumbers(int endNum)
        {
            int[] _arr = new int[10];
            int previousNum = 1;
            for (int i = 0; i < 10; i++)
            {
                string input = Console.ReadLine();
                int n = 0;
                if (int.TryParse(input, out n))
                {
                    if (previousNum < n && n < endNum)
                    {
                        previousNum = n;
                        _arr[i] = n;
                    }
                    else
                    {
                        Console.WriteLine($"Your number is not in range {previousNum} - 100!");
                        i--;
                        //throw new InvalidCastException("Invalid Number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    //throw new Exception("Your number is not in range {currentNumber} - 100!");
                }
            }
            return _arr;
        }
    }
}