namespace P05_Play_Catch
{
    internal class P05_Play_Catch
    {
        private static int _numOfExceptions = 0;
        private static int[] _numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        static void Main()
        {
            while (_numOfExceptions < 3)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                if (!IsIndexValid(input[1]))
                {
                    continue;
                }
                int index = int.Parse(input[1]);
                switch (command)
                {
                    case "Show":
                        Console.WriteLine(_numbers[index]);
                        break;
                    case "Print":
                        if (!IsIndexValid(input[2]))
                        {
                            continue;
                        }
                        int endIndex = int.Parse(input[2]);
                        for (int i = index; i <= endIndex; i++)
                        {
                            if (i == index)
                            {
                                Console.Write($"{_numbers[i]}");
                            }
                            else if (i == endIndex)
                            {
                                Console.WriteLine($", {_numbers[i]}");
                            }
                            else
                            {
                                Console.Write($", {_numbers[i]}");
                            }
                        }
                        break;
                    case "Replace":
                        if (!IsElementValid(input[2]))
                        {
                            continue;
                        }
                        int element = int.Parse(input[2]);
                        _numbers[index] = element;
                        break;
                }
            }
            Print();
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", _numbers));
        }

        private static bool IsIndexValid(string number)
        {
            try
            {
                int num = _numbers[int.Parse(number)];
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
            }
            _numOfExceptions++;
            return false;
        }
        private static bool IsElementValid(string number)
        {
            try
            {
                int num = int.Parse(number);
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
            }
            _numOfExceptions++;
            return false;
        }

    }
}