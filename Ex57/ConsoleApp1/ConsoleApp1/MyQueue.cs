using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyQueue<T>
    {
        private List<T> items = new List<T>();

        public MyQueue()
        {
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            T item = items.First();
            items.Remove(item);
            return item;
        }

        public int Count()
        {
            return items.Count;
        }

        public Boolean IsEmpty()
        {
            return items.Count == 0 ? true : false;
        }
    }
}
