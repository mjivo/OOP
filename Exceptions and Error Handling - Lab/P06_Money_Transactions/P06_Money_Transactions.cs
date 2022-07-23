using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Money_Transactions
{
    internal class P06_Money_Transactions
    {
        private static Dictionary<int, double> bank = new Dictionary<int, double>();
        private static bool IsError = false;
        static void Main()
        {
            string[] accounts = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            accounts.ToList().ForEach(v => bank.Add(int.Parse(v.Split('-', StringSplitOptions.RemoveEmptyEntries)[0]),
                double.Parse(v.Split('-', StringSplitOptions.RemoveEmptyEntries)[1])));
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                string command = input[0];
                int accNum = int.Parse(input[1]);
                double balance = double.Parse(input[2]);
                switch (command)
                {
                    case "Deposit":
                        if (!IsAccValid(accNum))
                        {
                            IsError = true;
                        }
                        else
                        {
                            bank[accNum] += balance;
                        }
                        break;
                    case "Withdraw":
                        if (!IsAccValid(accNum))
                        {
                            IsError = true;
                        }
                        else if (balance > bank[accNum])
                        {
                            Console.WriteLine("Insufficient balance!");
                            IsError = true;
                        }
                        else
                        {
                            bank[accNum] -= balance;
                        }
                        break;
                    default:
                        IsError = true;
                        Console.WriteLine("Invalid command!");
                        break;
                }
                if (!IsError)
                {
                    Console.WriteLine($"Account {accNum} has new balance: {bank[accNum]:F2}");
                }
                IsError = false;
                Console.WriteLine("Enter another command");
                input = Console.ReadLine().Split();
            }
        }
        private static bool IsAccValid(int accNum)
        {
            if (!bank.ContainsKey(accNum))
            {
                Console.WriteLine("Invalid account!");
                IsError = true;
                return false;
            }
            return true;
        }
    }
}