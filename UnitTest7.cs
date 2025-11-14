using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;

namespace UnitTest_CreateWashingMachineObject
{
    [TestClass]
    public class CreateWashingMachineObject
    {
        [TestMethod]
        public void Test_CreateWashingMachine()
        {
            var wm = new WashingMachine("Samsung", "WW80J5555", 499.99, "Белый", 8, "Автоматическая");
            Assert.AreEqual("Samsung", wm.Manufacturer);
            Assert.AreEqual(8, wm.LoadCapacity);
            Assert.AreEqual("Автоматическая", wm.Type);
        }
    }
}