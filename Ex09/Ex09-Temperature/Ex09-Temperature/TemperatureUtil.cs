using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Temperature
{
    public class TemperatureUtil
    {
        public static double FahrenheitToCelsius(double v)
        {
            v -= 32;
            v = v * 5 / 9;
            return v;
        }

        public static double CelsiusToFahrenheit(double v)
        {
            v = v * 9 / 5;
            v += 32;
            return v;
        }
    }
}
