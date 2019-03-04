using System;

namespace Searching
{
    public class Search
    {
        public static int FindPositionInList_Linear(int[] data, int value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindPositionInList_Binary(int[] data, int value)
        {
            throw new NotImplementedException();
        }
    }
}
