using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitFullCodeTest
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void Validators_Correct()
        {
            Assert.IsTrue(Validators.IsValidColor("Черный"));
            Assert.IsTrue(Validators.IsValidType("Автоматическая"));
            Assert.IsTrue(Validators.IsValidLoadCapacity(5));
        }

        [TestMethod]
        public void Create_WashingMachine_Succeeds()
        {
            var wm = new WashingMachine("M", "X", 100, "Белый", 3, "Автоматическая");
            Assert.AreEqual("M", wm.Manufacturer);
        }

        [TestMethod]
        public void Create_Dishwasher_Succeeds()
        {
            var dw = new Dishwasher("M", "Y", 200, "Серый", 2, false);
            Assert.AreEqual(2, dw.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Create_WashingMachine_InvalidLoad_Throws()
        {
            new WashingMachine("M", "X", 100, "Белый", 0, "Автоматическая");
        }
    }
}