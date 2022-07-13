namespace Animals
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            string type = Console.ReadLine();
            while (type != "Beast!")
            {
                try
                {
                    string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    switch (type)
                    {
                        case "Dog":
                            animals.Add(new Dog(data[0], int.Parse(data[1]), data[2]));
                            break;
                        case "Frog":
                            animals.Add(new Frog(data[0], int.Parse(data[1]), data[2]));
                            break;
                        case "Cat":
                            animals.Add(new Cat(data[0], int.Parse(data[1]), data[2]));
                            break;
                        case "Tomcat":
                            animals.Add(new Tomcat(data[0], int.Parse(data[1])));
                            break;
                        case "Kitten":
                            animals.Add(new Kitten(data[0], int.Parse(data[1])));
                            break;
                        default:
                            throw new ArgumentNullException(nameof(type), "");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
                type = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                if (animal.Name != "Invalid input!")
                    Console.WriteLine(animal);
            }

        }
    }
}
