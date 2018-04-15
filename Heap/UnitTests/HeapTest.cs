using Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HeapTest
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
        Heap.NodeHeap nodeHeap;
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

        public void InitializeNodeHeap()
        {
            nodeHeap = new Heap.NodeHeap();

            for (int i = 0; i < iterations; i++)
            {
                nodeHeap.Push(i);
            }
        }

        public void InitializeHeaps()
        {
            InitializeArrayHeap();
            InitializeNodeHeap();
        }

        [TestMethod]
        public void NodeHeap_SimpleCountCheck()
        {
            InitializeNodeHeap();
            int count = nodeHeap.Count();
            Assert.AreEqual(iterations, count, $"The count of the heap is wrong. Expected count of {iterations}. Actual {count}.");
        }

        [TestMethod]
        public void ArrayHeap_SimpleCountCheck()
        {
            InitializeArrayHeap();
            int count = arrayHeap.Count();
            Assert.AreEqual(iterations, count, $"The count of the heap is wrong. Expected count of {iterations}. Actual {count}.");
        }

        [TestMethod]
        public void NodeHeap_SimplePeek()
        {
            InitializeNodeHeap();
            int peekValue = nodeHeap.Peek();
            Assert.AreEqual(0, peekValue, $"This is not a min heap. Expected value of 0. Actual {peekValue}.");
        }

        [TestMethod]
        public void NodeHeap_SimplePop()
        {
            InitializeNodeHeap();
            int rootValue = nodeHeap.Pop();
            Assert.AreEqual(0, rootValue, $"This is not a min heap. Expected value of 0. Actual {rootValue}.");
        }

        [TestMethod]
        public void NodeHeap_PopInOrderTraversal()
        {
            InitializeNodeHeap();
            int rootValue = nodeHeap.Pop();
            Assert.AreEqual(0, rootValue, $"This is not a min heap. Excepted value of 0. Actual {rootValue}.");

            string inOrder = nodeHeap.PrintHeap(Enums.PrintOrder.InOrder);

            // New Min Heap
            //         1
            //        / \
            //       3    2
            //      / \  / \
            //     7   4 5  6
            //    / \ 
            //   9  8 
            //
            // In Order:  9 7 8 3 4 1 5 2 6
            inOrderTraversal = "9 7 8 3 4 1 5 2 6";
            Assert.AreEqual(inOrderTraversal, inOrder, $"The in order traversal was wrong: {inOrderTraversal} != {inOrder}.");
        }

        [TestMethod]
        public void NodeHeap_MinHeap()
        {
            Heap.NodeHeap heap = new NodeHeap(10);
            heap.Push(20);
            heap.Push(16);
            heap.Push(14);
            heap.Push(33);
            heap.Push(77);
            heap.Push(2);
            heap.Push(7);
            int peekValue = heap.Peek();
            Assert.AreEqual(2, peekValue, $"This is not a min heap. peekValue = {peekValue}.");
        }

        [TestMethod]
        public void ArrayHeap_SimplePeek()
        {
            InitializeArrayHeap();
            int peekValue = arrayHeap.Peek();
            Assert.AreEqual(0, peekValue, $"This is not a min heap. peekValue = {peekValue}.");
        }

        [TestMethod]
        public void NodeHeap_InOrder()
        {
            InitializeNodeHeap();
            string inOrder = nodeHeap.PrintHeap(Enums.PrintOrder.InOrder);
            Assert.AreEqual(inOrderTraversal, inOrder, $"The in order traversal was wrong: {inOrderTraversal} != {inOrder}.");
        }

        [TestMethod]
        public void NodeHeap_PreOrder()
        {
            InitializeNodeHeap();
            string preOrder = nodeHeap.PrintHeap(Enums.PrintOrder.PreOrder);
            Assert.AreEqual(preOrderTraversal, preOrder, $"The pre order traversal was wrong: {preOrderTraversal} != {preOrder}.");
        }

        [TestMethod]
        public void NodeHeap_PostOrder()
        {
            InitializeNodeHeap();
            string postOrder = nodeHeap.PrintHeap(Enums.PrintOrder.PostOrder);
            Assert.AreEqual(postOrderTraversal, postOrder, $"The post order traversal was wrong: {postOrderTraversal} != {postOrder}.");
        }

        [TestMethod]
        public void NodeHeap_PushPop_Count()
        {
            Heap.NodeHeap heap = new NodeHeap(10);
            Assert.AreEqual(1, heap.Count(), $"The count is wrong. Expected 1 and got {heap.Count()}");
            heap.Push(15);
            Assert.AreEqual(2, heap.Count(), $"The count is wrong. Expected 2 and got {heap.Count()}");
            heap.Push(1);
            heap.Push(22);
            Assert.AreEqual(4, heap.Count(), $"The count is wrong. Expected 4 and got {heap.Count()}");
            heap.Pop();
            Assert.AreEqual(3, heap.Count(), $"The count is wrong. Expected 3 and got {heap.Count()}");
        }

        [TestMethod]
        public void NodeHeap_RootRotation()
        {
            Heap.NodeHeap heap = new NodeHeap(10);

            heap.Push(15);
            heap.Push(1);

            // Min Heap
            //         1
            //        / \
            //      15    10

            preOrderTraversal = "1 15 10";

            string preOrder = heap.PrintHeap(Enums.PrintOrder.PreOrder);
            Assert.AreEqual(preOrderTraversal, preOrder, $"The post order traversal was wrong: {preOrderTraversal} != {preOrder}.");
        }

        [TestMethod]
        public void NodeHeap_PreOrderMixedNodes()
        {
            Heap.NodeHeap heap = new NodeHeap(10);

            heap.Push(15);
            heap.Push(25);
            heap.Push(20);
            heap.Push(35);
            heap.Push(14);
            heap.Push(1);

            // Min Heap
            //         1
            //        / \
            //      15    10
            //      / \   / \
            //    20  35 25  14
            preOrderTraversal = "1 15 20 35 10 25 14";

            string preOrder = heap.PrintHeap(Enums.PrintOrder.PreOrder);
            Assert.AreEqual(preOrderTraversal, preOrder, $"The post order traversal was wrong: {preOrderTraversal} != {preOrder}.");           
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
