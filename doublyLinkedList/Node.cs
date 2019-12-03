using System;

namespace ds.doublylinkedlist
{
    public class Node
    {
        public int data;
        public Node next;
        public Node previous;

        public void displayNode()
        {
            Console.WriteLine(data);
            Console.ReadKey();
        }
    }
}
