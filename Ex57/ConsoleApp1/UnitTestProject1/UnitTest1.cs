using System;
using System.Collections.Generic;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestQueue()
        {
            Queue<int> stdQueue = new Queue<int>();   // standard queue implemented by .NET
            MyQueue<int> ourQueue = new MyQueue<int>();   // our manually implemented queue

            // Test generates 100 random integers and adds to both queues
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int randVal = r.Next();
                stdQueue.Enqueue(randVal);
                ourQueue.Enqueue(randVal);
            }

            // Test reading back half the added integers
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(stdQueue.Dequeue(), ourQueue.Dequeue());
                Assert.AreEqual(stdQueue.Count, ourQueue.Count());
            }

            // Test adding 50 more random integers
            for (int i = 0; i < 50; i++)
            {
                int randVal = r.Next();
                stdQueue.Enqueue(randVal);
                ourQueue.Enqueue(randVal);
            }

            // Test reading back all the remaining values
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stdQueue.Dequeue(), ourQueue.Dequeue());
                Assert.AreEqual(stdQueue.Count, ourQueue.Count());
            }

            // Test queue is empty now
            Assert.AreEqual(true, ourQueue.IsEmpty());
        }

        [TestMethod]
        public void TestStack()
        {
            Stack<int> stdStack = new Stack<int>();   // standard queue implemented by .NET
            MyStack<int> ourStack = new MyStack<int>();  // our manually implemented stack

            // Test generates 100 random integers and adds to both queues
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int randVal = r.Next();
                stdStack.Push(randVal);
                ourStack.Push(randVal);
            }

            // Test reading back half the added integers
            for (int i = 0; i < 50; i++)
            {
                Assert.AreEqual(stdStack.Pop(), ourStack.Pop());
                Assert.AreEqual(stdStack.Peek(), ourStack.Peek());
                Assert.AreEqual(stdStack.Count, ourStack.Count());
            }

            // Test adding 50 more random integers
            for (int i = 0; i < 50; i++)
            {
                int randVal = r.Next();
                stdStack.Push(randVal);
                ourStack.Push(randVal);
            }

            // Test reading back all the remaining values
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(stdStack.Peek(), ourStack.Peek());
                Assert.AreEqual(stdStack.Pop(), ourStack.Pop());
                Assert.AreEqual(stdStack.Count, ourStack.Count());
            }
        }
    }
}
