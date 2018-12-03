using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Node
    {
        internal int X;
        internal int Y;
        internal List<Node> neighbours = new List<Node>();
    }
}
