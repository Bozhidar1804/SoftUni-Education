using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        private static string usernameBozhidar = "Bozhidar";
        private static int followersBozhidar = 50;
        private static Influencer influencer = new Influencer(usernameBozhidar, followersBozhidar);
        private InfluencerRepository influencerRepository;
        private List<Influencer> data;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            influencerRepository = new InfluencerRepository();
            Assert.That(influencerRepository.Influencers, Is.Not.Null);
            Assert.AreEqual(influencerRepository.Influencers.Count, 0);
        }

        [Test]
        public void RegisterInvalidInfluencer()
        {
            influencerRepository = new InfluencerRepository();
            Influencer testInfluencer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RegisterInfluencer(testInfluencer);
            });
            Assert.AreEqual(influencerRepository.Influencers.Count, 0);
        }

        [Test]
        public void RegisterAlreadyAddedInfluencer()
        {
            influencerRepository = new InfluencerRepository();
            influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                influencerRepository.RegisterInfluencer(influencer);
            });
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }

        [Test]
        public void RegisterSuccess()
        {
            influencerRepository = new InfluencerRepository();
            string expected = $"Successfully added influencer Bozhidar with 50";
            string actual = influencerRepository.RegisterInfluencer(influencer);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(influencerRepository.Influencers.Count, 1);
        }

        [Test]
        public void RemoveNullInfluencer()
        {
            influencerRepository = new InfluencerRepository();
            string invalidUsername = null;
            influencerRepository.RegisterInfluencer(influencer);
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RemoveInfluencer(invalidUsername);
            });
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveWhiteSpaceInfluencer()
        {
            influencerRepository = new InfluencerRepository();
            string invalidUsername = " ";
            influencerRepository.RegisterInfluencer(influencer);
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
            Assert.Throws<ArgumentNullException>(() =>
            {
                influencerRepository.RemoveInfluencer(invalidUsername);
            });
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveReturnsTrue()
        {
            influencerRepository = new InfluencerRepository();
            string existingUsername = "Bozhidar";
            influencerRepository.RegisterInfluencer(influencer);
            bool result = influencerRepository.RemoveInfluencer(existingUsername);
            Assert.True(result);
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveReturnsFalse()
        {
            influencerRepository = new InfluencerRepository();
            string notExistingUsername = "Georgi";
            influencerRepository.RegisterInfluencer(influencer);
            bool result = influencerRepository.RemoveInfluencer(notExistingUsername);
            Assert.False(result);
            Assert.That(influencerRepository.Influencers.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetInfluencerWithMostFollowers_ReturnsCorrectly()
        {
            influencerRepository = new InfluencerRepository();
            Influencer influencerLeast = new Influencer("Bozhidar", 50);
            Influencer influencerMid = new Influencer("Georgi", 100);
            Influencer influencerMost = new Influencer("Ivan", 150);
            influencerRepository.RegisterInfluencer(influencerLeast);
            influencerRepository.RegisterInfluencer(influencerMid);
            influencerRepository.RegisterInfluencer(influencerMost);

            Influencer returnedInfluencer = influencerRepository.GetInfluencerWithMostFollowers();
            Assert.That(returnedInfluencer, Is.Not.Null);
            Assert.AreEqual(returnedInfluencer.Username, "Ivan");
            Assert.AreEqual(returnedInfluencer.Followers, 150);
            Assert.AreEqual(returnedInfluencer, influencerMost);
        }

        [Test]
        public void GetInfluencerByName()
        {
            influencerRepository = new InfluencerRepository();
            Influencer firstInf = new Influencer("Bozhidar", 50);
            Influencer secondInf = new Influencer("Georgi", 100);
            Influencer thidInf = new Influencer("Ivan", 150);
            influencerRepository.RegisterInfluencer(firstInf);
            influencerRepository.RegisterInfluencer(secondInf);
            influencerRepository.RegisterInfluencer(thidInf);
            string validName = "Georgi";

            Influencer returnedInfluencer = influencerRepository.GetInfluencer(validName);
            Assert.That(returnedInfluencer, Is.Not.Null);
            Assert.AreEqual(returnedInfluencer.Username, "Georgi");
            Assert.AreEqual(returnedInfluencer.Followers, 100);
            Assert.AreEqual(returnedInfluencer, secondInf);
        }
    }
}