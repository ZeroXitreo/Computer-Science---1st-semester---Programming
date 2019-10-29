using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oevelse01
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            Thread tr1 = new Thread(HelloConsoleTimesFour);
            tr1.Start();
            Thread tr2 = new Thread(() =>
            {
                HelloConsoleTimesFour();
            });
            tr2.Start();
            Thread tr3 = new Thread();
            tr3.Start();
        }

        private void HelloConsoleTimesFour()
        {
            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
