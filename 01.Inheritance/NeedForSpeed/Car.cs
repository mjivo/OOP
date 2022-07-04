using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double _defaultFuelConsumption = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            base.DefaultFuelConsumption = _defaultFuelConsumption;
        }
    }
}
