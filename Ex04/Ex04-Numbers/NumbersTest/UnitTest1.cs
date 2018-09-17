using System;
using Ex04_Numbers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumbersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestArea12()
        {
            Assert.AreEqual(12, Numbers.RectangleArea(3, 4));
        }
        [TestMethod]
        public void TestArea24()
        {
            Assert.AreEqual(24, Numbers.RectangleArea(12, 2));
        }
        [TestMethod]
        public void TestArea51()
        {
            Assert.AreEqual(51, Numbers.RectangleArea(17, 3));
        }


        [TestMethod]
        public void TestSumOfIntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(24, Numbers.Sum(ints));
        }

        [TestMethod]
        public void TestMinOfIntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(1, Numbers.Min(ints));
        }

        [TestMethod]
        public void TestMaxOfIntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(9, Numbers.Max(ints));
        }


        [TestMethod]
        public void TestCheck5IntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(true, Numbers.Contains(5, ints));
        }

        [TestMethod]
        public void TestCheck3IntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(false, Numbers.Contains(3, ints));
        }

        [TestMethod]
        public void TestCheck6IntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.IsTrue(Numbers.Contains(9, ints));
        }

        [TestMethod]
        public void TestCheck7IntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.IsFalse(Numbers.Contains(8, ints));
        }


        [TestMethod]
        public void TestAverageOfIntArray()
        {
            int[] ints = { 5, 9, 2, 7, 1 };

            Assert.AreEqual(4.8, Numbers.Average(ints));
        }


        [TestMethod]
        public void TestLineLength()
        {
            int xa = 5;
            int ya = 5;
            int xb = 5;
            int yb = 10;

            Assert.AreEqual(5, Numbers.LineLength(xa, ya, xb, yb));
        }


        [TestMethod]
        public void TestPolyline15Length()
        {
            int[] xCoords = { 5, 5, 10, 10 };
            int[] yCoords = { 5, 10, 10, 5 };

            Assert.AreEqual(15, Numbers.PolylineLength(xCoords, yCoords));
        }

        [TestMethod]
        public void TestPolyline11Length()
        {
            int[] xCoords = { 3, 5, 7, 5, 3 };
            int[] yCoords = { 3, 5, 3, 1, 3 };

            Assert.AreEqual(11.313, Numbers.PolylineLength(xCoords, yCoords), 0.001);
        }

    }
}
