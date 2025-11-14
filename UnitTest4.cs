using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;

namespace UnitTest_InvalidType_ReturnsFalse
{
    [TestClass]
    public class UnitTest_InvalidType
    {
        [TestMethod]
        public void Test_InvalidType_ReturnsFalse()
        {
            Assert.IsFalse(Validators.IsValidType("Робот"));
            Assert.IsFalse(Validators.IsValidType(""));
            Assert.IsFalse(Validators.IsValidType(null));
        }
    }
}