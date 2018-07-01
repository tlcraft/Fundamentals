using System;
using static Heap.Enums;

namespace Heap
{
    class Driver
    {
        public static void Main(string[] args)
        {
            // Node Heap
            NodeHeap heap = new NodeHeap();

            // Add some nodes
            // New Min Heap
            //         1
            //        / \
            //       2    5
            //      / \  
            //     20  7

            //PreOrder: 1 2 20 7 5
            //InOrder: 20 2 7 1 5
            //PostOrder: 20 7 2 5 1
            heap.Push(5);
            heap.Push(7);
            heap.Push(2);
            heap.Push(20);
            heap.Push(1);

            // Print heap tree
            PrintHeap(heap);

            // Remove a couple nodes
            heap.Pop();
            heap.Pop();

            Console.WriteLine();

            // Print heap tree
            PrintHeap(heap);

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public static void PrintHeap(NodeHeap heap)
        {
            Console.WriteLine("PreOrder: " + heap.PrintHeap(PrintOrder.PreOrder));
            Console.WriteLine("InOrder: " + heap.PrintHeap(PrintOrder.InOrder));
            Console.WriteLine("PostOrder: " + heap.PrintHeap(PrintOrder.PostOrder));
        }
    }
}
