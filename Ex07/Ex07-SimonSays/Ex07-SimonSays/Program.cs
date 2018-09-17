using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07_SimonSays
{
    class Program
    {
        static void Main(string[] args)
        {
            Simon simon = new Simon();
            Console.WriteLine(simon.Echo("Yo, wazzup ?"));
            Console.WriteLine(simon.Shout("Yo, wazzup ?"));
        }
    }
}
