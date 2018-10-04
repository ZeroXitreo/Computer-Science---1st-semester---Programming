using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 10;
            Labyrinth lab = new Labyrinth(size);

            lab.GeneratePath(lab.Grid[0, 0], lab.Grid[size - 1, size - 1]);
            lab.Print();
            Console.ReadKey();

            lab.Fill();
            lab.Print();
            Console.ReadKey();
        }

        private static int[] RequestCoordinates(int size, string question)
        {
            int[] output = new int[2];
            string[] inputSplit = new string[0];
            bool completed = false;
            while (!completed)
            {
                Console.WriteLine(question);
                string input = Console.ReadLine();
                inputSplit = input.Split(',');
                
                if (inputSplit.Length != 2) // Are there more or less than two indexes?
                {
                    Console.WriteLine("Not two coordinates!");
                    completed = false;
                }
                else if (!int.TryParse(inputSplit[0], out output[0]) || !int.TryParse(inputSplit[1], out output[1])) // Can they not be parsed as numbers?
                {
                    Console.WriteLine("Either or both are not a number!");
                    completed = false;
                }
                else if (output[0] >= 0 && output[0] < size && output[1] >= 0 && output[1] < size) // is not an end point of the labyrinth?
                {
                    completed = true;
                }
                else
                {
                    Console.WriteLine("Doesn't hit an end of the labyrinth!");
                    completed = false;
                }
            }
            return output;
        }

        private static int RequestInt(string question)
        {
            int output;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out output));
            return output;
        }
    }
}
