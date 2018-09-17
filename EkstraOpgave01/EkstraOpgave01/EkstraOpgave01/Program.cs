using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Program
    {
        private static bool[,] Labyrinth;
        static void Main(string[] args)
        {
            int size = RequestInt("What size would you like the labyrinth to be ?");
            Labyrinth = new bool[size, size];
            PrintLabyrinth(Labyrinth);

            int[] start = RequestCoordinates(Labyrinth, "Where would you like to start?");
            PrintLabyrinth(Labyrinth, start);
            int[] finish = RequestCoordinates(Labyrinth, "Where would you like to finish?");
            PrintLabyrinth(Labyrinth, start, finish);

            GeneratePath(start, finish);

            Console.ReadKey();
        }

        private static void GeneratePath(int[] start, int[] finish)
        {
            Random rnd = new Random();
            List<int[]> pathTaken = new List<int[]>();
            pathTaken.Add(start);

            while (!pathTaken.Any(p => p.SequenceEqual(finish)))
            {
                // Check all 4 blocks around
                List<int[]> availablePath = new List<int[]>();

                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (x == 0 && y == 0) // Center
                        {
                            continue;
                        }
                        else if (Math.Abs(x) == Math.Abs(y)) // Corner
                        {
                            continue;
                        }
                        else // Side
                        {
                            try
                            {
                                int xCoords = pathTaken.Last()[0] + x;
                                int yCoords = pathTaken.Last()[1] + y;
                                //bool aa = Labyrinth[xCoords, yCoords];
                                if (xCoords >= 0 && xCoords < Labyrinth.GetLength(0) && yCoords >= 0 && yCoords < Labyrinth.GetLength(1))
                                {
                                    availablePath.Add(new int[] { xCoords, yCoords });
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                // out of bounce
                            }
                        }
                    }
                }

                // Next step
                int[] nextStep = availablePath[rnd.Next(0, availablePath.Count)];

                if(pathTaken.Any(p => p.SequenceEqual(nextStep)))
                {
                    int index = pathTaken.FindIndex(p => p[0] == nextStep[0] && p[1] == nextStep[1]);
                    pathTaken = pathTaken.GetRange(0, index + 1);
                }
                else
                {
                    pathTaken.Add(nextStep);
                }

                //PrintLabyrinth(Labyrinth, pathTaken.Last(), finish);
                //Console.WriteLine(pathTaken.Count);
                //Console.ReadKey();
            }

            Console.WriteLine("===End result===");
            foreach (int[] step in pathTaken)
            {
                Labyrinth[step[0], step[1]] = true;
            }
            PrintLabyrinth(Labyrinth, start, finish);
            Console.WriteLine("Found a path!");
        }

        private static int[] RequestCoordinates(bool[,] labyrinth, string question)
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
                else if (output[0] != 0 && output[0] != labyrinth.GetLength(0) - 1 && output[1] != 0 && output[1] != labyrinth.GetLength(1) - 1) // is not an end point of the labyrinth?
                {
                    Console.WriteLine("Doesn't hit an end of the labyrinth!");
                    completed = false;
                }
                else
                {
                    completed = true;
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

        private static void PrintLabyrinth(bool[,] labyrinth, int[] start = null, int[] finish = null)
        {
            for (int i = 0; i < labyrinth.GetLength(1); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(0); j++)
                {
                    if (start != null && j == start[0] && i == start[1])
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (finish != null && j == finish[0] && i == finish[1])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if(labyrinth[j, i])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(labyrinth[j, i] ? "X" : "O");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
