using System;

namespace data_structures{
    public class Stack
    {
        private int maxSize;
        private char[] stackArray;
        private int top;

        public Stack(int size)
        {
            this.maxSize = size;
            this.stackArray = new char[maxSize];
            this.top = -1;
        }

        public void push(char j)
        {
            if(isFull())
            {
                return;
            }
            top++;
            stackArray[top] = j;
        }

        public char pop()
        {
            if(isEmpty())
            {
               Console.WriteLine("No items to pop");
                return '0';
            }
            else
            {
                int oldTop = top;
                top--;
                return stackArray[oldTop];
            }
          
        }

        public char peak()
        {
            return stackArray[top];
        }
        
        public bool isEmpty()
        {
            return (top == -1);
        }

        public bool isFull()
        {
            return (maxSize - 1 == top);
        }
    }
}
