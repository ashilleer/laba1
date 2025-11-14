using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;

namespace UnitTest_ValidColor_ReturnsTrue
{
    [TestClass]
    public class UnitTest_ValidColor
    {
        [TestMethod]
        public void Test_ValidColor_ReturnsTrue()
        {
            Assert.IsTrue(Validators.IsValidColor("Черный"));
            Assert.IsTrue(Validators.IsValidColor("Белый"));
        }
    }
}