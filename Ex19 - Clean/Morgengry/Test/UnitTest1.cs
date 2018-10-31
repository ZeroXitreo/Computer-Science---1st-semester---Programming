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
        Course c111, c112, c113;
        ValuableRepository repo;

        [TestInitialize]
        public void Init()
        {
            repo = new ValuableRepository();

            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);
            repo.AddValuable(b1);
            repo.AddValuable(b2);
            repo.AddValuable(b3);


            a11 = new Amulet("11");
            a12 = new Amulet("12", Level.high);
            a13 = new Amulet("13", Level.low, "Capricorn");
            repo.AddValuable(a11);
            repo.AddValuable(a12);
            repo.AddValuable(a13);

            c111 = new Course("Eufori med røg");
            c112 = new Course("Nuru Massage using Chia Oil", 1);
            c113 = new Course("Mit møde med mig", 157);
            repo.AddValuable(c111);
            repo.AddValuable(c112);
            repo.AddValuable(c113);
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

        [TestMethod]
        public void AllCourseConstructorsWorkProperly()
        {
            Assert.AreEqual("Name: Eufori med røg, Duration in Minutes: 0, Pris pr påbegyndt time: 825", c111.ToString());
            c112.CourseHourValue = 1100;
            Assert.AreEqual("Name: Nuru Massage using Chia Oil, Duration in Minutes: 1, Pris pr påbegyndt time: 1100", c112.ToString());
            Assert.AreEqual("Name: Mit møde med mig, Duration in Minutes: 157, Pris pr påbegyndt time: 825", c113.ToString());
        }

        [TestMethod]
        public void AllSetPropertiesWorks()
        {
            a13.ItemId = "X";
            a13.Quality = Level.high;
            a13.Design = "Dolphin";

            b3.ItemId = "Y";
            b3.Title = "Smoke on the Water";
            b3.Price = 376.45;

            c112.Name = "How to Ying-Yang";
            c112.DurationInMinutes = 413;

            Assert.AreEqual("ItemId: X, Quality: high, Design: Dolphin", a13.ToString());
            Assert.AreEqual("ItemId: Y, Title: Smoke on the Water, Price: 376.45", b3.ToString());
            Assert.AreEqual("Name: How to Ying-Yang, Duration in Minutes: 413, Pris pr påbegyndt time: 825", c112.ToString());
        }

        [TestMethod]
        public void TestGetValueForBook()
        {
            Assert.AreEqual(b1.GetValue(), 0.0);
            Assert.AreEqual(b2.GetValue(), 0.0);
            Assert.AreEqual(b3.GetValue(), 123.55);
        }

        [TestMethod]
        public void TestGetValueForAmulet()
        {
            Assert.AreEqual(20.0, a11.GetValue());
            Assert.AreEqual(27.5, a12.GetValue());
            Assert.AreEqual(12.5, a13.GetValue());
        }

        [TestMethod]
        public void TestGetValueForCourse()
        {
            Assert.AreEqual(0.0, c111.GetValue());
            c112.CourseHourValue = 1100;
            Assert.AreEqual(1100.0, c112.GetValue());
            Assert.AreEqual(2475.0, c113.GetValue());
        }

        [TestMethod]
        public void TestValuableRepository()
        {
            Assert.AreEqual(9, repo.Count());

            Book dummy = new Book("Dummy");
            repo.AddValuable(dummy);
            Assert.AreEqual(10, repo.Count());

            Book result = (Book)repo.GetValuable("Dummy");
            Assert.AreEqual(dummy, result);

            Assert.AreEqual(3483.55, repo.GetTotalValue());
        }
    }
}
