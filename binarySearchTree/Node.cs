namespace ds.binarysearchtree
{
    public class Node
    {
        public int key;
        public string value;
        public Node leftChild, rightChild;

        public Node(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
