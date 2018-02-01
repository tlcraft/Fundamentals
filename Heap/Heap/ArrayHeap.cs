using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class ArrayHeap : IHeap
    {
        private int?[] Heap
        {
            get;
            set;
        } = new int?[10];

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
            // TODO: Grab index and compare to size of array, increase if necessary
            // GrowHeap()

            if (Heap[index] == null)
            {
                Heap[index] = value;
            }
            else
            {
                int left = (2 * index) + 1;
                int right = left + 1;
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
