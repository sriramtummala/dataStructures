namespace ds.singlyLinkedList
{
    public class SinglyLinkedList
    {
        private Node first;

        public SinglyLinkedList()
        {

        }

        public bool isEmpty()
        {
            return (first == null);
        }

        public void insertFirst(int data)
        {
            Node newNode = new Node();
            newNode.data = data;
            newNode.next = first;
            first = newNode;
        }

        public Node deleteFirst()
        {
            Node temp = first;
            first = first.next;
            return temp;
        }

        public void insertLast(int data)
        {
            Node current = first;
            while (current.next != null)
            {
                current = current.next;
            }
            Node newNode = new Node();
            newNode.data = data;
            current.next = newNode;
        }

    }
}
