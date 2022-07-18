namespace Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.FuelConsumptionModifier = 1.4;
        }
        public string DriveEmpty(double km)
        {
            double neededLiters = this.FuelConsumption * km;
            if (this.FuelQuantity - neededLiters >= 0)
            {
                base.FuelQuantity -= neededLiters;
                return $"{GetType().Name} travelled {km} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }
    }
}
//car 100 0.1 20
//truck 150 0.3 200
//bus 70 0.6 100
//10
//Refuel Car -10
//Fuel must be a positive number
//Refuel Car 100
//Cannot fit 100 fuel in the tank
//Drive Car 10