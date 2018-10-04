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
        public Node[,] Grid;
        public List<Node> AvailableNodes = new List<Node>();
        public List<List<Node>> PathsTaken = new List<List<Node>>();
        private readonly Random rnd = new Random();

        public Labyrinth(int size)
        {
            Grid = new Node[size, size];

            // Set their positions
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                for (int x = 0; x < Grid.GetLength(0); x++)
                {
                    Node node = new Node();
                    AvailableNodes.Add(node);
                    Grid[x, y] = node;
                    node.X = x;
                    node.Y = y;
                }
            }
        }
        public void Fill()
        {
            if (PathsTaken.Count > 0)
            {
                while (AvailableNodes.Count > 0)
                {
                    GeneratePath(AvailableNodes[rnd.Next(0, AvailableNodes.Count)]);
                }
            }
        }

        public void GeneratePath(Node start, Node finish = null)
        {
            List<Node> path = new List<Node>();
            path.Add(start);

            while (path.Last() != finish)
            {
                List<Node> neighbours = GetNeighbours(path.Last());

                Node nextNode = neighbours[rnd.Next(0, neighbours.Count)];

                if (path.Any(p => p == nextNode)) // is the next step a part of the current path?
                {
                    int index = path.FindIndex(p => p == nextNode);
                    path = path.GetRange(0, index + 1);
                }
                else
                {
                    path.Add(nextNode);
                }

                if (finish == null && PathsTaken.Exists(p => p.Exists(q => q == path.Last())))
                {
                    break;
                }
            }

            foreach (Node node in path)
            {
                AvailableNodes.Remove(node);
            }

            PathsTaken.Add(path);
        }

        public List<Node> GetNeighbours(Node spot)
        {
            List<Node> neighbours = new List<Node>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    try
                    {
                        int xCoords = spot.X + x;
                        int yCoords = spot.Y + y;

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
                            neighbours.Add(Grid[xCoords, yCoords]);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // out of bounce
                    }
                }
            }

            return neighbours;
        }
        public List<Node> GetEdge(Node spot)
        {
            List<Node> edge = new List<Node>();

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    int xCoords = spot.X + x;
                    int yCoords = spot.Y + y;
                    try
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
                            Node v = Grid[xCoords, yCoords];
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // out of bounce
                        Node node = new Node();
                        node.X = xCoords;
                        node.Y = yCoords;
                        edge.Add(node);
                    }
                }
            }

            return edge;
        }

        public void Print()
        {
            Console.Clear();

            bool[,] walls = new bool[Grid.GetLength(0) * 2 + 1, Grid.GetLength(1) * 2 + 1];

            foreach (List<Node> path in PathsTaken)
            {
                for (int i = 0; i < path.Count; i++)
                {
                    Node node = path[i];

                    walls[node.X * 2 + 1, node.Y * 2 + 1] = true;

                    if (node == path.Last())
                    {
                        continue;
                    }

                    // Path
                    Node nextNode = path[i + 1];
                    walls[node.X + nextNode.X + 1, node.Y + nextNode.Y + 1] = true;

                }
            }

            if (PathsTaken.Count > 0)
            {
                Node start = PathsTaken[0][0];
                List<Node> startEdge = GetEdge(start);
                Node preStart = startEdge[rnd.Next(0, startEdge.Count)];
                walls[start.X + preStart.X + 1, start.Y + preStart.Y + 1] = true;

                Node finish = PathsTaken[0].Last();
                List<Node> finishEdge = GetEdge(finish);
                Node preFinish = finishEdge[rnd.Next(0, finishEdge.Count)];
                walls[finish.X + preFinish.X + 1, finish.Y + preFinish.Y + 1] = true;
            }
            
            for (int y = 0; y < walls.GetLength(1); y++)
            {
                for (int x = 0; x < walls.GetLength(0); x++)
                {
                    //if (PathsTaken.Exists(p => p.Exists(q => q.X == x && q.Y == y)))
                    if (walls[x, y])
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
