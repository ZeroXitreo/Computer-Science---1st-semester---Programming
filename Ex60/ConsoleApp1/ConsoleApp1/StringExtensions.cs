using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class StringExtensions
    {
        public static string Shift(this string str, int shift)
        {
            string newString = str.Substring(str.Length - shift, shift);
            newString += str.Substring(0, str.Length - shift);
            return newString;
        }
    }
}
