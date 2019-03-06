using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyStack<T>
    {
        List<T> items = new List<T>();

        public MyStack()
        {
        }

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            T item = items.Last();
            items.Remove(item);
            return item;
        }

        public T Peek()
        {
            return items.Last();
        }

        public int Count()
        {
            return items.Count;
        }

        public bool IsEmpty()
        {
            return items.Count == 0 ? true : false;
        }
    }
}
