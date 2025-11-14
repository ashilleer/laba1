using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;

namespace UnitTests1
{
    [TestClass]
    public class UnitTest_InvalidColor
    {
        [TestMethod]
        public void Test_InvalidColor_ReturnsFalse()
        {
            Assert.IsFalse(Validators.IsValidColor("Зеленый"));
            Assert.IsFalse(Validators.IsValidColor(""));
            Assert.IsFalse(Validators.IsValidColor(null));
        }
    }
}