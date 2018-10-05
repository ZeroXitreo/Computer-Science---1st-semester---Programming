using System;
using System.Collections.Generic;
using System.Text;

namespace Ex12_Timer
{
    public class Timer
    {
        public int Seconds;

        override
        public string ToString()
        {
            string seconds = Padded(Seconds % 60);
            string minutes = Padded(Seconds / 60 % 60);
            string hours = Padded(Seconds / 60 / 60 % 60);
            return hours + ":" + minutes + ":" + seconds;
        }

        public string Padded(int v)
        {
            return string.Format("{0:00}", v);
        }
    }
}