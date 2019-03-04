using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Searching;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {        /*--------------------------------------------------*/
        /* Binary search tests of FindPositionInList_Binary */
        /*--------------------------------------------------*/

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_01()
        {
            // Arrange
            int[] data = { 4, 7, 10, 11, 15, 18, 24, 31, 32, 40 };
            int value = 11;
            int expectedPosition = 3;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_02()
        {
            // Arrange
            int[] data = { 4, 7, 10, 11, 15, 18, 24, 31, 32, 40 };
            int value = 31;
            int expectedPosition = 7;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_03()
        {
            // Arrange
            int[] data = { 4, 7, 10, 11, 15, 18, 24, 31, 32, 40 };
            int value = 4;
            int expectedPosition = 0;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_04()
        {
            // Arrange
            int[] data = { 4, 7, 10, 11, 15, 18, 24, 31, 32, 40 };
            int value = 40;
            int expectedPosition = data.Length - 1;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_05()
        {
            // Arrange
            int[] data = { 4, 7, 10, 11, 15, 18, 24, 31, 32, 40 };
            int value = 13;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_06()
        {
            // Arrange
            int[] data = { 8 };
            int value = 8;
            int expectedPosition = 0;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_07()
        {
            // Arrange
            int[] data = { 8 };
            int value = 9;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Sorted_BinaryTest_08()
        {
            // Arrange
            int[] data = { };
            int value = 9;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Binary(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }
    }
}
