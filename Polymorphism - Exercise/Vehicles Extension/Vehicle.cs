using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double _fuelQuantity;
        private double _fuelConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public virtual double FuelQuantity
        {
            get => this._fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    value = 0;
                }
                this._fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get => this._fuelConsumption;
            protected set
            {
                this._fuelConsumption = value;
            }
        }
        public virtual double TankCapacity { get; protected set; }
        public double FuelConsumptionModifier { get; protected set; }
        public virtual string Drive(double km)
        {
            double neededLiters = (this.FuelConsumption + FuelConsumptionModifier) * km;
            if (this.FuelQuantity - neededLiters >= 0)
            {
                this.FuelQuantity -= neededLiters;
                return $"{GetType().Name} travelled {km} km";
            }
            else
            {
                return $"{GetType().Name} needs refueling";
            }
        }
        public virtual void Refuel(double value)
        {
            if (this.FuelQuantity + value > this.TankCapacity)
            {
                throw new OverflowException($"Cannot fit {value} fuel in the tank");
            }
            else if (value <= 0)
            {
                throw new OverflowException($"Fuel must be a positive number");
            }
            this.FuelQuantity += value;
        }
    }
}
