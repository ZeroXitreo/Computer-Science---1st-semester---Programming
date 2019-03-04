using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Searching;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {        /*--------------------------------------------------*/
        /* Linear search tests of FindPositionInList_Linear */
        /*--------------------------------------------------*/

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_01()
        {
            // Arrange
            int[] data = { 24, 37, 1, 21, 5, 8, 4, 31, 32, 17 };
            int value = 21;
            int expectedPosition = 3;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_02()
        {
            // Arrange
            int[] data = { 24, 37, 1, 21, 5, 8, 4, 31, 32, 17 };
            int value = 4;
            int expectedPosition = 6;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_03()
        {
            // Arrange
            int[] data = { 24, 37, 1, 21, 5, 8, 4, 31, 32, 17 };
            int value = 20;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_04()
        {
            // Arrange
            int[] data = { 24, 37, 1, 21, 5, 8, 4, 31, 32, 17 };
            int value = 24;
            int expectedPosition = 0;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_05()
        {
            // Arrange
            int[] data = { 24, 37, 1, 21, 5, 8, 4, 31, 32, 17 };
            int value = 17;
            int expectedPosition = data.Length - 1;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_06()
        {
            // Arrange
            int[] data = { 5 };
            int value = 5;
            int expectedPosition = 0;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_07()
        {
            // Arrange
            int[] data = { 5 };
            int value = 6;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }

        [TestMethod()]
        public void FindPositionInList_Unsorted_LinearTest_08()
        {
            // Arrange
            int[] data = { };
            int value = 5;
            int expectedPosition = -1;
            // Act
            int foundPosition = Search.FindPositionInList_Linear(data, value);
            // Assert
            Assert.AreEqual(expectedPosition, foundPosition);
        }
    }
}
