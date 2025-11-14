using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest_ValidType_ReturnsTrue
{
    [TestClass]
    public class UnitTest_ValidType
    {
        [TestMethod]
        public void Test_ValidType_ReturnsTrue()
        {
            Assert.IsTrue(Validators.IsValidType("Автоматическая"));
            Assert.IsTrue(Validators.IsValidType("Полуавтоматическая"));
        }
    }
}
