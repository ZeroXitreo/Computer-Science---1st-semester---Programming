using System;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShiftStringTest01()
        {
            // Arrange
            string original = "This is my life";
            // Act
            string shifted = original.Shift(0);
            // Assert
            Assert.AreEqual("This is my life", shifted);
        }
        [TestMethod]
        public void ShiftStringTest02()
        {
            // Arrange
            string original = "This is my life";
            // Act
            string shifted = original.Shift(1);
            // Assert
            Assert.AreEqual("eThis is my lif", shifted);
        }
        [TestMethod]
        public void ShiftStringTest03()
        {
            // Arrange
            string original = "This is my life";
            // Act
            string shifted = original.Shift(5);
            // Assert
            Assert.AreEqual(" lifeThis is my", shifted);
        }
        [TestMethod]
        public void ShiftStringTest04()
        {
            // Arrange
            string original = "This is my life";
            // Act
            string shifted = original.Shift(14);
            // Assert
            Assert.AreEqual("his is my lifeT", shifted);
        }
        [TestMethod]
        public void ShiftStringTest05()
        {
            // Arrange
            string original = "This is my life";
            // Act
            string shifted = original.Shift(15);
            // Assert
            Assert.AreEqual("This is my life", shifted);
        }
    }
}
