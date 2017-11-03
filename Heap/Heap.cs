using System;
using System.Text;
using static Heap.Enums;

namespace Heap
{
    public class Heap
    {
        #region Constructors

        public Heap()
        {

        }

        public Heap(Node root)
        {
            this.Root = root;
        }

        #endregion Constructors

        public void Push(int value)
        {
            Node newNode = new Node(value);

            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                Node root = this.Root;
                Upheap(ref root, newNode);
                this.Root = root;
            }
        }

        public void Pop(int value)
        {
            Downheap(value);
        }

        private void Upheap(ref Node parentNode, Node newNode)
        {
            //Min Heap
            if (parentNode.Value > newNode.Value)
            {
                //set newNode as parent
                Node temp = new Node(parentNode.Value, parentNode.LeftNode, parentNode.RightNode);
                parentNode = newNode;
                parentNode.LeftNode = temp.LeftNode;
                parentNode.RightNode = temp.RightNode;
                temp.LeftNode = null;
                temp.RightNode = null;

                //pass in parent to upheap
                Upheap(ref parentNode, temp);
            }
            else if (parentNode.LeftNode == null)
            {
                parentNode.LeftNode = newNode;
            }
            else if (parentNode.RightNode == null)
            {
                parentNode.RightNode = newNode;
            }
            else
            {
                Node leftChild = parentNode.LeftNode;
                Upheap(ref leftChild, newNode);
                parentNode.LeftNode = leftChild;
            }
        }

        private void Downheap(int value)
        {
            throw new NotImplementedException();
        }

        public Node Root
        {
            get;
            set;
        } = null;

        #region PrintTree

        public string ToString(PrintOrder orderBy)
        {
            StringBuilder tree = new StringBuilder();

            switch (orderBy)
            {
                case PrintOrder.PostOrder:
                    PostOrder(this.Root, tree);
                    break;
                case PrintOrder.InOrder:
                    InOrder(this.Root, tree);
                    break;
                case PrintOrder.PreOrder:
                case PrintOrder.None:
                default:
                    PreOrder(this.Root, tree);
                    break;
            }

            return tree.ToString();
        }

        private void InOrder(Node currentNode, StringBuilder tree)
        {
            if (currentNode != null)
            {
                if (currentNode.LeftNode != null)
                {
                    InOrder(currentNode.LeftNode, tree);
                }

                if (tree.Length > 0)
                {
                    tree.Append(" ");
                }

                tree.Append(currentNode.Value.ToString());

                if (currentNode.RightNode != null)
                {
                    InOrder(currentNode.RightNode, tree);
                }
            }
        }

        private void PostOrder(Node currentNode, StringBuilder tree)
        {
            if (currentNode != null)
            {
                if (currentNode.LeftNode != null)
                {
                    PostOrder(currentNode.LeftNode, tree);
                }

                if (currentNode.RightNode != null)
                {
                    PostOrder(currentNode.RightNode, tree);
                }
                
                if (tree.Length > 0)
                {
                    tree.Append(" ");
                }

                tree.Append(currentNode.Value.ToString());
            }
        }

        private void PreOrder(Node currentNode, StringBuilder tree)
        {
            if (currentNode != null)
            {
                if (tree.Length > 0)
                {
                    tree.Append(" ");
                }

                tree.Append(currentNode.Value.ToString());

                if (currentNode.LeftNode != null)
                {
                    PreOrder(currentNode.LeftNode, tree);
                }

                if (currentNode.RightNode != null)
                {
                    PreOrder(currentNode.RightNode, tree);
                }
            }
        }

        #endregion PrintTree
    }
}
