namespace Vehicles 
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            base.FuelConsumptionModifier = 1.6;
        }
        public override void Refuel(double value)//coulde be base.Refuel(value*0.95);
        {
            if (this.FuelQuantity + value > this.TankCapacity)
            {
                throw new OverflowException($"Cannot fit {value} fuel in the tank");
            }
            else if (value <= 0)
            {
                throw new OverflowException($"Fuel must be a positive number");
            }
            base.Refuel(value * 0.95);
        }
    }
}
