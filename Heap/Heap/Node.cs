namespace Heap
{
    public class Node
    {
        public Node(int value, Node parent, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
            this.Parent = parent;
        }

        public Node Left
        {
            get;
            set;
        } = null;

        public Node Right
        {
            get;
            set;
        } = null;

        public Node Parent
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
