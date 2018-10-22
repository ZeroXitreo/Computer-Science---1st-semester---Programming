using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex15OrangeTree
{
    public class OrangeTree
    {
        public int Age { get; private set; }
        public int Height { get; private set; }
        public bool TreeAlive { get; private set; }
        public int NumOranges { get; private set; }
        public int OrangesEaten { get; private set; }

        public OrangeTree(int age, int height)
        {
            Age = age;
            Height = height;
            TreeAlive = true;
        }

        public void OneYearPasses()
        {
            Age++;
            OrangesEaten = 0;
            if (Age < 80)
            {
                Height += 2;
                if (Age >= 2)
                {
                    NumOranges += 5;
                }
            }
            else
            {
                TreeAlive = false;
                NumOranges = 0;
            }
        }

        public void EatOrange(int v)
        {
            if (OrangesEaten + v > NumOranges)
            {
                throw new IndexOutOfRangeException("You can't eat an orange that isn't there!  There are 0 oranges available to eat");
            }
            OrangesEaten += v;
        }
    }
}
