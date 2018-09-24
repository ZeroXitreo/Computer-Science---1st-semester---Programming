using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09_Temperature
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(@"..\..\InputFil.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] splitLine = line.Split(' ');
                        Console.WriteLine("Celsius");
                        foreach (string celcius in splitLine)
                        {
                            Temperature temp = new Temperature();
                            temp.Celsius = double.Parse(celcius);
                            Console.WriteLine(temp.Celsius);
                        }
                        line = sr.ReadLine();
                        splitLine = line.Split(' ');
                        Console.WriteLine("Fahrenheit");
                        foreach (string fahrenheit in splitLine)
                        {
                            Temperature temp = new Temperature();
                            temp.Fahrenheit = double.Parse(fahrenheit);
                            Console.WriteLine(temp.Fahrenheit);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
