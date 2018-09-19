using System;

namespace Ex03_HelloUCL
{
    internal class Functions
    {
        internal static string Hello(string v = null)
        {
            return "Hello" + (v != null ? " " + v : "");
        }
    }
}