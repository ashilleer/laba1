using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_ValidLoadCapacity_ReturnsTrue
{
    [TestClass]
    public class UnitTest_ValidLoadCapacity
    {
        [TestMethod]
        public void Test_ValidLoadCapacity()
        {
            Assert.IsTrue(Validators.IsValidLoadCapacity(5));
            Assert.IsTrue(Validators.IsValidLoadCapacity(7));
        }
    }
}
