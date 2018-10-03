using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex11_Temperature
{
    public class Temperature
    {
        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                celsius = value;
            }
        }
        public double Fahrenheit
        {
            get
            {
                return celsius * 9 / 5 + 32;
            }
            set
            {
                celsius = (value - 32) * 5 / 9;
            }
        }
        private double celsius;
        public enum TemperatureScale
        {
            Celsius,
            Fahrenheit
        }

        public void SetTemperature(double v, TemperatureScale scale)
        {
            switch (scale)
            {
                case TemperatureScale.Fahrenheit:
                    Fahrenheit = v;
                    break;
                default:
                    Celsius = v;
                    break;
            }
        }
    }
}
