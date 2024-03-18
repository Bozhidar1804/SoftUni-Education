using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [Test]
        public void DummyLosesHealthCorrectly()
        {
            dummy.TakeAttack(2);
            Assert.AreEqual(dummy.Health, 8);
        }

        [Test]
        public void DeadDummyThrowsAnException()
        {
            dummy = new Dummy(-10, 10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);
            });
        }

        [Test]
        public void DeadDummyGivesXP()
        {
            dummy = new Dummy(-10, 10);

            Assert.AreEqual(dummy.GiveExperience(), 10);
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}