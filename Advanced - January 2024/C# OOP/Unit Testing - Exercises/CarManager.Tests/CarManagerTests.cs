using System;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string validMake = "BMW";
        private string validModel = "E46";
        private double validFuelConsumption = 3;
        private double validFuelCapacity = 20;
        private Car car;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Ctor_WithoutParams_InitializesCorrectly()
        {
            car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
            Assert.That(car, Is.Not.Null);
            Assert.AreEqual(car.Make, validMake);
            Assert.AreEqual(car.Model, validModel);
            Assert.AreEqual(car.FuelConsumption, validFuelConsumption);
            Assert.AreEqual(car.FuelCapacity, validFuelCapacity);
        }

        [Test]
        public void MakeSetter_ThrowsExceptionCorrectly()
        {
            string invalidMake = null;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(invalidMake, validModel, validFuelConsumption, validFuelCapacity);
            });
        }

        [Test]
        public void ModelSetter_ThrowsExceptionCorrectly()
        {
            string invalidModel = null;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(validMake, invalidModel, validFuelConsumption, validFuelCapacity);
            });
        }

        [Test]
        public void FuelConsumptionSetter_ThrowsExceptionCorrectly()
        {
            int invalidFuelConsumption = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(validMake, validModel, invalidFuelConsumption, validFuelCapacity);
            });
        }

        [Test]
        public void FuelCapacitySetter_ThrowsExceptionCorrectly()
        {
            int invalidFuelCapacity = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(validMake, validModel, validFuelConsumption, invalidFuelCapacity);
            });
        }

        [Test]
        public void RefuelMethod_WorksAndThrowsCorrectly()
        {
            Car car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);

            double fuelToRefuel = 5;
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(car.FuelAmount, fuelToRefuel);

            Car car2 = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
            double overflowingRefuel = 21;
            car2.Refuel(overflowingRefuel);
            Assert.AreEqual(car2.FuelAmount, car2.FuelCapacity);

            double invalidRefuel = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                car2.Refuel(invalidRefuel);
            });
        }

        [Test]
        public void DriveMethod_WorksAndThrowsCorrectly()
        {
            Car car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
            double refuel = 15;
            car.Refuel(refuel);

            double distance = 3;
            double fuelNeeded = (distance / 100) * validFuelConsumption;

            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount, refuel - fuelNeeded);

            double overflowingDistance = 2000;
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(overflowingDistance);
            });
        }

        /* [Test]
        public void FuelAmountSetter_WorkAndThrowCorrectly()
        {
            Car car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
            car.Refuel(1);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Drive(1);
            });
        } */
    }
}