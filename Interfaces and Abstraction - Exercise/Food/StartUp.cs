namespace Food
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main()
        {
            //List<Person> people = new List<Person>();
            //List<Pet> pets = new List<Pet>();
            //List<Robot> robots = new List<Robot>();
            //List<Rebel> rebels = new List<Rebel>();
            Dictionary<string, IBuyable> people = new Dictionary<string, IBuyable>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (cmd.Length == 3)//rebel
                {
                    people.Add(cmd[0], new Rebel(cmd[0], int.Parse(cmd[1]), cmd[2]));
                }
                else if (cmd.Length == 4)
                {
                    people.Add(cmd[0], new Person(cmd[0], int.Parse(cmd[1]), cmd[2], cmd[3]));
                }
            }
            string input = Console.ReadLine();
            int food = 0;
            while (input != "End")
            {
                if (people.ContainsKey(input))
                {
                    food += people[input].BuyFood();
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(food);
            //string birthdate = Console.ReadLine();
            ////foreach(Robot robot in robots)
            ////{

            ////}
            //foreach (IBirthdateable person in people)
            //{
            //    if (person.Birthdate.EndsWith(birthdate))
            //    {
            //        Console.WriteLine($"{person.Birthdate}");
            //    }
            //}
            //foreach (IBirthdateable pet in pets)
            //{
            //    if (pet.Birthdate.EndsWith(birthdate))
            //    {
            //        Console.WriteLine($"{pet.Birthdate}");
            //    }
            //}
        }
    }
}
