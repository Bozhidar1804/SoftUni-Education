using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[2] { 1, 2 };
        private int[] data = new int[16];

        [SetUp]
        public void SetUp()
        { 
            database = new Database(initialData);
        }

        [Test]
        public void Ctor_EmptyDatabaseInitializesCorrectly()
        {
            Database database = new Database();
            Assert.That(database, Is.Not.Null);
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_DatabaseInitializesCorrectly()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }

            Database database = new Database(data);
            Assert.That(database, Is.Not.Null);
        }

        [Test]
        public void CollectionLength()
        {
            int actualLength = 2;
            Assert.AreEqual(initialData.Length, actualLength);
        }

        [Test]
        public void AddMethod_WorksCorrectly()
        {
            int expectedCount = 3;
            database.Add(3);
            Assert.AreEqual(database.Count, expectedCount);
        }

        [Test]
        public void AddMethod_ThrowsExceptionCorrectly()
        {
            int magicNumber = 16;
            for (int i = database.Count; i < 16; i++)
            {
                database.Add(magicNumber);
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(magicNumber);
            });
        }

        [Test]
        public void RemoveMethod_WorksCorrectly()
        {
            int expectedLength = 1;
            database.Remove();
            Assert.AreEqual(database.Count, expectedLength);
        }

        [Test]
        public void RemoveMethod_ThrowsExceptionCorrectly()
        {
            for (int i = database.Count - 1; i >= 0; i--)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Remove();
            });
        }

        [Test]
        public void FetchMethod_WorksCorrectly()
        {
            int[] fetchedArray = database.Fetch();
            CollectionAssert.AreEqual(initialData, fetchedArray);
        }
    }
}
