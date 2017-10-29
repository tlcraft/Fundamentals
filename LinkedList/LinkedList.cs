using System.Text;

namespace LinkedList
{
    public class LinkedList
    {
        public LinkedList (Node root = null)
        {
            this.Root = root;
        }

        public Node Root
        {
            get;
            set;
        } = null;

        public bool Add(int data)
        {
            bool success = false;
            Node newNode = new Node(data);

            if (this.Root == null)
            {
                this.Root = newNode;
                success = true;
            }
            else
            {
                Node currentNode = this.Root;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
                success = true;
            }

            return success;
        }

        override public string ToString()
        {
            StringBuilder list = new StringBuilder();
            if (this.Root != null)
            {
                list.Append(this.Root.Data);

                Node currentNode = this.Root.Next;
                while (currentNode != null)
                {
                    list.Append(" " + currentNode.Data);
                    currentNode = currentNode.Next;
                }
            }

            return list.ToString();
        }
    }
}