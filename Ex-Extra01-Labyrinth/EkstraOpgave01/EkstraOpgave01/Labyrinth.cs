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
        private bool[,] Grid;
        private List<int[]> Path;

        public Labyrinth(int size)
        {
            Grid = new bool[size, size];
        }

        public void GeneratePath(int[] start, int[] finish = null)
        {
            Random rnd = new Random();
            Path = new List<int[]>();
            Path.Add(start);

            while (finish == null || !Path.Any(p => p.SequenceEqual(finish)))
            {
                // Check all 4 blocks around
                List<int[]> availablePath = AvailableSteps();

                if (finish == null)
                {
                    bool found = false;
                    foreach (int[] coord in availablePath)
                    {
                        if (Grid[coord[0], coord[1]])
                        {
                            Console.Write("Gotcha!");
                            found = true;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }

                // Next step
                int[] nextStep = availablePath[rnd.Next(0, availablePath.Count)];

                if (Path.Any(p => p.SequenceEqual(nextStep))) // is the next step a part of the current path?
                {
                    int index = Path.FindIndex(p => p[0] == nextStep[0] && p[1] == nextStep[1]);
                    Path = Path.GetRange(0, index + 1);
                }
                else
                {
                    Path.Add(nextStep);
                }

                List<int[]> pathsNextToLastStep = PathsNextToLastStep();
                if (pathsNextToLastStep.Count > 1) // is it next to more than 1?
                {
                    int[] currentPos = Path.Last();
                    int lowestIndex = Path.Count - 1;

                    foreach (int[] coord in pathsNextToLastStep)
                    {
                        int index = Path.IndexOf(coord);
                        if(index < lowestIndex)
                        {
                            lowestIndex = index;
                        }
                    }
                    
                    Path = Path.GetRange(0, lowestIndex + 1);
                    Path.Add(currentPos);
                }
            }
            Print();
            Console.ReadKey();
            foreach (int[] step in Path)
            {
                Grid[step[0], step[1]] = true;
            }
        }

        private List<int[]> AvailableSteps()
        {
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
                            int xCoords = Path.Last()[0] + x;
                            int yCoords = Path.Last()[1] + y;
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


            return availablePath;
        }
        private List<int[]> PathsNextToLastStep()
        {
            List<int[]> pathsNextToStep = new List<int[]>();

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
                            int[] last = Path.Last();
                            if (Path.Any(p => p[0] == last[0] + x && p[1] == last[1] + y))
                            {
                                pathsNextToStep.Add(Path.Find(p => p[0] == last[0] + x && p[1] == last[1] + y));
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // out of bounce
                        }
                    }
                }
            }

            return pathsNextToStep;
        }

        public void Print()
        {
            Console.Clear();
            for (int i = 0; i < Grid.GetLength(1); i++)
            {
                for (int j = 0; j < Grid.GetLength(0); j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    if (Grid[j, i])
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(Path.Exists(p => p[0] == j && p[1] == i) ? "X" : " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
    }
}
