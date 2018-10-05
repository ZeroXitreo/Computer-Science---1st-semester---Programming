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
            int seconds = Seconds % 60;
            int minutes = Seconds / 60 % 60;
            int hours = Seconds / 60 / 60 % 60;
            return string.Format("{2:00}:{1:00}:{0:00}", seconds, minutes, hours);
        }

        public string Padded(int v)
        {
            return string.Format("{0:00}", v);
        }
    }
}
