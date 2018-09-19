using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("================");
                Console.WriteLine("Which ability would you like to use? (anything else exits the program)");
                Console.WriteLine("================");
                Console.WriteLine("1 - Calculate a rectangle area");
                Console.WriteLine("2 - Check an array of numbers' sum, min and max");
                Console.WriteLine("3 - Check to see if a number exists in an array");
                Console.WriteLine("4 - Show a polyline work");

                ConsoleKeyInfo input = Console.ReadKey();
                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                        UseRectangleArea();
                        break;
                    case ConsoleKey.D2:
                        UseArrayOfInts();
                        break;
                    case ConsoleKey.D3:
                        CheckIfNumberContainsInArray();
                        break;
                    case ConsoleKey.D4:
                        UsePolyLine();
                        break;
                    default:
                        exit = true;
                        break;
                }
                Console.Clear();
            }
            Console.WriteLine("Goodbye.");
        }

        private static void UsePolyLine()
        {
            Console.WriteLine("================");
            Console.WriteLine("Insert the coordinates as follows: x,y (finish with a blank line)");
            int[][] ints = new int[0][];

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    break;
                }
                else
                {
                    string[] splittedInput = input.Split(',');
                    int[] splittedInputInt = new int[splittedInput.Length];
                    if (splittedInput.Length != 2 || !int.TryParse(splittedInput[0], out splittedInputInt[0]) || !int.TryParse(splittedInput[1], out splittedInputInt[1]))
                    {
                        Console.WriteLine("^ Not a coordinate!");
                        continue;
                    }
                    else
                    {
                        Array.Resize(ref ints, ints.Length + 1);
                        ints[ints.Length - 1] = new int[2];
                        ints[ints.Length - 1] = splittedInputInt;
                    }
                }
            }

            Console.Write("The polyline coordinates are: ");
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write("(" + ints[i][0] + "," + ints[i][1] + ")");
            }
            Console.WriteLine(".");

            int[] xCoords = new int[ints.Length];
            int[] yCoords = new int[ints.Length];
            for (int i = 0; i < ints.Length; i++)
            {
                xCoords[i] = ints[i][0];
                yCoords[i] = ints[i][1];
            }
            Console.WriteLine("The polyline has a total length of " + Numbers.PolylineLength(xCoords, yCoords) + " units");

            Console.WriteLine("================");
            Console.ReadKey();
        }

        static void UseRectangleArea()
        {
            Console.WriteLine("================");
            int v1 = 0;
            do
            {
                Console.WriteLine("Insert the rectangle height");
            }
            while (!int.TryParse(Console.ReadLine(), out v1));

            int v2 = 0;
            do
            {
                Console.WriteLine("Insert the rectangle width");
            }
            while (!int.TryParse(Console.ReadLine(), out v2));

            Console.Write("The total area of the rectangle is ");
            Console.WriteLine(Numbers.RectangleArea(v1, v2));
            Console.WriteLine("================");
            Console.ReadKey();
        }
        static void UseArrayOfInts()
        {
            Console.WriteLine("================");
            int[] ints = RequestIntArray();
            // Results
            Console.WriteLine("================");
            Console.Write("Sum of the numbers: ");
            Console.WriteLine(Numbers.Sum(ints));
            Console.Write("Lowest number: ");
            Console.WriteLine(Numbers.Min(ints));
            Console.Write("Highest number: ");
            Console.WriteLine(Numbers.Max(ints));
            Console.WriteLine("================");
            Console.ReadKey();
        }
        
        static void CheckIfNumberContainsInArray()
        {
            Console.WriteLine("================");
            int[] ints = RequestIntArray();

            //Check number
            Console.WriteLine("Which number would you like to see if it exists in the array?");
            int contains;
            while (true)
            {
                string input = Console.ReadLine();
                
                if (!int.TryParse(input, out int inputInt))
                {
                    Console.WriteLine("^ Not a number!");
                    continue;
                }
                else
                {
                    contains = inputInt;
                    break;
                }
            }
            // Results
            Console.WriteLine("================");
            Console.WriteLine(contains + " " + (Numbers.Contains(contains, ints) ? "do" : "does not") + " exist in the given array");
            Console.WriteLine("================");
            Console.ReadKey();
        }

        static int[] RequestIntArray()
        {
            Console.WriteLine("Insert the numbers you wanna use (finish with a blank line)");
            int[] ints = new int[0];

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    break;
                }
                else
                {
                    if (!int.TryParse(input, out int inputInt))
                    {
                        Console.WriteLine("^ Not a number!");
                        continue;
                    }
                    else
                    {
                        Array.Resize(ref ints, ints.Length + 1);
                        ints[ints.Length - 1] = inputInt;
                    }
                }
            }
            return ints;
        }
    }
}
