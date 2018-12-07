namespace Adt
{
    class Node
    {
        public Node Next;
        public Node Prev;
        public object Data;

        public Node(object data)
        {
            Data = data;
        }
    }
}