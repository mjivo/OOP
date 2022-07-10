namespace Birthday
{
    using System;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main()
        {
            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Pet> pets = new List<Pet>();
            List<Robot> robots = new List<Robot>();
            while (cmd[0] != "End")
            {
                if (cmd[0] == "Pet")
                {
                    pets.Add(new Pet(cmd[1], cmd[2]));
                }
                else if (cmd[0] == "Citizen")
                {
                    people.Add(new Person(cmd[1], int.Parse(cmd[2]), cmd[3], cmd[4]));
                }
                else if (cmd[0] == "Robot")
                {
                    robots.Add(new Robot(cmd[1], cmd[2]));
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string birthdate = Console.ReadLine();
            //foreach(Robot robot in robots)
            //{

            //}
            foreach (IBirthdateable person in people)
            {
                if (person.Birthdate.EndsWith(birthdate))
                {
                    Console.WriteLine($"{person.Birthdate}");
                }
            }
            foreach (IBirthdateable pet in pets)
            {
                if (pet.Birthdate.EndsWith(birthdate))
                {
                    Console.WriteLine($"{pet.Birthdate}");
                }
            }
        }
    }
}
