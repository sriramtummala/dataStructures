using System;

namespace ds.circularlinkedlist
{
    public class Node
    {
        public int data;
        public Node next;

        public void displayNode()
        {
            Console.WriteLine(data);
            Console.ReadKey();
        }
    }
}
