namespace LinkedList
{
    public class Node
    {
        public Node(int data, Node node = null)
        {
            this.Data = data;
            this.Next = node;
        }

        public int Data
        {
            get;
            set;
        } = 0;

        public Node Next
        {
            get;
            set;
        } = null;
    }
}