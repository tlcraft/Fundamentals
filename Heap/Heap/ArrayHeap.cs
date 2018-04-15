using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    /// <summary>
    /// This class represents a min heap object implemented with an integer array
    /// </summary>
    public class ArrayHeap : IHeap
    {
        #region Constructors

        public ArrayHeap()
        {

        }

        public ArrayHeap(int value)
        {
            if (Heap != null)
            {
                Heap[0] = value;
                ElementCount++;
            }
        }

        #endregion Constructors

        private int?[] Heap
        {
            get;
            set;
        } = new int?[5];

        private Queue<int?> Queue
        {
            get;
            set;
        } = new Queue<int?>();

        private int ElementCount
        {
            get;
            set;
        }

        #region Heap Interface

        public int Count()
        {
            return ElementCount;
        }

        public int Peek()
        {
            return (Heap[0] != null) ? (int)Heap[0] : 0;
        }

        //TODO Complete Pop method
        public int Pop()
        {
            ElementCount--;
            throw new NotImplementedException();
        }

        public void Push(int value)
        {
            ElementCount++;

            Queue.Clear();

            Push(0, value);

            Queue.Clear();
        }

        private void Push(int index, int value)
        {
            if (index >= Heap.Length)
            {
                GrowHeap();
            }

            if (Heap[index] == null)
            {
                Heap[index] = value;
            }
            else
            {
                int left = (2 * index) + 1;
                int right = left + 1;

                if (left >= Heap.Length || right >= Heap.Length)
                {
                    GrowHeap();
                }

                if (Heap[left] == null)
                {
                    Heap[left] = value;
                }
                else if (Heap[right] == null)
                {
                    Heap[right] = value;
                }
                else
                {
                    Queue.Enqueue(left);
                    Queue.Enqueue(right);

                    int? nextCheck = Queue.Dequeue();
                    if (nextCheck != null && nextCheck >= 0)
                    {
                        Push((int)nextCheck, value);
                    }
                }
            }
        }

        #endregion Heap Interface

        private void GrowHeap()
        {
            int currentSize = Heap.Length;

            int?[] newHeap = new int?[currentSize * 2];

            for(int i = 0; i < currentSize; i++)
            {
                newHeap[i] = Heap[i];
            }

            Heap = newHeap;
        }

        #region Print Heap

        //TODO Implement array traversals
        public string PrintHeap(Enums.PrintOrder orderBy)
        {
            throw new NotImplementedException();
        }

        private void InOrder()
        {
            throw new NotImplementedException();
        }

        private void PostOrder()
        {
            throw new NotImplementedException();
        }

        private void PreOrder()
        {
            throw new NotImplementedException();
        }

        #endregion Print Heap
    }
}
