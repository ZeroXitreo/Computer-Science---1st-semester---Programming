using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Labyrinth
    {
        private Node[,] Grid;
        private readonly Random rnd = new Random();

        public Labyrinth(int size)
        {
            Grid = new Node[size, size];
        }
        public void Print()
        {
        }
    }
}
