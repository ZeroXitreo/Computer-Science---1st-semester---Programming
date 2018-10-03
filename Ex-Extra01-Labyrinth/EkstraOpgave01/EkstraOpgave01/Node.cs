using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Node
    {
        public int X;
        public int Y;
        public enum Classification
        {
            Opened,
            Closed,
            Start,
            Finish
        }
        public Classification Role = Classification.Opened;
    }
}
