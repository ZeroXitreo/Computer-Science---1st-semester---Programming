using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ex03_HelloUCL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHello()
        {
            Assert.AreEqual("Hello", Functions.Hello());
        }
        [TestMethod]
        public void TestHelloFred()
        {
            Assert.AreEqual("Hello Fred", Functions.Hello("Fred"));
        }
        [TestMethod]
        public void TestHelloBarney()
        {
            Assert.AreEqual("Hello Barney", Functions.Hello("Barney"));
        }
    }
}
