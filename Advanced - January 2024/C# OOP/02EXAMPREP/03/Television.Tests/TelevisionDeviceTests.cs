namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private string brand = "Sony";
        private double price = 13.4;
        private int screenWidth = 5;
        private int screenHeight = 3;
        private int lastChannel = 0;
        private int lastVolume = 13;
        private bool lastMuted = false;
        private TelevisionDevice televisionDevice;

        [SetUp]
        public void Setup()
        {
            televisionDevice = new TelevisionDevice(brand, price, screenWidth, screenHeight);
        }

        [Test]
        public void CtorWorksCorrectly()
        {
            Assert.That(televisionDevice, Is.Not.Null);
            Assert.AreEqual(televisionDevice.Brand, brand);
            Assert.AreEqual(televisionDevice.Price, price);
            Assert.AreEqual(televisionDevice.ScreenWidth, screenWidth);
            Assert.AreEqual(televisionDevice.ScreenHeigth, screenHeight);
            Assert.AreEqual(televisionDevice.CurrentChannel, lastChannel);
            Assert.AreEqual(televisionDevice.Volume, lastVolume);
            Assert.AreEqual(televisionDevice.IsMuted, lastMuted);
        }

        [Test]
        public void SwitchOnMethod_WorksCorrectly()
        {
            string result = televisionDevice.SwitchOn();
            Assert.AreEqual(result, $"Cahnnel {televisionDevice.CurrentChannel} - Volume {televisionDevice.Volume} - Sound On");
        }

        [Test]
        public void ChangeChannelMethod_WorksCorrectly()
        {
            int channel = 5;
            int result = televisionDevice.ChangeChannel(channel);
            Assert.AreEqual(channel, result);
        }

        [Test]
        public void ChangeChannelMethod_ThrowsExceptionCorrectly()
        {
            int invalidChannel = -1;
            Assert.Throws<ArgumentException>(() =>
            {
                televisionDevice.ChangeChannel(invalidChannel);
            });
        }

        [Test]
        public void MuteDeviceMethod_WorksCorrectly()
        {
            bool result = televisionDevice.MuteDevice();
            Assert.AreEqual(result, true);
            Assert.That(televisionDevice.IsMuted, Is.EqualTo(true));

            bool result2 = televisionDevice.MuteDevice();
            Assert.AreEqual(result2, false);
            Assert.That(televisionDevice.IsMuted, Is.EqualTo(false));
        }

        [Test]
        public void ToStringMethod_WorksCorrectly()
        {
            Assert.AreEqual(televisionDevice.ToString(), $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeight}, Price {price}$");
        }

        [Test]
        public void VolumeChangeMethod_WorksCorrectly()
        {
            string result;
            string expected;
            expected = "Volume: 23";
            result = televisionDevice.VolumeChange("UP", 10);
            Assert.AreEqual(result, expected);

            result = televisionDevice.VolumeChange("UP", 100);
            expected = "Volume: 100";
            Assert.AreEqual(result, expected);

            result = televisionDevice.VolumeChange("DOWN", 10);
            expected = "Volume: 90";
            Assert.AreEqual(result, expected);

            result = televisionDevice.VolumeChange("DOWN", 100);
            expected = "Volume: 0";
            Assert.AreEqual(result, expected);
        }
    }
}