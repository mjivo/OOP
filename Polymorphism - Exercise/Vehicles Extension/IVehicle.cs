namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; } // l per km
        public double TankCapacity { get; }
        public double FuelConsumptionModifier { get; }
        public string Drive(double km);
        public void Refuel(double fuel);
    }
}
