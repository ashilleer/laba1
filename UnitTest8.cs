using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_CreateDishwasherObject
{
    [TestClass]
    public class CreateDishwasherObject
    {
        [TestMethod]
        public void Test_CreateDishwasher()
        {
            var dw = new Dishwasher("Bosch", "SMV46KX01R", 599.99, "Серый", 14, true);
            Assert.AreEqual("Bosch", dw.Manufacturer);
            Assert.AreEqual(14, dw.Capacity);
            Assert.IsTrue(dw.HasDrying);
        }
    }
}