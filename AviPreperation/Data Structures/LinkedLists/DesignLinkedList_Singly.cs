using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    public class MyLinkedList
    {
        /*Declare a node class with int val and Node next and construct the node
         * HINT: Always depend on Size of the Linked list
         * 1. If size is 0 - Add at Head
         * 2. If index >= size, Nothing happens (linked list with indexes 0 and 1 for size-2, if htey give index2 does not exists)
         * 3. If index < size, then the index value exists in linked list, then we can add/Remove.
         */
        public class Node
        {
            public int val;
            public Node next;
            public Node(int x)
            {
                val = x;
            }
        }
        //Head of Linked List
        public Node head;
        //Size of linked list
        public int size;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            size = 0;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            if (index >= size)
                return -1;
            var cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }
            return cur.val;
        }

        /** Add a node of value val before the first element of the linked list. After the insertion, 
         * the new node   will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            Node cur = new Node(val);
            cur.next = head;
            head = cur;
            size++;
        }

        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            Node node = new Node(val);
            if (size == 0)
            {
                head = node;
            }
            else
            {
                Node cur = head;
                while(cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = node;
            }
            size++;
        }

        /** Add a node of value val before the index-th node in the linked list. 
        * If index equals to the length of linked list, the node will be appended to the end of linked list. 
        * If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > size) return;
            else if (index == 0) AddAtHead(val);
            else if (size == index) AddAtTail(val);
            else if (index < size)
            {
                Node cur = new Node(val);
                Node prev = head;
                for (int i = 0; i < index - 1; i++)
                {
                    prev = prev.next;
                }
                cur.next = prev.next;
                prev.next = cur;
                size++;
            }
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        /*NOTE: Always consider the deletion of 0 index, index >= size, index < size*/
        public void DeleteAtIndex(int index)
        {
            if (index >= size) return;
            size--;

            if (size == 0)
            {
                head = null;
                return;
            }

            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }
            current.next = current.next.next;
        }
    }

    //public class MainClass
    //{
    //    Your MyLinkedList object will be instantiated and called as such:
    //    public static void Main()
    //    {
    //        MyLinkedList obj = new MyLinkedList();
    //        int param_1 = obj.Get(1);
    //        obj.AddAtHead(1);
    //        obj.AddAtHead(4);
    //        obj.AddAtTail(4);
    //        obj.AddAtIndex(1, 3);
    //        obj.DeleteAtIndex(0);
    //    }
    //}
}
