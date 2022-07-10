namespace Telephony
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main()
        {
            Queue<string> phoneNumbers = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Queue<string> URLs = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            //try
            //{
            while (phoneNumbers.Count > 0)
            {
                string phoneNumber = phoneNumbers.Dequeue();
                ICallable phone;
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                else if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else// phones will allways be valid
                {
                    throw new Exception("Invalid number!");
                }
                Console.WriteLine(phone.Call(phoneNumber));
            }
            while (URLs.Count > 0)
            {
                string url = URLs.Dequeue();
                Smartphone smartphone = new Smartphone();
                Console.WriteLine(smartphone.Browse(url));
            }
            //}
            //catch (ArgumentException a)
            //{
            //    Console.WriteLine(a.Message);

            //}
        }
    }
}
