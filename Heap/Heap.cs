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
            if (this.Root.Value == value)
            {
                //remove root
                //grab rightmost node on lowest level
                //replace this node as parent
                //downheap(root)
            }
            else if (this.Root.Left.Value >= value)
            {
                //pop(left, value)
            }
            else
            {
                //pop(right, value);
            }
        }

        private void Upheap(ref Node parent, Node newNode)
        {
            //Min Heap
            if (parent.Value > newNode.Value)
            {
                //set newNode as parent
                Node temp = new Node(parent.Value, parent.Left, parent.Right);
                parent = newNode;
                parent.Left = temp.Left;
                parent.Right = temp.Right;
                temp.Left = null;
                temp.Right = null;

                //pass in parent to upheap
                Upheap(ref parent, temp);
            }
            else if (parent.Left == null)
            {
                parent.Left = newNode;
            }
            else if (parent.Right == null)
            {
                parent.Right = newNode;
            }
            else
            {
                Node left = parent.Left;
                Upheap(ref left, newNode);
                parent.Left = left;
            }
        }

        private void Downheap(Node parent)
        {
            if (parent != null)
            {
                int parentValue = parent.Value;
                int leftValue = parent.Left?.Value ?? 0;
                int rightValue = parent.Right?.Value ?? 0;

                if (parentValue > leftValue || parentValue > rightValue)
                {
                    if (leftValue >= rightValue)
                    {
                        //replace right
                        Node right = parent.Right;
                        Node temp = new Node(right.Value, right.Left, right.Right);
                        right.Left = parent.Left;
                        right.Right = parent;
                        parent.Left = temp.Left;
                        parent.Right = temp.Right;
                    }
                    else
                    {
                        //replace left
                        Node left = parent.Left;
                        Node temp = new Node(left.Value, left.Left, left.Right);
                        left.Left = parent;
                        left.Right = parent.Right;
                        parent.Left = temp.Left;
                        parent.Right = temp.Right;
                    }

                    Downheap(parent);
                }
            }
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
                if (currentNode.Left != null)
                {
                    InOrder(currentNode.Left, tree);
                }

                if (tree.Length > 0)
                {
                    tree.Append(" ");
                }

                tree.Append(currentNode.Value.ToString());

                if (currentNode.Right != null)
                {
                    InOrder(currentNode.Right, tree);
                }
            }
        }

        private void PostOrder(Node currentNode, StringBuilder tree)
        {
            if (currentNode != null)
            {
                if (currentNode.Left != null)
                {
                    PostOrder(currentNode.Left, tree);
                }

                if (currentNode.Right != null)
                {
                    PostOrder(currentNode.Right, tree);
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

                if (currentNode.Left != null)
                {
                    PreOrder(currentNode.Left, tree);
                }

                if (currentNode.Right != null)
                {
                    PreOrder(currentNode.Right, tree);
                }
            }
        }

        #endregion PrintTree
    }
}
