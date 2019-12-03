namespace ds.binarysearchtree
{
    public class BST
    {
        private Node root;

        public void insert(int key, string value)
        {
            Node newNode = new Node(key, value);
            if(root == null)
            {
                root = newNode;
            } else
            {
                Node current = root;
                Node parent;

                while (true)
                {
                    parent = current;
                    if(key < current.key)
                    {
                        current = current.leftChild;
                        if(current == null) // its parent is the leaf node
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if(current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public Node findMin()
        {
            Node current = root;
            Node last = null;
            while (current != null)
            {
                last = current;
                current = current.leftChild;
            }
            return last;
        }

        public Node findMax()
        {
            Node current = root;
            Node last = null;
            while (current != null)
            {
                last = current;
                current = current.rightChild;
            }
            return last;
        }

        public bool remove(int key)
        {
            Node currentNode = root;
            Node parentNode = root;

            bool isLeftChild = false;

            //Searching to find the node with the key to delete
            while(currentNode.key != key)
            {
                parentNode = currentNode;
                if(key < currentNode.key)
                {
                    isLeftChild = true;
                    currentNode = currentNode.leftChild;

                }
                else
                {
                    currentNode = currentNode.rightChild;
                    isLeftChild = false;
                }

                if(currentNode == null)
                {
                    return false;
                }
            }

            //found  the node
            Node nodeToDelete = currentNode;

            // if node is leaf node
            if(nodeToDelete.leftChild == null && nodeToDelete.rightChild == null)
            {
                if(nodeToDelete == root)
                {
                    root = null;
                }
                else if (isLeftChild)
                {
                    parentNode.leftChild = null;
                }
                else
                {
                    parentNode.rightChild = null;
                }

            }

            // if node has one child on left
            else if(nodeToDelete.rightChild == null)
            {
                if(nodeToDelete == root)
                {
                    root = nodeToDelete.leftChild;
                } else if (isLeftChild)
                {
                    parentNode.leftChild = nodeToDelete.leftChild;
                }else
                {
                    parentNode.rightChild = nodeToDelete.leftChild;
                }
            }

            // if node has one child on right
            else if (nodeToDelete.leftChild == null)
            {
                if (nodeToDelete == root)
                {
                    root = nodeToDelete.rightChild;
                }
                else if (isLeftChild)
                {
                    parentNode.leftChild = nodeToDelete.rightChild;
                }
                else
                {
                    parentNode.rightChild = nodeToDelete.rightChild;
                }
            }

            // if node has 2 children
            else
            {
                Node successor = getSuccessor(nodeToDelete);

                // connect parent of nodetodelete to successor instead
                if(nodeToDelete == root)
                {
                    root = successor;
                }else if (isLeftChild)
                {
                    parentNode.leftChild = successor;
                }
                else
                {
                    parentNode.rightChild = successor;
                }
                successor.leftChild = nodeToDelete.leftChild;
            }

            return true;
        }

        private Node getSuccessor(Node nodeToDelete)
        {
            Node successorParent = nodeToDelete;
            Node successor = nodeToDelete;

            Node current = nodeToDelete.rightChild;
            while (current != null) // start going left down th tree until node has no left child
            {
                successorParent = successor;
                successor = current;
                current = current.leftChild;
            }

            //if successor is not a right child
            if (successor != nodeToDelete.rightChild)
            {
                successorParent.leftChild = successor.rightChild;
                successor.rightChild = nodeToDelete.rightChild;
            }

            return successor;
        }
    }
}
