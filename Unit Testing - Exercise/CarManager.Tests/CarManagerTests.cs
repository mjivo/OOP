namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _rangeRover;
        [SetUp]
        public void SetUp()
        {
            this._rangeRover = new Car("Land Rover", "Range Rover Sport", 14, 100);
        }
        //Constructor tests:
        [Test]
        public void ConstructorShouldSetFuelAmuntToZero()
        {
            Car car = new Car("Land Rover", "Range Rover Sport", 14, 100);
            Assert.AreEqual(0, car.FuelAmount,
                "Fuel amunt is not set to zero.");
        }
        [Test]
        public void ConstructorShouldSetValuesToProps()
        {
            string model = "Land Rover";
            string make = "Range Rover Sport";
            double fuelfuelConsumption = 14;
            double fuelCampacity = 100;
            Car car = new Car(make, model, fuelfuelConsumption, fuelCampacity);
            Assert.AreEqual(0, car.FuelAmount,
                "FuelAmount is not set to zero.");
            Assert.AreEqual(model, car.Model,
                "Model is not set correctly.");
            Assert.AreEqual(make, car.Make,
                "Make is not set correctly.");
            Assert.AreEqual(fuelfuelConsumption, car.FuelConsumption,
                "FuelConsumption is not set correctly.");
            Assert.AreEqual(fuelCampacity, car.FuelCapacity,
                "FuelCapacity is not set correctly.");
        }
        //Validation testing:
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeCannotBeNullOrEmpty(string make)
        {
            //Arange
            Car car;
            Exception makeException = Assert.Throws<ArgumentException>(
                () => car = new Car(make, "Range Rover Sport", 14, 100),
                "Exception is not thrown.");
            Assert.AreEqual("Make cannot be null or empty!", makeException.Message,
                "Exceptions are not the same.");
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelCannotBeNullOrEmpty(string model)
        {
            //Arange
            Car car;
            Exception modelException = Assert.Throws<ArgumentException>(
                () => car = new Car("Land Rover", model, 14, 100),
                "Exception is not thrown.");
            Assert.AreEqual("Model cannot be null or empty!", modelException.Message,
                "Exceptions are not the same.");
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void FuelConsumationCannotBeZeroOrLower(double fuelConsumption)
        {
            //Arange
            Car car;
            Exception fuelConsumptionException = Assert.Throws<ArgumentException>(
                () => car = new Car("Land Rover", "Range Rover", fuelConsumption, 100),
                "Exception is not thrown.");
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", fuelConsumptionException.Message,
                "Exceptions are not the same."
                );
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void FuelCapacityCannotBeZeroOrLower(double fuelCapacity)
        {
            //Arange
            Car car;
            Exception fuelCapacityException = Assert.Throws<ArgumentException>(
                () => car = new Car("Land Rover", "Range Rover", 14, fuelCapacity),
                "Exception is not thrown.");
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", fuelCapacityException.Message,
                "Exceptions are not the same.");
        }
        //Refuel tests:
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void CannotRefuelWithZeroOrLower(double fuel)
        {
            Exception fuelAmountException = Assert.Throws<ArgumentException>(
                () => this._rangeRover.Refuel(fuel),
                "Exception is not thrown.");
            Assert.AreEqual("Fuel amount cannot be zero or negative!", fuelAmountException.Message,
                "Exceptions are not the same.");
        }
        [Test]
        [TestCase(1)]
        [TestCase(99)]
        [TestCase(100)]
        [TestCase(101)]
        [TestCase(1000)]
        public void RefuelMethodShouldRefuel(double fuel)
        {
            //Act
            this._rangeRover.Refuel(fuel);
            //Assert
            if (fuel >= this._rangeRover.FuelCapacity)
            {
                Assert.AreEqual(this._rangeRover.FuelCapacity, this._rangeRover.FuelAmount,
                    "Fuel amount is not set correctly.");
            }
            else
            {
                Assert.AreEqual(fuel, this._rangeRover.FuelAmount,
                    "Fuel amount is not set correctly.");
            }
        }
        //Drive tests:
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(1000)]
        public void Drive(double distance)
        {
            //Arange
            double refuelFuel = 100;
            double neededFuel = distance * (this._rangeRover.FuelConsumption / 100);
            this._rangeRover.Refuel(refuelFuel);
            //Assert
            if (neededFuel > this._rangeRover.FuelAmount)
            {
                Exception driveException = Assert.Throws<InvalidOperationException>(
                    () => this._rangeRover.Drive(distance),
                    "Eception is not thrown.");
                Assert.AreEqual("You don't have enough fuel to drive!", driveException.Message,
                    "Exceptions are not the same.");
            }
            else
            {
                this._rangeRover.Drive(distance);
                Assert.AreEqual(refuelFuel - neededFuel, this._rangeRover.FuelAmount,
                    "Fuel should be decrised after drive.");
            }
        }
    }
}   