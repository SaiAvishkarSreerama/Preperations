using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures
{
    public class Stack
    {
        private int top;
        private int max;
        private int[] ele;

        public Stack(int size)
        {
            ele = new int[size];
            max = size;
            top = -1;
        }

        public void Push(int item)
        {
            if (top == max - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                ele[++top] = item;
            }
        }

        public int Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
            {
                Console.WriteLine(ele[top--]);
                return ele[top--];
            }
        }

        public int Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
            {
                Console.WriteLine(ele[top]);
                return ele[top];
            }
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                for (int i = 0; i < ele.Length; i++)
                {
                    Console.WriteLine(ele[i]);
                    Console.ReadLine();
                }
            }
        }
    }

    public class StackUsingArray
    {
        //static void Main()
        //{
        //    var stack = new Stack(4);
        //    stack.Push(10);
        //    stack.Push(30);
        //    stack.Push(20);
        //    stack.Push(90);

        //    stack.Pop();
        //    stack.Peek();
        //    stack.PrintStack();
        //}
    }

    public class StacksLinkedLikst
    {
        StackNode root;

        public class StackNode
        {
            public int data;
            public StackNode next;

            public StackNode(int data)
            {
                this.data = data;
            }
        }

        public bool isEmpty()
        {
            return root == null ? false : true;
        }

        public void Push(int data)
        {
            StackNode newNode = new StackNode(data);
            if (root == null)
                root = newNode;
            else
            {
                StackNode temp = root;
                root = newNode;
                newNode.next = temp;
            }
        }

        public int Pop()
        {
            int popped = int.MinValue;
            if (root == null)
                Console.WriteLine("Stack is Empty");
            else
            {
                popped = root.data;
                root = root.next;
            }
            return popped;
        }

        public int Peek()
        {
            if (root == null)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            else
                return root.data;
        }
        //public static void Main(String[] args)
        //{

        //    StacksLinkedLikst sll = new StacksLinkedLikst();

        //    sll.Push(10);
        //    sll.Push(20);
        //    sll.Push(30);

        //    Console.WriteLine(sll.Pop() + " popped from stack");

        //    Console.WriteLine("Top element is " + sll.Peek());
        //}
    }
}

