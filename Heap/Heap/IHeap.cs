using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Heap.Enums;

namespace Heap
{
    interface IHeap
    {
        //https://www.youtube.com/watch?v=t0Cq6tVNRBA
        void Push(int value);

        void Pop(int value);

        void Pop(Node current, int value);

        void Upheap(ref Node parent, Node newNode);

        void Downheap(Node parent);

        Node Root
        {
            get;
            set;
        }

        #region Print Heap

        string ToString(PrintOrder orderBy);

        void InOrder(Node currentNode, StringBuilder tree);

        void PostOrder(Node currentNode, StringBuilder tree);

        void PreOrder(Node currentNode, StringBuilder tree);

        #endregion Print Heap
    }
}
