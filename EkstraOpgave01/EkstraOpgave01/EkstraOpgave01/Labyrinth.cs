using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkstraOpgave01
{
    class Labyrinth
    {
        private bool[,] Grid;
        private List<int[]> Path;
        internal int[] Start;
        internal int[] Finish;

        public Labyrinth(int size)
        {
            Grid = new bool[size, size];
        }

        public void GeneratePath()
        {
            Random rnd = new Random();
            List<int[]> pathTaken = new List<int[]>();
            pathTaken.Add(Start);

            while (!pathTaken.Any(p => p.SequenceEqual(Finish)))
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
                                if (xCoords >= 0 && xCoords < Grid.GetLength(0) && yCoords >= 0 && yCoords < Grid.GetLength(1))
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

                if (pathTaken.Any(p => p.SequenceEqual(nextStep))) // is the next step a part of the current path?
                {
                    int index = pathTaken.FindIndex(p => p[0] == nextStep[0] && p[1] == nextStep[1]);
                    pathTaken = pathTaken.GetRange(0, index + 1);
                }
                else if (false) // Is the next step next to two current paths? (eleminating the already created path)
                {

                }
                else
                {
                    pathTaken.Add(nextStep);
                }
            }
            
            foreach (int[] step in pathTaken)
            {
                Grid[step[0], step[1]] = true;
            }
            Path = pathTaken;
        }

        public void Print()
        {
            for (int i = 0; i < Grid.GetLength(1); i++)
            {
                for (int j = 0; j < Grid.GetLength(0); j++)
                {
                    if (Start != null && j == Start[0] && i == Start[1])
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (Finish != null && j == Finish[0] && i == Finish[1])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (Grid[j, i])
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    Console.Write(Grid[j, i] ? "X" : "O");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
