using System;
using Adt;
using ex33_linkedlist;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ClubMember c1, c2, c3, c4, c5;

        [TestInitialize]
        public void Init()
        {
            c1 = new ClubMember(1, "Anders", "And", 15);
            c2 = new ClubMember(2, "Bjørn", "Borg", 30);
            c3 = new ClubMember(3, "Cristian", "Nielsen", 20);
            c4 = new ClubMember(4, "Kurt", "Nielsen", 33);
            c5 = new ClubMember(5, "Lis", "Sørnsen", 18);
        }
        [TestMethod]
        public void TestClubMember()
        {
            Assert.AreEqual("1 Anders And 15", c1.ToString());
        }
        [TestMethod]
        public void TestInsertOne()
        {
            MyLinkedList l1 = new MyLinkedList();

            Assert.AreEqual(0, l1.Count);
            l1.Insert(c1);
            Assert.AreEqual(1, l1.Count);
            Assert.AreEqual("1 Anders And 15\n", l1.ToString());
        }
        [TestMethod]
        public void TestInsertTwo()
        {
            MyLinkedList l1 = new MyLinkedList();

            l1.Insert(c1);
            l1.Insert(c2);
            Assert.AreEqual(2, l1.Count);
            Assert.AreEqual("2 Bjørn Borg 30\n1 Anders And 15\n", l1.ToString());
        }
        [TestMethod]
        public void TestDelete()
        {
            MyLinkedList l1 = new MyLinkedList();

            l1.Insert(c1);
            l1.Insert(c2);
            l1.Delete();
            Assert.AreEqual(1, l1.Count);
            Assert.AreEqual("1 Anders And 15\n", l1.ToString());
        }
        [TestMethod]
        public void TestItemAt()
        {
            MyLinkedList l1 = new MyLinkedList();

            l1.Insert(c1);
            l1.Insert(c2);
            Assert.AreEqual(c2, l1.ItemAt(0));
            Assert.AreEqual(c1, l1.ItemAt(1));
            Assert.AreEqual("2 Bjørn Borg 30\n1 Anders And 15\n", l1.ToString());
        }

        [TestMethod]
        public void TestInsertAt()
        {
            MyLinkedList l1 = new MyLinkedList();

            l1.Insert(c1);
            l1.Insert(c2);
            l1.Insert(c3, 1);
            Assert.AreEqual(3, l1.Count);
            /*l1.Insert(c4, 0);
            l1.Insert(c5, 4);
            Assert.AreEqual(5, l1.Count);
            Assert.AreEqual("4 Kurt Nielsen 33\n2 Bjørn Borg 30\n3 Cristian Nielsen 20\n1 Anders And 15\n5 Lis Sørnsen 18\n", l1.ToString());*/
        }
        [TestMethod]
        public void TestDeleteAt()
        {
            MyLinkedList l1 = new MyLinkedList();

            l1.Insert(c1);
            l1.Insert(c2);
            l1.Insert(c3, 1);
            l1.Insert(c4, 0);
            l1.Insert(c5, 4);
            l1.Delete(3);
            l1.Delete(3);
            Assert.AreEqual(3, l1.Count);
            Assert.AreEqual("4 Kurt Nielsen 33\n2 Bjørn Borg 30\n3 Cristian Nielsen 20\n", l1.ToString());
        }
    }
}
