using System;

namespace LinkedList
{
    public class Node
    {
        internal Node Next;
        internal Node Prev;
        internal object Value;
        public Node(object obj)
        {
            Value = obj;
            Next = null;
            Prev = null;
        }
    }

    public class DoublyLinkedList
    {
        internal Node head;
        internal Node tail;
        internal Node current; //This will have latest node
        public int Count;
        public DoublyLinkedList()
        {
            current = head = tail = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return head == null;
        }


        public void AddLast(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
                current = newNode;
            }
            Count++;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head.Next == null) //only one node in the list
            {
                head = null;
                tail = null;
                current = null;
            }
            else
            {
                //just move the head
                head = head.Next;
                head.Prev = null;
            }
            {
                if (current == tail)
                {
                    current = current.Prev;
                }
                tail = tail.Prev;
            }
            Count--;
        }

        public void AddStart(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
                current = newNode;
            }
            Count++;
        }

        public void RemoveStart()
        {
            if (!IsEmpty())
            {
                if (current == head)
                {
                    current = head.Next;
                }
                head = head.Next;
                Count--;
            }
            else
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
        }

        // to be updated
        //public void InsertNode(Node n, object data)
        //{
        //    Node newNode = new Node(data);
        //    if (Count == 0)
        //    {
        //        head = tail = current = newNode;
        //    }
        //    else
        //    {
        //        newNode.Next = head;
        //        head = newNode;
        //        current = newNode;
        //    }
        //    Count++;
        //}

        public void PrintList()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty list!");
            }
            else
            {
                Console.Write("Head");
                Node curr = head;
                while (curr != null)
                {
                    Console.Write(" <-");
                    Console.Write(curr.Value);
                    Console.Write("-> ");
                    curr = curr.Next;
                }
                Console.Write("Tail");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();
            list.PrintList();
            //list.RemoveLast();
            Console.WriteLine();
            list.AddLast(789);
            Console.WriteLine(list.current.Value);

            Console.WriteLine();
            list.AddLast("Bob");
            list.AddLast("John");
            Console.WriteLine(list.current.Value);

            list.PrintList();
            Console.WriteLine();

            list.AddStart(123);
            Console.WriteLine(list.current.Value);
            list.PrintList();
            Console.WriteLine();

            list.RemoveStart();
            list.PrintList();
        }
    }
}