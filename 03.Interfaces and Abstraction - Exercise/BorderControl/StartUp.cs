using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Robot> robots = new List<Robot>();
            while (cmd[0] != "End")
            {
                if (cmd.Length == 2)//robot
                {
                    robots.Add(new Robot(cmd[0], cmd[1]));
                }
                else if (cmd.Length == 3)//person
                {
                    people.Add(new Person(cmd[0], int.Parse(cmd[1]), cmd[2]));
                }
                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            string id = Console.ReadLine();
            foreach (IIdentifilable robot in robots)
            {
                if (robot.Id.EndsWith(id))
                {
                    Console.WriteLine($"{robot.Id}");
                }
            }
            foreach (IIdentifilable person in people)
            {
                if (person.Id.EndsWith(id))
                {
                    Console.WriteLine($"{person.Id}");
                }
            }
            //people.ForEach(p => (p.Id.EndsWith(id)) == true ? Console.WriteLine(p.Id));
        }
    }
}
