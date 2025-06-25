using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 3);
            dummy = new Dummy(10, 10);
        }
        [Test]
        public void AxeLosesDurabilityCorrectle()
        {
            axe.Attack(dummy);

            Assert.AreEqual(axe.DurabilityPoints, 2, "Axe durability doesn't reduce after attack.");
        }

        [Test]
        public void AttackingWithABrokenWeapon()
        {
            axe = new Axe(10, -10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }
    }
}