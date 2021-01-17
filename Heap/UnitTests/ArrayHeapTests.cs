using Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ArrayHeapTests
    {
        // Min Heap after adding values 0 to 9
        //         0
        //        / \
        //       1    2
        //      / \  / \
        //     3   4 5  6
        //    / \ /
        //   7  8 9
        //
        // In Order:  7 3 8 1 9 4 0 5 2 6
        // Pre Order:  0 1 3 7 8 4 9 2 5 6
        // Post Order:  7 8 3 9 4 1 5 6 2 0
        string inOrderTraversal = "7 3 8 1 9 4 0 5 2 6";
        string preOrderTraversal = "0 1 3 7 8 4 9 2 5 6";
        string postOrderTraversal = "7 8 3 9 4 1 5 6 2 0";
        Heap.ArrayHeap arrayHeap;
        const int iterations = 10;

        public void InitializeArrayHeap()
        {
            arrayHeap = new ArrayHeap();

            for (int i = 0; i < iterations; i++)
            {
                arrayHeap.Push(i);
            }
        }

        [TestMethod]
        public void ArrayHeap_SimpleCountCheck()
        {
            InitializeArrayHeap();
            int count = arrayHeap.Count();
            Assert.AreEqual(iterations, count, $"The count of the heap is wrong. Expected count of {iterations}. Actual {count}.");
        }

        [TestMethod]
        public void ArrayHeap_SimplePeek()
        {
            InitializeArrayHeap();
            int peekValue = arrayHeap.Peek();
            Assert.AreEqual(0, peekValue, $"This is not a min heap. peekValue = {peekValue}.");
        }

        [TestMethod]
        public void ArrayHeap_SimplePop()
        {
            InitializeArrayHeap();
            int popValue = arrayHeap.Pop();
            Assert.AreEqual(0, popValue, $"This is not a min heap. popValue = {popValue}.");
        }

        [TestMethod]
        public void ArrayHeap_Count()
        {
            Heap.ArrayHeap heap = new ArrayHeap(10);
            Assert.AreEqual(1, heap.Count(), $"The count is off, expected 1. {heap.Count()}");

            heap.Push(15);
            heap.Push(25);
            heap.Push(20);
            heap.Push(35);
            heap.Push(14);

            Assert.AreEqual(6, heap.Count(), $"The count is off, expected 6. {heap.Count()}");
        }
    }
}
