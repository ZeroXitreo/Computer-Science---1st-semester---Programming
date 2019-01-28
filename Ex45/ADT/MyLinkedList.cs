using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public class MyLinkedList
    {
        private class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }

            public Node(object data)
            {
                Data = data;
            }
        }

        private Node head;

        public int Count { get; private set; }
        public object First
        {
            get { return ItemAt(0); }
        }
        public object Last
        {
            get { return ItemAt(Count - 1); }
        }

        /// <summary>
        /// The Insert(Object data, int index = 0) method inserts data as a node in the list
        /// at the position indicated by index. 
        /// The list is 0-indexed. 
        /// Default value of index is 0.
        /// If index is 0 or less, the data is inserted at the start of the list.
        /// If index is equal to Count or higher, the data is inserted at the end of the list.
        /// </summary>
        public void Insert(object data, int index = 0)
        {
            Node n = new Node(data);

            // Adjust index, if necessary
            if (index > Count)
                index = Count;

            if (Count == 0 || index < 1)
            {
                n.Next = head;
                head = n;
            }
            else
            {
                Node position = head;
                for (int i = 0; i < index - 1; i++)
                {
                    position = position.Next;
                }
                n.Next = position.Next;
                position.Next = n;
            }

            Count++;
        }

        /// <summary>
        /// The Append(Object data) method appends data at the end of the list.
        /// </summary>
        public void Append(object data)
        {
            Insert(data, Count);
        }

        /// <summary>
        /// The Delete(int index = 0) method deletes the node in the list at the position indicated by index. 
        /// The list is 0-indexed. 
        /// Default value of index is 0.
        /// </summary>
        public void Delete(int index = 0)
        {
            if (Count > 0)
            {
                // Adjust index, if necessary
                if (index > Count)
                    index = Count;

                if (index < 1)
                    head = head.Next;
                else
                {
                    Node position = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        position = position.Next;
                    }
                    position.Next = position.Next.Next;
                }

                Count--;
            }
        }

        /// <summary>
        /// The ItemAt(int index) method returns the data from the list at the position indicated by index. 
        /// The list is 0-indexed. 
        /// </summary>
        public object ItemAt(int index)
        {
            object result = null;
            if (index < Count && index >= 0)
            {
                Node position = head;
                for (int i = 0; i < index; i++)
                {
                    position = position.Next;
                }
                result = position.Data;
            }
            return result;
        }

        /// <summary>
        /// The ToString() method returns a string representation of the whole list by concatenating 
        /// all the ToString()-values of each data object in the list.
        /// </summary>
        public override string ToString()
        {
            string result = "";
            Node pointernode = head;
            while (pointernode != null)
            {
                result = result + pointernode.Data.ToString() + "\n";

                pointernode = pointernode.Next;
            }
            return result;
        }

    }
}
