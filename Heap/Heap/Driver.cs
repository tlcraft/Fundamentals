using System;
using static Heap.Enums;

namespace Heap
{
    class Driver
    {
        static void Main(string[] args)
        {
            // Node Heap
            NodeHeap heap = new NodeHeap();

            // Add some nodes
            heap.Push(5);
            heap.Push(7);
            heap.Push(2);
            heap.Push(20);
            heap.Push(1);

            // Print heap tree
            Console.WriteLine("PreOrder: " + heap.PrintHeap(PrintOrder.PreOrder));
            Console.WriteLine("InOrder: " + heap.PrintHeap(PrintOrder.InOrder));
            Console.WriteLine("PostOrder: " + heap.PrintHeap(PrintOrder.PostOrder));

            // Remove a couple nodes
            //heap.Pop(7);
            //heap.Pop(20);

            // Print heap tree
            //Console.WriteLine("PreOrder: " + heap.ToString(PrintOrder.PreOrder));
            //Console.WriteLine("InOrder: " + heap.ToString(PrintOrder.InOrder));
            //Console.WriteLine("PostOrder: " + heap.ToString(PrintOrder.PostOrder));

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
