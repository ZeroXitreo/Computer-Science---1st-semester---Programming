using System;
using Konsol_applikation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ConcreteSubject cs;
        ConcreteObserver co1, co2, co3;

        [TestInitialize]
        public void Initialize()
        {
            cs = new ConcreteSubject();

            co1 = new ConcreteObserver(cs);
            co2 = new ConcreteObserver(cs);
            co3 = new ConcreteObserver(cs);

            cs.Attach(co1);
            cs.Attach(co2);
            cs.Attach(co3);
        }
        [TestMethod]
        public void TestObserverPattern()
        {
            cs.State = 1;
            Assert.AreEqual(1, co1.State);
            Assert.AreEqual(1, co2.State);
            Assert.AreEqual(1, co3.State);

            cs.State = 25;
            Assert.AreEqual(25, co1.State);
            Assert.AreEqual(25, co2.State);
            Assert.AreEqual(25, co3.State);

            cs.Detach(co2);
            cs.State = 42;
            Assert.AreEqual(42, co1.State);
            Assert.AreEqual(25, co2.State);
            Assert.AreEqual(42, co3.State);
        }
    }
}
