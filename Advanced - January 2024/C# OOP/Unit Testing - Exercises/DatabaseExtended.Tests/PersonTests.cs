using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedDatabase;
using NUnit.Framework;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private string validNamePesho = "pesho";
        private int validIdPesho = 1;

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            Person personPesho = new Person(validIdPesho, validNamePesho);
            Assert.That(personPesho, Is.Not.Null);
            Assert.AreEqual(personPesho.Id, validIdPesho);
            Assert.AreEqual(personPesho.UserName, validNamePesho);
        }
    }
}
