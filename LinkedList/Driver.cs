using System;

namespace LinkedList
{
    class Driver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Let's check out a linked list!");

            LinkedList list = new LinkedList();
            list.Add(10);
            list.Add(15);
            list.Add(20);
            Console.WriteLine(list.ToString());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}