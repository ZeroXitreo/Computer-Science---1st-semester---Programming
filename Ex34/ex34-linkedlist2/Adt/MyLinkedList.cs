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

        private Node Tail
        {
            get
            {
                Node node = Head;
                while (node != null && node.Next != null)
                {
                    node = node.Next;
                }
                return node;
            }
        }

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

        public void Insert(object obj)
        {
            if (Tail == null)
            {
                Head = new Node(obj);
            }
            else
            {
                Node tail = Tail;
                tail.Next = new Node(obj);
                tail.Next.Prev = tail;
            }
        }

        public void Insert(object obj, int index)
        {
            if (index <= 0)
            {
                Node node = Head;
                Head = new Node(obj);
                Head.Next = node;

                if (Head.Next != null)
                {
                    Head.Next.Prev = Head;
                }
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

                node.Next.Prev = node;
                if (node.Next.Next != null)
                {
                    node.Next.Next.Prev = node.Next;
                }
            }
        }

        public void Delete()
        {
            Head = Head.Next;
            Head.Prev = null;
        }

        public void Delete(int index)
        {
            if (index <= 0)
            {
                Delete();
            }
            else
            {
                Node node = Head;
                for (int i = 1; i < index; i++)
                {
                    node = node.Next;
                }
                node.Next = node.Next.Next;

                if (node.Next != null)
                {
                    node.Next.Prev = node;
                }
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

        public void Rervers()
        {
            MyLinkedList linkedList = new MyLinkedList();

            Node node = Tail;
            while (node != null)
            {
                linkedList.Insert(node.Data);
                node = node.Prev;
            }

            Head = linkedList.Head;
        }

        public void Swap(int v)
        {

            // Get node to swap
            Node pickedNode = Head;
            for (int i = 0; i < v; i++)
            {
                pickedNode = pickedNode.Next;
            }

            Delete(v);
            Insert(pickedNode.Data, v + 1);

            /*// Add the links outside the pickedNode
            pickedNode.Prev.Next = pickedNode.Next;
            pickedNode.Next.Prev = pickedNode.Prev;

            // Add the links on the pickedNode
            pickedNode.Prev = pickedNode.Next;
            pickedNode.Next = pickedNode.Prev.Next;

            // Insert into linking
            if (pickedNode.Next != null)
            {
                pickedNode.Next.Prev = pickedNode;
            }
            pickedNode.Prev.Next = pickedNode;*/
        }

        public string FremTilbage()
        {
            string str = string.Empty;
            Node node = Head;
            while (node != null)
            {
                str += node.Data + "\n";
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
            }
            node = node.Prev;
            while (node != null)
            {
                str += node.Data + "\n";
                node = node.Prev;
            }
            return str;
        }
    }
}
