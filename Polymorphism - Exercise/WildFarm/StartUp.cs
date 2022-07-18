namespace WildFarm
{
    using System;
    using WildFarm.Foods;
    using WildFarm.Animals;
    using WildFarm.Animals.Birds;
    using WildFarm.Animals.Mammal;
    using WildFarm.Animals.Mammal.Feline;
    using System.Collections.Generic;
    public class StartUp
    {
        static void Main()
        {
            string[] cmd = Console.ReadLine().Split();
            List<Animal> animals = new List<Animal>();
            while (cmd[0] != "End")
            {
                string[] animalInfo = cmd;
                string[] foodInfo = Console.ReadLine().Split();
                switch (cmd[0].ToLower())
                {
                    case "owl":                                                                                                //bird
                        animals.Add(new Owl(animalInfo[1], double.Parse(animalInfo[2]), 0, double.Parse(animalInfo[3])));      //bird
                        break;                                                                                                 //bird
                    case "hen":                                                                                                //bird
                        animals.Add(new Hen(animalInfo[1], double.Parse(animalInfo[2]), 0, double.Parse(animalInfo[3])));      //bird
                        break;                                                                                                 //bird
                    case "cat":                                                                                                //feline
                        animals.Add(new Cat(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3], animalInfo[4]));     //feline
                        break;                                                                                                 //feline
                    case "tiger":                                                                                              //feline
                        animals.Add(new Tiger(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3], animalInfo[4]));   //feline
                        break;                                                                                                 //feline
                    case "dog":                                                                                                //mammal
                        animals.Add(new Dog(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3]));                    //mammal
                        break;                                                                                                 //mammal
                    case "mouse":                                                                                              //mammal
                        animals.Add(new Mouse(animalInfo[1], double.Parse(animalInfo[2]), 0, animalInfo[3]));                  //mammal
                        break;                                                                                                 //mammal
                }
                Console.WriteLine(animals[animals.Count - 1].Sound());
                Food food = null;
                switch (foodInfo[0].ToLower())
                {
                    case "meat":
                        food = new Meat(int.Parse(foodInfo[1]));
                        break;
                    case "vegetable":
                        food = new Vegetable(int.Parse(foodInfo[1]));
                        break;
                    case "fruit":
                        food = new Fruit(int.Parse(foodInfo[1]));
                        break;
                    case "seeds":
                        food = new Seeds(int.Parse(foodInfo[1]));
                        break;
                }
                try
                {
                    animals[animals.Count - 1].Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                cmd = Console.ReadLine().Split();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
