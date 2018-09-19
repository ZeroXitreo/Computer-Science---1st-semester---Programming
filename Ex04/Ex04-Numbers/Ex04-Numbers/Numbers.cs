using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04_Numbers
{
    public class Numbers
    {
        public static int RectangleArea(int v1, int v2)
        {
            return v1 * v2;
        }

        public static int Sum(int[] ints)
        {
            //return ints.Sum();
            int sum = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                sum += ints[i];
            }
            return sum;
        }

        public static int Min(int[] ints)
        {
            //return ints.Min();
            int min = ints.Length != 0 ? ints[0] : 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (min > ints[i])
                {
                    min = ints[i];
                }
            }
            return min;
        }

        public static int Max(int[] ints)
        {
            //return ints.Max();
            int max = ints.Length != 0 ? ints[0] : 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (max < ints[i])
                {
                    max = ints[i];
                }
            }
            return max;
        }

        public static bool Contains(int v, int[] ints)
        {
            //return ints.Contains(v);
            for (int i = 0; i < ints.Length; i++)
            {
                if (v == ints[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static double Average(int[] ints)
        {
            //return ints.Average();
            double total = Sum(ints);
            return total / ints.Length;
        }

        public static double LineLength(int xa, int ya, int xb, int yb)
        {
            return Math.Sqrt(Math.Pow(xa - xb, 2) + Math.Pow(ya - yb, 2));
        }

        public static double PolylineLength(int[] xCoords, int[] yCoords)
        {
            double totalLength = 0;
            for (int i = 0; i < xCoords.Length - 1; i++)
            {
                totalLength += LineLength(xCoords[i], yCoords[i], xCoords[i + 1], yCoords[i + 1]);
            }
            return totalLength;
        }
    }
}
