using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private string addRangeExpectedException = "Provided data length should be in range [0..16]!";
        private int overflowingPeopleCapacity = 17;
        private int maxPeople = 16;
        private string validNamePesho = "pesho";
        private long validIdPesho = 1;
        private string validNameIvan = "ivan";
        private long validIdIvan = 2;
        private Database sut;

        [SetUp]
        public void SetUp()
        {
            Person pesho = new Person(validIdPesho, validNamePesho);
            Person ivan = new Person(validIdIvan, validNameIvan);
            Person[] people = new Person[] { pesho, ivan }; 
            sut = new Database(people);
        }

        [Test]
        public void Ctor_WithoutParams_InitializesCorrectly()
        {
            Database database = new Database();
            int expectedCount = 0;
            Assert.That(database, Is.Not.Null);
            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void Ctor_WithParams_InitializesCorrectly()
        {
            int expectedLength = 2;
            Assert.That(sut, Is.Not.Null);
            Assert.AreEqual(sut.Count, expectedLength);
        }

        [Test]
        public void Ctor_WithTooManyPeople_ThrowsExceptionCorrectly()
        {
            Person[] overflowingPeople = new Person[overflowingPeopleCapacity];
            for (int i = 0; i < overflowingPeopleCapacity; i++)
            {
                overflowingPeople[i] = new Person(validIdIvan + i, validNameIvan + "i");
            }
            ArgumentException ae = Assert.Throws<ArgumentException>(() =>
            {
                sut = new Database(overflowingPeople);
            });
            Assert.AreEqual(ae.Message, addRangeExpectedException);
        }

        [Test]
        public void AddMethod_ThrowsExceptionsCorrectly()
        {
            Person[] maxPeople = new Person[this.maxPeople];
            for (int i = 0; i < maxPeople.Length; i++)
            {
                maxPeople[i] = new Person(validIdIvan + i, validNameIvan + $"{i}");
            }
            sut = new Database(maxPeople);

            int overflowingPersonId = 333;
            string overflowingPersonName = "Test";
            Person overflowingPerson = new Person(overflowingPersonId, overflowingPersonName);
            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(overflowingPerson);
            });

            sut.Remove();
            sut.Remove(); //making space for test person at the last index;
            int lastPersonId = 100;
            string lastPersonName = "Last";
            Person lastPerson = new Person(lastPersonId, lastPersonName);
            sut.Add(lastPerson);
            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(new Person(lastPersonId, "Test"));
            });
            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(new Person(111, lastPersonName));
            });
        }

        [Test]
        public void RemoveMethod_ThrowsExceptionCorrectly()
        {
            sut = new Database(new Person[0]);
            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Remove();
            });
        }

        [Test]
        public void FindByUsernameMethod_WorksCorrectly()
        {
            Person ivanFound = sut.FindByUsername(validNameIvan);
            Assert.That(ivanFound, Is.Not.Null);
            Assert.AreEqual(ivanFound.Id, validIdIvan);
            Assert.AreEqual(ivanFound.UserName, validNameIvan);
        }

        [Test]
        public void FindByUsernameMethod_ThrowsExceptionsCorrectly()
        {
            string nullString = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                Person person = sut.FindByUsername(nullString);
            });

            string invalidName = "invalid";
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = sut.FindByUsername(invalidName);
            });
        }

        [Test]
        public void FindByIdMethod_WorksCorrectly()
        {
            Person ivanFound = sut.FindById(validIdIvan);
            Assert.That(ivanFound, Is.Not.Null);
            Assert.AreEqual(ivanFound.UserName, validNameIvan);
            Assert.AreEqual(ivanFound.Id, validIdIvan);
        }

        [Test]
        public void FindByIdMethod_ThrowsExceptionsCorrectly()
        {
            long invalidId = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Person person = sut.FindById(invalidId);
            });

            invalidId = 77;
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person person = sut.FindById(invalidId);
            });
        }
    }
}