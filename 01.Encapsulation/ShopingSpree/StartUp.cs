namespace ShopingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            List<Products> products = new List<Products>();
            Queue<string> input = new Queue<string>(Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries));
            try
            {
                while (input.Count > 0)
                {
                    string[] person = input.Dequeue().Split("=", StringSplitOptions.RemoveEmptyEntries);
                    people.Add(new Person(person[0], decimal.Parse(person[1])));
                }
                input = new Queue<string>(Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries));
                while (input.Count > 0)
                {
                    string[] product = input.Dequeue().Split("=", StringSplitOptions.RemoveEmptyEntries);
                    products.Add(new Products(product[0], decimal.Parse(product[1])));
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return;
            }

            string[] cmd = Console.ReadLine().Split();
            while (cmd[0] != "END")
            {
                Person person = people.FirstOrDefault(p => p.Name == cmd[0]);
                Products product = products.First(p => p.Name == cmd[1]);
                if (person.Money >= product.Cost)
                {
                    person.AddProductToTheBag(product);
                    person.Money -= product.Cost;
                    people[people.IndexOf(person)] = person;
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
                cmd = Console.ReadLine().Split();
            }

            foreach (Person person in people)
            {
                if (person.Bag.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
                }
            }

        }
    }
}
