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
        internal int[] Start;
        internal int[] Finish;

        public Labyrinth(int size)
        {
            Grid = new bool[size, size];
        }

        public void GeneratePath()
        {
            Random rnd = new Random();
            Path = new List<int[]>();
            Path.Add(Start);

            while (!Path.Any(p => p.SequenceEqual(Finish)))
            {
                // Check all 4 blocks around
                List<int[]> availablePath = AvailableSteps();

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
                Grid = new bool[Grid.GetLength(0), Grid.GetLength(1)];
                foreach (int[] step in Path)
                {
                    Grid[step[0], step[1]] = true;
                }
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
