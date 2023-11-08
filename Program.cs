using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

class HelloWorld
{
    public class DoublyNode<T>
    {

        public DoublyNode(T data)
        {
            Data = data;
            prev = null;
            next = null;
        }

        public T Data { get; }
        public DoublyNode<T> prev;
        public DoublyNode<T> next;

    }
    public class Deque<T>
    {
        public DoublyNode<T> head;
        public DoublyNode<T> tail;
        public DoublyNode<T> Current;

        public Deque(T inputData)
        {
            DoublyNode<T> node = new DoublyNode<T>(inputData);
            head = node;
            tail = node;
        }
        public void AddFirst(T inputData)
        {
            DoublyNode<T> node = new DoublyNode<T>(inputData);
            node.next = head;
            head.prev = node;
            head = node;
        }
        public void AddLast(T inputData)
        {
            DoublyNode<T> node = new DoublyNode<T>(inputData);
            node.prev = tail;
            tail.next = node;
            tail = node;
        }
        public void RemoveFirst()
        {
            head.next.prev = null;
            head = head.next;
        }
        public void RemoveLast()
        {
            tail.prev.next = null;
            tail = tail.prev;
        }

        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Doubly Linked List is empty");
                return;
            }
            Current = head;
            while (Current != null)
            {
                Console.Write(" " + Current.Data.ToString() + " ");
                Current = Current.next;
            }
        }
        public void Find(T findData)
        {
            Current = head;
            int count = 1;
            while (Current != null)
            {
                if (Current.Data.Equals(findData)) { Console.Write(" " + count.ToString() + " "); }
                count++;
                Current = Current.next;
            }
        }

        public void RemoveElement(int index)
        {
            int size = 0;
            Current = head;
            while (Current != null)
            {
                size++;
                Current = Current.next;
            }

            if (index == 1)
            {
                RemoveFirst();
            }
            else if (index == size)
            {
                RemoveLast();
            }
            else
            {
                int count = 1;
                Current = head;
                while (Current != null && count != index)
                {
                    Current = Current.next;
                    count++;
                }
                Current.prev.next = Current.next;
                Current.next.prev = Current.prev;
            }
        }
    }
    
    static int Main()
    {
        int FirVal = 0;
        Console.WriteLine("Enter the first value");
        FirVal = Convert.ToInt32(Console.ReadLine());
        Deque<int> deque = new Deque<int>(FirVal);

        for (;;)
        {
            int code;
            int val;

            Console.WriteLine("1 - AddFirst");
            Console.WriteLine("2 - AddLast");
            Console.WriteLine("3 - RemoveFirst");
            Console.WriteLine("4 - RemoveLast");
            Console.WriteLine("5 - Print");
            Console.WriteLine("6 - Find");
            Console.WriteLine("7 - RemoveElement");
            Console.WriteLine("0 - выход");

            Console.Write("Code - ");
            code = Convert.ToInt32(Console.ReadLine());

            switch (code)
            {
                case 1:
                    Console.Write("Add = ");
                    val = Convert.ToInt32(Console.ReadLine());
                    deque.AddFirst(val);
                    break;

                case 2:
                    Console.Write("Add = ");
                    val = Convert.ToInt32(Console.ReadLine());
                    deque.AddLast(val);
                    break;

                case 3:
                    deque.RemoveFirst();
                    break;

                case 4:
                    deque.RemoveLast();
                    break;

                case 5:
                    deque.Print();
                    Console.WriteLine("");
                    break;

                case 6:
                    Console.Write("Find = ");
                    val = Convert.ToInt32(Console.ReadLine());
                    deque.Find(val);
                    Console.WriteLine("");
                    break;

                case 7:
                        Console.Write("Index = ");
                        val = Convert.ToInt32(Console.ReadLine());
                        deque.RemoveElement(val);
                        break;

                    case 0:
                    return 0;

                default:
                    Console.WriteLine("Error, Incorrect command entered");
                    break;
            }
        }
    }
}