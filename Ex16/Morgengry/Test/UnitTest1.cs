using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morgengry;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Book b1, b2, b3;
        Amulet a11, a12, a13;

        [TestInitialize]
        public void Init()
        {
            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);

            a11 = new Amulet("11");
            a12 = new Amulet("12", Level.high);
            a13 = new Amulet("13", Level.low, "Capricorn");
        }

        [TestMethod]
        public void AllBookConstructorsWorkProperly()
        {
            Assert.AreEqual("ItemId: 1, Title: , Price: 0", b1.ToString());
            Assert.AreEqual("ItemId: 2, Title: Falling in Love with Yourself, Price: 0", b2.ToString());
            Assert.AreEqual("ItemId: 3, Title: Spirits in the Night, Price: 123.55", b3.ToString());
        }

        [TestMethod]
        public void AllAmuletConstructorsWorkProperly()
        {
            Assert.AreEqual("ItemId: 11, Quality: medium, Design: ", a11.ToString());
            Assert.AreEqual("ItemId: 12, Quality: high, Design: ", a12.ToString());
            Assert.AreEqual("ItemId: 13, Quality: low, Design: Capricorn", a13.ToString());
        }
    }

}
