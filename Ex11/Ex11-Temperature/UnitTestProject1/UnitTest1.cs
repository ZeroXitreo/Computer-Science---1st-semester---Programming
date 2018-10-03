using System;
using Ex11_Temperature;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        const double delta = 0.00001;

        [TestMethod]
        public void TwoPropertiesUsesOneVariable01()
        {
            Temperature temperature = new Temperature();
            temperature.Celsius = 50.0;

            Assert.AreEqual(50, temperature.Celsius, delta);
            Assert.AreEqual(122.0, temperature.Fahrenheit, delta);
        }

        [TestMethod]
        public void TwoPropertiesUsesOneVariable02()
        {
            Temperature temperature = new Temperature();
            temperature.Fahrenheit = 55.5;

            Assert.AreEqual(55.5, temperature.Fahrenheit, delta);
            Assert.AreEqual(13.05555, temperature.Celsius, delta);
        }

        [TestMethod]
        public void TwoPropertiesUsesOneVariable03()
        {
            Temperature temperature = new Temperature();

            Assert.AreEqual(0.0, temperature.Celsius, delta);
            Assert.AreEqual(32.0, temperature.Fahrenheit, delta);
        }

        [TestMethod]
        public void SettingTemperatureUsingEnumValueCelsius()
        {
            Temperature temperature = new Temperature();
            temperature.SetTemperature(114.7, Temperature.TemperatureScale.Celsius);

            Assert.AreEqual(114.7, temperature.Celsius, delta);
            Assert.AreEqual(238.46, temperature.Fahrenheit, delta);
        }

        [TestMethod]
        public void SettingTemperatureUsingEnumValueFahrenheit()
        {
            Temperature temperature = new Temperature();
            temperature.SetTemperature(103.6, Temperature.TemperatureScale.Fahrenheit);

            Assert.AreEqual(39.77777, temperature.Celsius, delta);
            Assert.AreEqual(103.6, temperature.Fahrenheit, delta);
        }

    }
}
