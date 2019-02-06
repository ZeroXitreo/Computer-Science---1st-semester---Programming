using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateClassLibrary;

namespace DateUnitTestProject
{
    [TestClass]
    public class UnitTestDate
    {
        [TestMethod]
        public void TestMethod_DateConstructor()
        {
            UclDate aDate = new UclDate(2019, 2, 6);
            Assert.IsNotNull(aDate, "UclDate Constructor is not working");
        }

        [TestMethod]
        public void TestMethod_DateConstructorNoParameters()
        {
            UclDate aDate = new UclDate();
            Assert.IsNull(aDate, "UclDate Constructor is able to initiate without a date");
        }

        [TestMethod]
        public void TestMethod_GetYear()
        {
            UclDate date = new UclDate(2019, 11, 6);
            Assert.AreEqual(2019, date.GetYear());

            date = new UclDate(20019, 12, 20);
            Assert.AreEqual(20019, date.GetYear());

            date = new UclDate(-357, 12, 20);
            Assert.AreEqual(-357, date.GetYear());
        }

        [TestMethod]
        public void TestMethod_SetYear()
        {
            UclDate date = new UclDate(2019, 3, 22);
            Assert.AreEqual(2019, date.GetYear());

            date.SetYear(200);
            Assert.AreEqual(200, date.GetYear());

            date.SetYear(12901);
            Assert.AreEqual(12901, date.GetYear());
        }

        [TestMethod]
        public void TestMethod_GetMonth()
        {
            UclDate date = new UclDate(2019, 9, 6);
            Assert.AreEqual(9, date.GetMonth());

            date = new UclDate(2019, 12, 3);
            Assert.AreEqual(12, date.GetMonth());
        }

        [TestMethod]
        public void TestMethod_SetMonth()
        {
            UclDate date = new UclDate(2019, 3, 22);
            Assert.AreEqual(3, date.GetMonth());

            date.SetMonth(6);
            Assert.AreEqual(6, date.GetMonth());

            date.SetMonth(11);
            Assert.AreEqual(11, date.GetMonth());
        }

        [TestMethod]
        public void TestMethod_SetMonthExtremeCase()
        {
            UclDate date = new UclDate(2019, 30, 22);
            Assert.AreNotEqual(30, date.GetMonth());

            date.SetMonth(60);
            Assert.AreNotEqual(60, date.GetMonth());

            date.SetMonth(-1);
            Assert.AreNotEqual(-1, date.GetMonth());
        }

        [TestMethod]
        public void TestMethod_GetDay()
        {
            UclDate date = new UclDate(2019, 3, 22);
            Assert.AreEqual(22, date.GetDay());

            date = new UclDate(2019, 3, 12);
            Assert.AreEqual(12, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_SetDay()
        {
            UclDate date = new UclDate(2019, 3, 21);
            Assert.AreEqual(21, date.GetDay());

            date.SetDay(2);
            Assert.AreEqual(2, date.GetDay());

            date.SetDay(28);
            Assert.AreEqual(28, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_SetDayExtremeCase()
        {
            UclDate date = new UclDate(2019, 3, 21);
            Assert.AreEqual(21, date.GetDay());

            date.SetDay(200);
            Assert.AreNotEqual(200, date.GetDay());

            date.SetDay(-10);
            Assert.AreNotEqual(-10, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_GetDatoStringYMD()
        {
            UclDate date = new UclDate(2019, 2, 6);
            Assert.AreEqual("2019-02-06", date.GetDatoStringYMD());

            date = new UclDate(20019, 2, 6);
            Assert.AreEqual("20190-02-06", date.GetDatoStringYMD());
        }

        [TestMethod]
        public void TestMethod_GetDatoStringDMY()
        {
            UclDate date = new UclDate(2022, 2, 26);
            Assert.AreEqual("06/02/22", date.GetDatoStringDMY());
        }

        [TestMethod]
        public void TestMethod_GetQuater()
        {
            UclDate date = new UclDate(2022, 2, 26);
            Assert.AreEqual(1, date.GetQuater());

            date = new UclDate(2022, 4, 26);
            Assert.AreEqual(2, date.GetQuater());

            date = new UclDate(2022, 8, 26);
            Assert.AreEqual(3, date.GetQuater());

            date = new UclDate(2022, 10, 26);
            Assert.AreEqual(4, date.GetQuater());
        }

        [TestMethod]
        public void TestMethod_GetMonthTxt()
        {
            UclDate date = new UclDate(2022, 1, 26);
            Assert.AreEqual("Januar", date.GetMonthTxt());

            date.SetMonth(2);
            Assert.AreEqual("Februar", date.GetMonthTxt());

            date = new UclDate(2022, 3, 26);
            Assert.AreEqual("Marts", date.GetMonthTxt());

            date = new UclDate(2022, 4, 26);
            Assert.AreEqual("April", date.GetMonthTxt());

            date.SetMonth(5);
            Assert.AreEqual("Maj", date.GetMonthTxt());

            date = new UclDate(2022, 6, 26);
            Assert.AreEqual("Juni", date.GetMonthTxt());

            date = new UclDate(2022, 7, 26);
            Assert.AreEqual("Juli", date.GetMonthTxt());

            date = new UclDate(2022, 8, 26);
            Assert.AreEqual("August", date.GetMonthTxt());

            date = new UclDate(2022, 9, 26);
            Assert.AreEqual("September", date.GetMonthTxt());

            date = new UclDate(2022, 10, 26);
            Assert.AreEqual("Oktober", date.GetMonthTxt());

            date.SetMonth(11);
            Assert.AreEqual("November", date.GetMonthTxt());

            date.SetMonth(12);
            Assert.AreEqual("December", date.GetMonthTxt());
        }

        [TestMethod]
        public void TestMethod_GetQuarterTxt()
        {
            UclDate date = new UclDate(2022, 1, 26);
            Assert.AreEqual("Januar kvartal", date.GetQuaterTxt());

            date.SetMonth(2);
            Assert.AreEqual("Januar kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 3, 26);
            Assert.AreEqual("Januar kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 4, 26);
            Assert.AreEqual("April kvartal", date.GetQuaterTxt());

            date.SetMonth(5);
            Assert.AreEqual("April kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 6, 26);
            Assert.AreEqual("April kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 7, 26);
            Assert.AreEqual("Juli kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 8, 26);
            Assert.AreEqual("Juli kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 9, 26);
            Assert.AreEqual("Juli kvartal", date.GetQuaterTxt());

            date = new UclDate(2022, 10, 26);
            Assert.AreEqual("Oktober kvartal", date.GetQuaterTxt());

            date.SetMonth(11);
            Assert.AreEqual("Oktober kvartal", date.GetQuaterTxt());

            date.SetMonth(12);
            Assert.AreEqual("Oktober kvartal", date.GetQuaterTxt());
        }

        [TestMethod]
        public void TestMethod_MoveToNextDate()
        {
            UclDate date = new UclDate(2022, 1, 26);
            Assert.AreEqual(26, date.GetDay());

            date.MoveToNextDate();
            Assert.AreEqual(27, date.GetDay());

            date.SetDay(1);
            date.MoveToNextDate();
            Assert.AreEqual(2, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_MoveToPrevDate()
        {
            UclDate date = new UclDate(2022, 1, 26);
            Assert.AreEqual(26, date.GetDay());

            date.MoveToPrevDate();
            Assert.AreEqual(25, date.GetDay());

            date.SetDay(1);
            date.MoveToPrevDate();
            Assert.AreNotEqual(0, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_MoveDays()
        {
            UclDate date = new UclDate(2022, 1, 26);
            Assert.AreEqual(26, date.GetDay());

            date.MoveDays(2);
            Assert.AreEqual(28, date.GetDay());

            date.SetDay(15);
            date.MoveDays(2);
            Assert.AreEqual(17, date.GetDay());

            date.MoveDays(-7);
            Assert.AreEqual(10, date.GetDay());

            date.SetDay(1);
            date.MoveDays(-1);
            Assert.AreNotEqual(0, date.GetDay());
        }

        [TestMethod]
        public void TestMethod_GetDayNumber()
        {
            UclDate date = new UclDate(2022, 1, 1);
            Assert.AreEqual(1, date.GetDayNumber());

            date.SetDay(2);
            Assert.AreEqual(2, date.GetDayNumber());

            date.SetMonth(2);
            Assert.AreEqual(33, date.GetDayNumber());
        }
    }
}
