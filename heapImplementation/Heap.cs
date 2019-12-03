namespace heapImplementation
{
    public class Heap
    {
        private Node[] heapArray;
        private int maxSize;
        private int currentSize;

        public Heap(int size)
        {
            this.maxSize = size;
            currentSize = 0;
            heapArray = new Node[size];
        }

        public int getSize()
        {
            return currentSize;
        }

        public bool isEmpty()
        {
            return (currentSize == 0);
        }

        public bool insert(int key)
        {
            if(currentSize == maxSize) //array is full 
            {
                return false;
            }

            Node newNode = new Node(key);
            heapArray[currentSize] = newNode;

            trickleUp(currentSize);

            currentSize++;
            return true;
        }

        private void trickleUp(int idx)
        {
            int parentIndx = (idx - 1) / 2;
            Node nodeToInsert = heapArray[idx];

            while(idx > 0 && heapArray[parentIndx].getKey() < nodeToInsert.getKey())
            {
                heapArray[idx] = heapArray[parentIndx]; // move parent down
                idx = parentIndx;
                parentIndx = (parentIndx - 1) / 2; // move up
            }
            heapArray[idx] = nodeToInsert;
        }

        public Node remove()
        {
            Node root = heapArray[0];
            currentSize--;
            heapArray[0] = heapArray[currentSize];
            trickleDown(0);

            return root;

        }

        private void trickleDown(int idx)
        {
            int largerChildIdx;
            Node top = heapArray[idx]; // save last into top variable

            // will run as long as idx is not on the bottom row
            while(idx < currentSize / 2)
            {
                int leftChildIdx = 2 * idx + 1;  // left child idx position
                int rightChildIdx = 2 * idx + 2; // right child idx position

                //figure out which child is larger
                if(rightChildIdx < currentSize & heapArray[leftChildIdx].getKey()< heapArray[rightChildIdx].getKey())
                {
                    largerChildIdx = rightChildIdx;
                } else
                {
                    largerChildIdx = leftChildIdx;
                }

                if(top.getKey()>= heapArray[largerChildIdx].getKey())
                {
                    // successefully made root the largest key
                    break;
                }

                heapArray[idx] = heapArray[largerChildIdx];
                idx = largerChildIdx; // go down
            }
            heapArray[idx] = top;
        }
    }
}
