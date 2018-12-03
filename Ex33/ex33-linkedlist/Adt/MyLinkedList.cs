using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adt
{
    public class MyLinkedList
    {
        private Node Head;

        public int Count
        {
            get
            {
                int count = 0;
                Node node = Head;
                while (node != null)
                {
                    node = node.Next;
                    count++;
                }
                return count;
            }
        }

        public void Insert(object obj, int index = 0)
        {
            if (index <= 0)
            {
                Node oldHead = Head;
                Head = new Node(obj);
                Head.Next = oldHead;
            }
            else
            {
                Node node = Head;
                for (int i = 1; i < index; i++)
                {
                    node = node.Next;
                }
                Node oldNext = node.Next;
                node.Next = new Node(obj);
                node.Next.Next = oldNext;
            }
        }

        public void Delete(int index = 0)
        {
            if (index <= 0)
            {
                Head = Head.Next;
            }
            else
            {
                Node node = Head;
                for (int i = 1; i < index; i++)
                {
                    node = node.Next;
                }
                node.Next = node.Next.Next;
            }
        }

        public object ItemAt(int index)
        {
            Node node = Head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node.Data;
        }

        public override string ToString()
        {
            Node node = Head;
            string str = string.Empty;
            while (node != null)
            {
                str += node.Data + "\n";
                node = node.Next;
            }
            return str;
        }
    }
}
