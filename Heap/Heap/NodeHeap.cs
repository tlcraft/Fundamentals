using System;
using System.Text;
using static Heap.Enums;
using System.Collections.Generic;

namespace Heap
{
    /// <summary>
    /// This class represents a min heap object implemented with Nodes
    /// </summary>
    public class NodeHeap : IHeap
    {
        #region Constructors

        public NodeHeap()
        {

        }

        public NodeHeap(int value)
        {
            Node root = new Heap.Node(value, null);
            this.Root = root;
            ElementCount++;
        }

        #endregion Constructors

        #region Properties

        private int ElementCount
        {
            get;
            set;
        } = 0;

        private Queue<Node> Queue
        {
            get;
            set;
        } = new Queue<Node>();

        private Node Root
        {
            get;
            set;
        } = null;

        #endregion Properties

        #region Heap Interface

        public int Count()
        {
            return ElementCount;
        }

        public int Peek()
        {
            return this.Root.Value;
        }
        
        public int Pop()
        {
            ElementCount--;
            int root = this.Root.Value;

            Node newRoot = RightMostNode();

            if (newRoot != null)
            {
                this.Root.Value = newRoot.Value;
                UpdateParentChildReference(newRoot);
                newRoot = null;

                Downheap(this.Root);
            }

            return root;
        }

        public void Push(int value)
        {
            ElementCount++;

            Node newNode = new Node(value, null);

            Queue.Clear();

            Node root = this.Root;
            Push(ref root, newNode);
            Upheap(ref newNode);
            SetRoot(newNode);

            Queue.Clear();
        }

        #endregion Heap Interface

        private void Push(ref Node current, Node newNode)
        {
            if (current == null)
            {
                current = newNode;
            }
            else if (current.Left == null)
            {
                current.Left = newNode;
                newNode.Parent = current;
            }
            else if (current.Right == null)
            {
                current.Right = newNode;
                newNode.Parent = current;
            }
            else
            {
                EnqueueChildren(current);

                Node nextCheck = Queue.Dequeue();
                Push(ref nextCheck, newNode);
            }
        }

        private void SetRoot(Node node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
            }

            this.Root = node;
        }

        private Node RightMostNode()
        {
            if (this.Root == null)
            {
                return null;
            }

            Node rightMost = this.Root;

            Queue.Clear();

            EnqueueChildren(this.Root);
            RightMostNode(ref rightMost);

            Queue.Clear();

            return rightMost;
        }

        private void RightMostNode(ref Node rightMost)
        {
            Node current = null;

            current = Queue.Dequeue();
            while (current != null)
            {
                rightMost = current;
                EnqueueChildren(current);
            }
        }


        private void EnqueueChildren(Node node)
        {
            Queue.Enqueue(node.Left);
            Queue.Enqueue(node.Right);
        }

        private bool UpdateParentChildReference(Node node)
        {
            Node parent = node.Parent;
            bool isSuccessful = false;

            if (parent != null)
            {
                if (parent.Left == node)
                {
                    parent.Left = null;
                    isSuccessful = true;
                }
                else if (parent.Right == node)
                {
                    parent.Right = null;
                    isSuccessful = true;
                }
            }
            else // Root Node
            {
                isSuccessful = true;
            }

            return isSuccessful;
        }

        private bool UpdateTopParentChildReference(ref Node newChild, ref Node oldChild)
        {
            bool isSuccessful = true;

            Node topParent = newChild.Parent;
            int childValue = oldChild.Value;
            Node replacement = newChild;

            if (topParent == null)
            {
                // At root
            }
            else if (topParent.Left.Value == childValue)
            {
                topParent.Left = replacement;
            }
            else if (topParent.Right.Value == childValue)
            {
                topParent.Right = replacement;
            }
            else
            {
                isSuccessful = false;
            }

            return isSuccessful;
        }

        private void Upheap(ref Node newNode)
        {
            if (newNode != null)
            {
                Node parent = newNode.Parent;

                if (parent != null)
                {
                    //Min Heap
                    if (parent.Value > newNode.Value)
                    {
                        //set newNode as parent
                        Node temp = new Node(parent.Value, parent.Parent, parent.Left, parent.Right);
                        Node tempLeft = newNode.Left;
                        Node tempRight = newNode.Right;

                        parent = newNode;

                        if (temp.Left == newNode)
                        {
                            parent.Left = temp;
                            parent.Parent = temp.Parent;

                            UpdateTopParentChildReference(ref parent, ref temp);

                            parent.Right = temp.Right;
                            temp.Parent = parent;
                        }
                        else
                        {
                            parent.Left = temp.Left;
                            if (parent.Left != null)
                            {
                                parent.Left.Parent = parent;
                            }
                        }

                        if (temp.Right == newNode)
                        {
                            parent.Right = temp;
                            parent.Parent = temp.Parent;

                            UpdateTopParentChildReference(ref parent, ref temp);

                            parent.Left = temp.Left;
                            temp.Parent = parent;
                        }
                        else
                        {
                            parent.Right = temp.Right;
                            if (parent.Right != null)
                            {
                                parent.Right.Parent = parent;
                            }
                        }
                        
                        temp.Left = tempLeft;
                        temp.Right = tempRight;

                        if (tempLeft != null)
                        {
                            tempLeft.Parent = temp;
                        }

                        if (tempRight != null)
                        {
                            tempRight.Parent = temp;
                        }
                        
                        // Continue up the heap
                        Upheap(ref parent);
                    }
                }
            }
        }

        private void Downheap(Node parent)
        {
            if (parent != null)
            {
                int parentValue = parent.Value;
                int leftValue = parent.Left?.Value ?? 0;
                int rightValue = parent.Right?.Value ?? 0;
                Node right, left, temp;

                while (parentValue > leftValue || parentValue > rightValue)
                {
                    if (leftValue >= rightValue)
                    {
                        //replace right
                        right = parent.Right;
                        temp = new Node(right.Value, right.Parent, right.Left, right.Right);
                        right.Left = parent.Left;
                        right.Right = parent;
                        parent.Left = temp.Left;
                        parent.Right = temp.Right;
                    }
                    else
                    {
                        //replace left
                        left = parent.Left;
                        temp = new Node(left.Value, left.Parent, left.Left, left.Right);
                        left.Left = parent;
                        left.Right = parent.Right;
                        parent.Left = temp.Left;
                        parent.Right = temp.Right;
                    }

                    leftValue = parent.Left?.Value ?? 0;
                    rightValue = parent.Right?.Value ?? 0;
                }
            }
        }
        
        #region Print Heap

        public string PrintHeap(PrintOrder orderBy)
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

        #endregion Print Heap
    }
}
