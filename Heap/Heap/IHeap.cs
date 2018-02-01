using System.Text;
using static Heap.Enums;

namespace Heap
{
    interface IHeap
    {
        // Resources
        //
        // What is a Heap: http://www.cprogramming.com/tutorial/computersciencetheory/heap.html
        // Data Structures: Heaps: https://www.youtube.com/watch?v=t0Cq6tVNRBA
        // Intro to a Heap: https://www.youtube.com/watch?v=c1TpLRyQJ4w&list=PLTxllHdfUq4fMXqS6gCDWuWhiaRDVGsgu
        // Basic operations: https://en.wikipedia.org/wiki/Heap_(data_structure)

        /// <summary>
        /// Returns the number of elements within the heap structure.
        /// </summary>
        /// <returns>Returns the number of elements within the heap.</returns>
        int Count();

        /// <summary>
        /// Returns the root value without removing it from the heap.
        /// </summary>
        /// <returns>Returns the root int value.</returns>
        int Peek();

        /// <summary>
        /// Returns the root value and removes it from the heap.
        /// </summary>
        /// <returns>Returns the root int value.</returns>
        int Pop();

        /// <summary>
        /// Inserts a new int value into the heap structure.
        /// </summary>
        /// <param name="value">int value to add to the heap.</param>
        void Push(int value);
    }
}
