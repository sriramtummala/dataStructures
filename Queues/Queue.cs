using System;

namespace ds.queue
{
    public class Queue
    {
        private int maxSize; // maintains set number of slots 
        private long[] queArray; // slots to maintain the data
        private int front; // this will be index position for the element in the front
        private int rear; // index position for the element at the back
        private int nItems;

        public Queue(int size)
        {
            this.maxSize = size;
            this.queArray = new long[size];
            front = 0; // index position of the first slot of the array
            rear = -1; // there is no item in the array yet to be considered as the last item
            nItems = 0;
        }

        public void insert(long j)
        {
            if (rear == maxSize -1)
            {
                rear= -1;
            }
                 rear++;
                queArray[rear] = j;
                nItems++;
        }

        public long remove()
        {
            long temp = queArray[front];
            front++;
            if(front == maxSize)
            {
                front = 0;
            }
            nItems--;
            return temp;
        }

        public long peekFront()
        {
            return queArray[front];
        }
        public bool isEmpty()
        {
            return (nItems == 0);
        }

        public bool isFull()
        {
            return (nItems == maxSize);
        }

        public void view()
        {
            for(int i =0; i <= queArray.Length - 1; i++)
            {
                Console.WriteLine(queArray[i]);
            }
            Console.ReadKey();
        }
    }
}
