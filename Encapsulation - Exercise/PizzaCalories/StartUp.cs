namespace PizzaCalories
{
using System;
    public class StartUp
    {
        static void Main()
        {
            try
            {
                string[] input = Console.ReadLine().Split();
                Pizza pizza = new Pizza(input[1]);
                input = Console.ReadLine().Split();
                pizza.Dough = new Dough(input[1], input[2], double.Parse(input[3]));
                input = Console.ReadLine().Split();
                
                while (input[0] != "END")
                {
                    pizza.AddToppings(new Toppings(input[1], double.Parse(input[2])));
                    input = Console.ReadLine().Split();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException argException)
            {
                Console.WriteLine(argException.Message);
            }
        }
    }
}
