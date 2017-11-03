namespace Heap
{
    public class Node
    {
        public Node(int value, Node left = null, Node right = null)
        {
            this.Value = value;
            this.LeftNode = left;
            this.RightNode = right;
        }

        public Node LeftNode
        {
            get;
            set;
        } = null;

        public Node RightNode
        {
            get;
            set;
        } = null;

        public int Value
        {
            get;
            set;
        }
    }
}
