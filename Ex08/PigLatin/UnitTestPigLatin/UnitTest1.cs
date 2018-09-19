using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PigLatin;

namespace UnitTestPigLatin
{
    [TestClass]
    public class PigLatinTests
    {
        Translator translator; //to be created before each test method

        [TestInitialize] //runs before every test method - sets up a "clean" translator
        public void CreateNewTranslator()
        {
            translator = new Translator();
        }

        [TestMethod]
        public void TranslateWordBeginningWithA()
        {
            Assert.AreEqual("appleay", translator.Translate("apple"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithE()
        {
            Assert.AreEqual("enday", translator.Translate("end"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithI()
        {
            Assert.AreEqual("icecreamay", translator.Translate("icecream"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithO()
        {
            Assert.AreEqual("orangeay", translator.Translate("orange"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithAConsonant1()
        {
            Assert.AreEqual("ananabay", translator.Translate("banana"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithAConsonant2()
        {
            Assert.AreEqual("astlecay", translator.Translate("castle"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithAConsonant3()
        {
            Assert.AreEqual("othermay", translator.Translate("mother"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithTwoConsonants1()
        {
            Assert.AreEqual("errychay", translator.Translate("cherry"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithTwoConsonants2()
        {
            Assert.AreEqual("imepray", translator.Translate("prime"));
        }

        [TestMethod]
        public void TranslateTwoWords()
        {
            Assert.AreEqual("eatay iepay", translator.Translate("eat pie"));
        }

        [TestMethod]
        public void TranslateWordBeginningWithThreeConsonants()
        {
            Assert.AreEqual("eethray", translator.Translate("three"));
        }

        [TestMethod]
        public void Count_SCH_AsASinglePhoneme()
        {
            Assert.AreEqual("oolschay", translator.Translate("school"));
        }

        [TestMethod]
        public void Count_QU_AsASinglePhoneme()
        {
            Assert.AreEqual("ietquay", translator.Translate("quiet"));
        }

        [TestMethod]
        public void Count_QU_AsAConsonantEvenWhenPreceededByAConsonant()
        {
            Assert.AreEqual("aresquay", translator.Translate("square"));
        }

        [TestMethod]
        public void TranslateManyWords()
        {
            Assert.AreEqual("ethay ickquay ownbray oxfay", translator.Translate("the quick brown fox"));
        }

        [TestMethod]
        public void TranslateManyWordsWithCapital()
        {
            Assert.AreEqual("Ethay ickquay Ownbray oxfay", translator.Translate("THe quIck Brown fOx"));
        }

        [TestMethod]
        public void TranslateDanish()
        {
            Assert.AreEqual("Ødray Ødgray edmay ødeflay", translator.Translate("Rød Grød med fløde", Translator.DANISH));
        }

        [TestMethod]
        public void TranslateDanishWithWeirdStart()
        {
            Assert.AreEqual("Ogay etday arvay etay æselay omsay øday altay øethay", translator.Translate("Og det var et æsel som ød alt høet", Translator.DANISH));
        }
    }
}
