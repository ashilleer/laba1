using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_InvalidDisplayType_ReturnsFalse
{
    [TestClass]
    public class UnitTest_InvalidLoadCapacity
    {
        [TestMethod]
        public void Test_InvalidLoadCapacity()
        {
            Assert.IsFalse(Validators.IsValidLoadCapacity(0));
            Assert.IsFalse(Validators.IsValidLoadCapacity(-3));
            Assert.IsFalse(Validators.IsValidLoadCapacity(15)); // превышает допустимый максимум
        }
    }
}