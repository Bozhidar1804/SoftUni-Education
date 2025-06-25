using System.Collections.Generic;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class DeviceTests
    {
        private int memoryCapacity = 1000;
        private Device device;

        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Ctor_InitializesCorrectly()
        {
            Assert.That(device, Is.Not.Null);
            Assert.AreEqual(device.MemoryCapacity, memoryCapacity);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Photos, 0);
            Assert.That(device.Applications, Is.Not.Null);
        }

        [Test]
        public void TakePhotoMethod_WorksCorrectly()
        {
            int photoSize = 100;
            int availableMemoryBefore = device.AvailableMemory;
            bool result = device.TakePhoto(photoSize);
            Assert.AreEqual(result, true);
            Assert.AreEqual(device.AvailableMemory, availableMemoryBefore - photoSize);
            Assert.AreEqual(device.Photos, 1);

            int photoSize2 = 900;
            int availableMemoryBefore2 = device.AvailableMemory;
            bool result2 = device.TakePhoto(photoSize2);
            Assert.AreEqual(result2, true);
            Assert.AreEqual(device.AvailableMemory, availableMemoryBefore2 - photoSize2);
            Assert.AreEqual(device.Photos, 2);

            int invalidPhotoSize = 1100;
            bool result3 = device.TakePhoto(invalidPhotoSize);
            Assert.AreEqual(result3, false);
        }

        [Test]
        public void InstallAppMethod_WorksCorrectly()
        {
            string appName = "Brawl stars";
            int appSize = 500;
            int availableMemoryBefore = device.AvailableMemory;
            string result = device.InstallApp(appName, appSize);
            Assert.AreEqual(result, $"{appName} is installed successfully. Run application?");
            Assert.AreEqual(device.Applications.Count, 1);
            Assert.AreEqual(device.AvailableMemory, availableMemoryBefore - appSize);

            int availableMemoryBefore2 = device.AvailableMemory;
            string result2 = device.InstallApp(appName, appSize);
            int expectedLeftMemory = 0;
            Assert.AreEqual(result2, $"{appName} is installed successfully. Run application?");
            Assert.AreEqual(device.Applications.Count, 2);
            Assert.AreEqual(device.AvailableMemory, availableMemoryBefore2 - appSize);
            Assert.AreEqual(device.AvailableMemory, expectedLeftMemory);
        }

        [Test]
        public void InstallAppMethod_ThrowsExceptionCorrectly()
        {
            string appName = "Brawl stars";
            int appSize = 1001;
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
            {
                device.InstallApp(appName, appSize);
            });
            string message = "Not enough available memory to install the app.";
            Assert.AreEqual(exception.Message, message);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
            Assert.AreEqual(device.Applications.Count, 0);
        }

        [Test]
        public void FormatDeviceMethod_WorksCorrectly()
        {
            int memoryCapacity = 2048;
            device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyFirstApp", 200);

            device.FormatDevice();
            Assert.AreEqual(device.Photos, 0);
            Assert.AreEqual(device.Applications.Count, 0);
            Assert.AreEqual(device.AvailableMemory, memoryCapacity);
        }

        [Test]
        public void GetDeviceStatusMethod_WorksCorrectly()
        {
            int memoryCapacity = 2048;
            device = new Device(memoryCapacity);
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyFirstApp", 200);
            device.InstallApp("MySecondApp", 300);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity - photoSize - 200 - 300} MB");
            stringBuilder.AppendLine($"Photos Count: 1");
            stringBuilder.AppendLine($"Applications Installed: MyFirstApp, MySecondApp");

            string expected = stringBuilder.ToString().TrimEnd();
            string actual = device.GetDeviceStatus();

            Assert.AreEqual(expected, actual);
            Assert.That(actual, Is.Not.Null);
        }
    }
}