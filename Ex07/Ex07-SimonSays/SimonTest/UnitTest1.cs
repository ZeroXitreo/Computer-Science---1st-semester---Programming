using System;
using Ex07_SimonSays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimonTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldEchoHello()
        {
            Simon simon = new Simon();
            Assert.AreEqual("hello", simon.Echo("hello"));
        }

        [TestMethod]
        public void ShouldEchoBye()
        {
            Simon simon = new Simon();
            Assert.AreEqual("bye", simon.Echo("Bye"));
        }


        [TestMethod]
        public void ShoutHello()
        {
            Simon simon = new Simon();
            Assert.AreEqual("HELLO", simon.Shout("hello"));
        }

        [TestMethod]
        public void ShoutMultipleWords()
        {
            Simon simon = new Simon();
            Assert.AreEqual("HELLO WORLD", simon.Shout("hello world"));
        }


        [TestMethod]
        public void ShouldRepeat()
        {
            Simon simon = new Simon();
            Assert.AreEqual("hello hello", simon.Repeat("hello"));
        }


        [TestMethod]
        public void ShouldRepeatANumberOfTimes()
        {
            Simon simon = new Simon();
            Assert.AreEqual("hello hello hello", simon.Repeat("hello", 3));
        }


        [TestMethod]
        public void ReturnsFirstLetterOfWord()
        {
            Simon simon = new Simon();
            Assert.AreEqual("h", simon.StartOfWord("hello", 1));
        }

        [TestMethod]
        public void ReturnsFirstTwoLettersOfWord()
        {
            Simon simon = new Simon();
            Assert.AreEqual("Bo", simon.StartOfWord("Bob", 2));
        }

        [TestMethod]
        public void ReturnsFirstSeveralLettersOfWord()
        {
            Simon simon = new Simon();
            string s = "abcdefg";
            Assert.AreEqual("a", simon.StartOfWord(s, 1));
            Assert.AreEqual("ab", simon.StartOfWord(s, 2));
            Assert.AreEqual("abc", simon.StartOfWord(s, 3));
        }


        [TestMethod]
        public void ReturnsFirstWordOfHelloWorld()
        {
            Simon simon = new Simon();
            Assert.AreEqual("Hello", simon.FirstWord("Hello World"));
        }

        [TestMethod]
        public void ReturnsFirstWordOfOhDear()
        {
            Simon simon = new Simon();
            Assert.AreEqual("Oh", simon.FirstWord("Oh Dear"));
        }


        [TestMethod]
        public void CapitilizeAWord()
        {
            Simon simon = new Simon();
            Assert.AreEqual("Jaws", simon.Titleize("jaws"));
        }

        [TestMethod]
        public void CapitilizeEveryWord()
        {
            Simon simon = new Simon();
            Assert.AreEqual("David Copperfield", simon.Titleize("david copperfield"));
        }

        [TestMethod]
        public void DontCapitilizeLittleWords()
        {
            Simon simon = new Simon();
            Assert.AreEqual("War and Peace", simon.Titleize("war and peace"));
        }

        [TestMethod]
        public void CapitilizeLittleWordsInBeginningOfSentence()
        {
            Simon simon = new Simon();
            Assert.AreEqual("The Bridge over the River Kwai", simon.Titleize("the bridge over the river kwai"));
        }

    }
}
