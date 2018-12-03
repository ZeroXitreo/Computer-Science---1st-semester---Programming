namespace Adt
{
    class Node
    {
        public Node Next;
        public object Data;

        public Node(object data)
        {
            Data = data;
        }
    }
}