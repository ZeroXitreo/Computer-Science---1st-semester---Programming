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
        private List<int[]> AvilableGridSpot = new List<int[]>();
        private List<List<int[]>> PathsTaken = new List<List<int[]>>();
        private List<int[]> Path;
        private Random rnd = new Random();

        public Labyrinth(int size)
        {
            Grid = new bool[size, size];
            Grid[0, 0] = true;
            Grid[size - 1, 0] = true;
            Grid[0, size - 1] = true;
            Grid[size - 1, size - 1] = true;

            // Add everything to the grid checker
            for (int i = 1; i < Grid.GetLength(1)-1; i++)
            {
                for (int j = 1; j < Grid.GetLength(0)-1; j++)
                {
                    AvilableGridSpot.Add(new int[] { j, i });
                }
            }
        }

        public void Fill()
        {
            while (AvilableGridSpot.Count > 0)
            {
                GeneratePath(AvilableGridSpot[rnd.Next(0, AvilableGridSpot.Count)]);
            }
        }

        public void GeneratePath(int[] start, int[] finish = null)
        {
            Path = new List<int[]>();
            Path.Add(start);

            while (finish == null || !Path.Any(p => p.SequenceEqual(finish)))
            {
                // Check all 4 blocks around
                List<int[]> availablePath = AvailableSteps(finish);

                if (finish == null)
                {
                    bool found = false;
                    foreach (int[] coord in availablePath)
                    {
                        if (Grid[coord[0], coord[1]])
                        {
                            Path.Add(new int[] { coord[0], coord[1] });
                            found = true;
                            break;
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

            

            PathsTaken.Add(Path);



            foreach (int[] step in Path)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        int xCoords = step[0] + x;
                        int yCoords = step[1] + y;

                        if (x == 0 && y == 0) // Center
                        {
                            Grid[xCoords, yCoords] = true;
                            AvilableGridSpot.RemoveAll(p => p[0] == xCoords && p[1] == yCoords);
                        }
                        else if (Math.Abs(x) == Math.Abs(y)) // Corner
                        {
                            continue;
                        }
                        else // Side
                        {
                            try
                            {
                                Grid[xCoords, yCoords] = true;
                                AvilableGridSpot.RemoveAll(p => p[0] == xCoords && p[1] == yCoords);
                            }
                            catch (IndexOutOfRangeException)
                            {
                                // out of bounce
                            }
                        }
                    }
                }
            }
        }

        private List<int[]> AvailableSteps(int[] finish = null)
        {
            List<int[]> availablePath = new List<int[]>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    try
                    {
                        int xCoords = Path.Last()[0] + x;
                        int yCoords = Path.Last()[1] + y;
                        // Does it touch the outer wall?
                        if (xCoords <= 0 || xCoords >= Grid.GetLength(0) - 1 || yCoords <= 0 || yCoords >= Grid.GetLength(1) - 1)
                        {
                            if (finish != null && finish[0] == xCoords && finish[1] == yCoords)
                            {

                            }
                            else
                            {
                                continue;
                            }
                        }

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
                            if (xCoords >= 0 && xCoords < Grid.GetLength(0) && yCoords >= 0 && yCoords < Grid.GetLength(1))
                            {
                                availablePath.Add(new int[] { xCoords, yCoords });
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // out of bounce
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
                    //Console.BackgroundColor = ConsoleColor.Green;
                    if (Grid[j, i])
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (PathsTaken.Exists(p => p.Exists(q => q[0] == j && q[1] == i)))
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write("  ");

                    // Reset
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
    }
}
