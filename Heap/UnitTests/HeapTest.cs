using Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class HeapTest
    {
        // Min Heap
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
        Heap.NodeHeap heap;

        [TestInitialize]
        public void Initialize()
        {
            heap = new Heap.NodeHeap();
            for (int i = 0; i < 10; i++)
            {
                heap.Push(i);
            }
        }

        [TestMethod]
        public void PushTest()
        {
            Assert.IsTrue(heap.Root.Value == 0, "This is not a min heap");
        }

        [TestMethod]
        public void InOrderTest()
        {
            string inOrder = heap.ToString(Enums.PrintOrder.InOrder);
            Assert.IsTrue(inOrderTraversal == inOrder, "The in order traversal was wrong: " + inOrderTraversal + " != " + inOrder);
        }

        [TestMethod]
        public void PreOrderTest()
        {
            string preOrder = heap.ToString(Enums.PrintOrder.PreOrder);
            Assert.IsTrue(preOrderTraversal == preOrder, "The pre order traversal was wrong: " + preOrderTraversal + " != " + preOrder);
        }

        [TestMethod]
        public void PostOrderTest()
        {
            string postOrder = heap.ToString(Enums.PrintOrder.PostOrder);
            Assert.IsTrue(postOrderTraversal == postOrder, "The post order traversal was wrong: " + postOrderTraversal + " != " + postOrder);
        }
    }
}
