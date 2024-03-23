using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Warrior strongestWarrior = new Warrior("Strongest", 50, 50);
        private Warrior weakestWarrior = new Warrior("Weakest", 10, 50);
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            arena = new Arena();
            Assert.That(arena, Is.Not.Null);
            Assert.AreEqual(arena.Count, 0);
            Assert.That(arena.Warriors, Is.Not.Null);
        }

        [Test]
        public void EnrollMethod_WorksAndThrowsCorrectly()
        {
            arena = new Arena();
            Warrior addedWarrior = new Warrior("Added", 10, 31);
            arena.Enroll(addedWarrior);
            Assert.That(arena.Count, Is.EqualTo(1));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(addedWarrior);
            });
        }

        [Test]
        public void FightMethod_WorksCorrectly()
        {
            arena = new Arena();
            arena.Enroll(strongestWarrior);
            arena.Enroll(weakestWarrior);
            arena.Fight("Weakest", "Strongest");
            Assert.That(strongestWarrior.HP, Is.EqualTo(40));
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("invalid", "Weakest");
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Weakest", "invalid");
            });
        }
    }
}
