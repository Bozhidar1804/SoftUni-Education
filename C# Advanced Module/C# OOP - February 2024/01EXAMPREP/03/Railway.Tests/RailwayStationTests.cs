namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        private RailwayStation railwayStation;
        private Queue<string> arrivalTrains;
        private Queue<string> departureTrains;
        private string trainInfo = "testTrain";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            string name = "test";
            railwayStation = new RailwayStation(name);
            Assert.AreEqual(name, railwayStation.Name);
            Assert.That(railwayStation.ArrivalTrains, Is.Not.Null);
            Assert.That(railwayStation.DepartureTrains, Is.Not.Null);
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));
        }

        [Test]
        public void NameProperty_ThrowsExceptionCorrectly()
        {
            string invalidEmptyName = "";
            string invalidNullName = null;

            Assert.Throws<ArgumentException>(() =>
            {
                railwayStation = new RailwayStation(invalidEmptyName);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                railwayStation = new RailwayStation(invalidNullName);
            });
        }

        [Test]
        public void NewArrivalMethod_WorksCorrectly()
        {
            railwayStation.NewArrivalOnBoard(trainInfo);
            Assert.AreEqual(railwayStation.ArrivalTrains.Count, 1);
            Assert.That(railwayStation.ArrivalTrains.Peek(), Is.EqualTo(trainInfo));
        }

        [Test]
        public void TrainHasArrivedMethod_WorksCorrectly()
        {
            railwayStation = new RailwayStation("test");
            railwayStation.NewArrivalOnBoard(trainInfo);
            string output = railwayStation.TrainHasArrived(trainInfo);

            Assert.AreEqual(output, $"{trainInfo} is on the platform and will leave in 5 minutes.");
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(1));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(0));
        }

        [Test]
        public void TrainHasArrivedMethod_ThrowsExceptionCorrectly()
        {
            railwayStation = new RailwayStation("test");
            railwayStation.NewArrivalOnBoard("lastTrain");
            railwayStation.NewArrivalOnBoard(trainInfo);
            string output = railwayStation.TrainHasArrived(trainInfo);

            Assert.AreEqual(output, $"There are other trains to arrive before {trainInfo}.");
            Assert.That(railwayStation.DepartureTrains.Count, Is.EqualTo(0));
            Assert.That(railwayStation.ArrivalTrains.Count, Is.EqualTo(2));
        }

        [Test]
        public void TestHasLeftMethod_WorksCorrectly()
        {
            railwayStation = new RailwayStation("test");
            railwayStation.NewArrivalOnBoard(trainInfo);
            railwayStation.TrainHasArrived(trainInfo);

            bool result = railwayStation.TrainHasLeft(trainInfo);
            Assert.AreEqual(result, true);
            Assert.AreEqual(railwayStation.DepartureTrains.Count, 0);

            railwayStation.NewArrivalOnBoard(trainInfo);
            railwayStation.TrainHasArrived(trainInfo);
            bool result2 = railwayStation.TrainHasLeft("notValidTrain");
            Assert.AreEqual(result2, false);
            Assert.AreEqual(railwayStation.DepartureTrains.Count, 1);
        }
    }
}