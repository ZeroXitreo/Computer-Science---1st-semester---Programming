using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Temperature
{
    public class Temperature
    {
        public double Fahrenheit;
        public double Celsius;

        public void SetCelsiusFromFahrenheit()
        {
            Celsius = TemperatureUtil.FahrenheitToCelsius(Fahrenheit);
        }

        public void SetFahrenheitFromCelsius()
        {
            Fahrenheit = TemperatureUtil.CelsiusToFahrenheit(Celsius);
        }
    }
}
