using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();
            Car car = new Car(double.Parse(input[1]), double.Parse(input[2]));
            input = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(input[1]), double.Parse(input[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                if (input[0] == "Drive")
                {
                    if (input[1] == "Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(input[2])));
                    }
                    else if (input[1] == "Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(input[2])));
                    }
                }
                else if (input[0] == "Refuel")
                {
                    if (input[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(input[2]));
                    }
                    else if (input[1] == "Car")
                    {
                        car.Refuel(double.Parse(input[2]));
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
