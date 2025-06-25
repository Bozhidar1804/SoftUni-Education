using NUnit.Framework;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace VendingRetail.Tests
{
    public class Tests
    {
        private int waterCapacity = 100;
        private int buttonsCount = 2;
        private CoffeeMat coffeeMat;
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            coffeeMat = new CoffeeMat(waterCapacity, buttonsCount);
            Assert.That(coffeeMat, Is.Not.Null);
            Assert.AreEqual(coffeeMat.WaterCapacity, 100);
            Assert.AreEqual(coffeeMat.ButtonsCount, 2);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void FillEmptyTank()
        {
            coffeeMat = new CoffeeMat(100, 1);
            string result = coffeeMat.FillWaterTank();

            Assert.AreEqual(result, $"Water tank is filled with 100ml");
            Assert.AreEqual(coffeeMat.WaterCapacity, 100);

        }

        [Test]
        public void FillFullTank()
        {
            coffeeMat = new CoffeeMat(100, 1);

            coffeeMat.FillWaterTank();
            string actualResult = coffeeMat.FillWaterTank();
            string expectedResult = "Water tank is already full!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddDrinksToDictionary()
        {
            coffeeMat = new CoffeeMat(100, 3);
            bool result = coffeeMat.AddDrink("Water", 1.20);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddDrinksToExceedCapacityOfDictionary()
        {
            coffeeMat = new CoffeeMat(100, 3);
            coffeeMat.AddDrink("Water", 1.20);
            coffeeMat.AddDrink("Cola", 1.30);
            coffeeMat.AddDrink("Fanta", 1.40);
            bool result = coffeeMat.AddDrink("Pepsi", 1.60);
            Assert.IsFalse(result);
        }

        [Test]
        public void BuyDrinkOutOfWaterCase()
        {
            coffeeMat = new CoffeeMat(70, 1);
            string expectedResult = "CoffeeMat is out of water!";
            string result = coffeeMat.BuyDrink("Test");
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void BuyExistingDrink()
        {
            coffeeMat = new CoffeeMat(100, 1);
            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Water", 1.20);
            string expectedResult = $"Your bill is 1.20$";
            string result = coffeeMat.BuyDrink("Water");

            Assert.AreEqual(result, expectedResult);
            Assert.AreEqual(coffeeMat.Income, 1.20);

            string fillTankExpected = $"Water tank is filled with 80ml";
            string fillTankActual = coffeeMat.FillWaterTank();
            Assert.AreEqual(fillTankExpected, fillTankActual);
        }

        [Test]
        public void BuyUnavailableDrink()
        {
            coffeeMat = new CoffeeMat(100, 1);

            coffeeMat.AddDrink("Coffee", 0.80);
            coffeeMat.AddDrink("Macciato", 1.80);
            coffeeMat.FillWaterTank();

            string expected = "Late is not available!";
            string result = coffeeMat.BuyDrink("Late");
            Assert.AreEqual(result, expected);
            Assert.AreEqual(coffeeMat.Income, 0);
        }

        [Test]
        public void CollectIncomeMethod_WorksCorrectly()
        {
            coffeeMat = new CoffeeMat(1000, 5);

            double expected = coffeeMat.Income;
            double result = coffeeMat.CollectIncome();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(coffeeMat.Income, 0);

            coffeeMat.FillWaterTank();
            coffeeMat.AddDrink("Coffee", 1.10);
            coffeeMat.AddDrink("Macciato", 1.10);
            coffeeMat.AddDrink("Capuccino", 1.10);
            coffeeMat.AddDrink("Latte", 1.10);
            coffeeMat.AddDrink("Hot Chocolate", 1.10);

            coffeeMat.BuyDrink("Coffee");
            coffeeMat.BuyDrink("Macciato");
            coffeeMat.BuyDrink("Capuccino");
            coffeeMat.BuyDrink("Latte");
            coffeeMat.BuyDrink("Hot Chocolate");

            double beforeCollectingIncome = coffeeMat.Income;
            double result2 = coffeeMat.CollectIncome();
            double afterCollectingIncome = coffeeMat.Income;

            Assert.AreEqual(beforeCollectingIncome, 5.50);
            Assert.AreEqual(result2, beforeCollectingIncome);
            Assert.AreEqual(afterCollectingIncome, 0);
        }
    }
}