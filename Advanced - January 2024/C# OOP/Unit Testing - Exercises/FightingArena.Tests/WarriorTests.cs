using System;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;
        private string validName = "ValidWarrior";
        private int validDamage = 10;
        private int validHp = 50;
        private Warrior warrior;

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            warrior = new Warrior(validName, validDamage, validHp);
            Assert.That(warrior, Is.Not.Null);
            Assert.AreEqual(warrior.Name, validName);
            Assert.AreEqual(warrior.Damage, validDamage);
            Assert.AreEqual(warrior.HP, validHp);
        }

        [Test]
        public void NameSetter_ThrowsExceptionCorrectly()
        {
            string invalidName = null;
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(invalidName, validDamage, validHp);
            });
        }

        [Test]
        public void DamageSetter_ThrowsExceptionCorrectly()
        {
            int invalidDamage = 0;
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(validName, invalidDamage, validHp);
            });
        }

        [Test]
        public void HPSetter_ThrowsExceptionCorrectly()
        {
            int invalidHp = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                warrior = new Warrior(validName, validDamage, invalidHp);
            });
        }

        [Test]
        public void AttackMethod_WorksCorrectly()
        {
            warrior = new Warrior(validName, validDamage, validHp);
            Warrior warrior2 = new Warrior("Warrior2", 10, 50);
            warrior.Attack(warrior2);
            Assert.AreEqual(warrior2.HP, warrior.HP);

            Warrior warrior3 = new Warrior("Warrior3", 41, 35);
            warrior3.Attack(warrior2);
            Assert.That(warrior2.HP, Is.EqualTo(0));

            Warrior warrior4 = new Warrior("Warrior4", 10, 35);
            Warrior warrior5 = new Warrior("Warrior5", 41, 35);
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior4.Attack(warrior5);
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior2.Attack(warrior3);
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(warrior2);
            });
        }
    }
}