using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatoConsoleSimpleAfprovning
{
    class Program
    {
        static void Main(string[] args)
        {
            DateClassLibrary.UclDate dato1 = new DateClassLibrary.UclDate(2007, 3, 7);
            Console.WriteLine("år: " + dato1.GetYear());
            Console.WriteLine("måned: " + dato1.GetMonth());
            Console.WriteLine("dag: " + dato1.GetDay());


            Console.ReadLine();  // Vent på return
        }
    }
}
