namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; } // l per km
        public string Drive(double km);
        public void Refuel(double fuel);
    }
}
