using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ex09_Temperature;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Fahrenheit to Celsius
        [TestMethod]
        public void ConvertBoilingTemperatureFahrenheitToCelsius()
        {
            Assert.AreEqual(100, TemperatureUtil.FahrenheitToCelsius(212));
        }

        [TestMethod]
        public void ConvertBodyTemperatureFahrenheitToCelsius()
        {
            Assert.AreEqual(37, TemperatureUtil.FahrenheitToCelsius(98.6));
        }

        [TestMethod]
        public void ConvertAbitraryTemperatureFahrenheitToCelsius()
        {
            Assert.AreEqual(20, TemperatureUtil.FahrenheitToCelsius(68));
        }

        //Celsius to Fahrenheit
        [TestMethod]
        public void ConvertFreezingTemperatureCelsiusToFahrenheit()
        {
            Assert.AreEqual(32, TemperatureUtil.CelsiusToFahrenheit(0));
        }

        [TestMethod]
        public void ConvertBoilingTemperatureCelsiusToFahrenheit()
        {
            Assert.AreEqual(212, TemperatureUtil.CelsiusToFahrenheit(100));
        }

        [TestMethod]
        public void ConvertBodyTemperatureCelsiusToFahrenheit()
        {
            Assert.AreEqual(98.6, TemperatureUtil.CelsiusToFahrenheit(37));
        }

        [TestMethod]
        public void ConvertArbitraryTemperatureCelsiusToFahrenheit()
        {
            Assert.AreEqual(68, TemperatureUtil.CelsiusToFahrenheit(20));
        }


        //Properties
        [TestMethod]
        public void CanSaveDataInFahrenheitProperty()
        {
            Temperature temp = new Temperature();
            temp.Fahrenheit = 32.0;
            Assert.AreEqual(32.0, temp.Fahrenheit);
        }

        [TestMethod]
        public void CanChangeDataInFarenheitProperty()
        {
            Temperature temp = new Temperature();
            temp.Fahrenheit = 45.9;
            Assert.AreEqual(45.9, temp.Fahrenheit);
            temp.Fahrenheit = 33.3;
            Assert.AreEqual(33.3, temp.Fahrenheit);
        }

        [TestMethod]
        public void CanSaveDataInCelsiusProperty()
        {
            Temperature temp = new Temperature();
            temp.Celsius = 0.0;
            Assert.AreEqual(0.0, temp.Celsius);
        }

        [TestMethod]
        public void CanChangeDataInCelsiusProperty()
        {
            Temperature temp = new Temperature();
            temp.Celsius = 0.0;
            Assert.AreEqual(0, temp.Celsius);
            temp.Celsius = 95.7;
            Assert.AreEqual(95.7, temp.Celsius);
        }

    }
}
