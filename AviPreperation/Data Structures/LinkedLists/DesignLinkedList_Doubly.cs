using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    public class MyLinkedListDoubly
    {
        /*Declare a DoublyNode class with int val and DoublyNode next and construct the DoublyNode
         * HINT: Always depend on Size of the Linked list
         * 1. If size is 0 - Add at Head
         * 2. If index >= size, Nothing happens (linked list with indexes 0 and 1 for size-2, if htey give index2 does not exists)
         * 3. If index < size, then the index value exists in linked list, then we can add/Remove.
         */
        public class DoublyNode
        {
            public int val;
            public DoublyNode prev;
            public DoublyNode next;
            public DoublyNode(int x)
            {
                val = x;
                prev = null;
                next = null;
            }
        }
        //Head of Linked List
        public DoublyNode head;
        //Size of linked list
        public int size;

        /** Initialize your data structure here. */
        public MyLinkedListDoubly()
        {
            size = 0;
        }

        /** Get the value of the index-th DoublyNode in the linked list. If the index is invalid, return -1. */
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

        /** Add a DoublyNode of value val before the first element of the linked list. After the insertion, 
         * the new DoublyNode   will be the first DoublyNode of the linked list. */
        public void AddAtHead(int val)
        {
            DoublyNode cur = new DoublyNode(val);
            cur.next = head;
            if (head != null)
                head.prev = cur;
            head = cur;
            size++;
        }

        /** Append a DoublyNode of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            DoublyNode node = new DoublyNode(val);
            if (size == 0)
            {
                head = node;
            }
            else
            {
                DoublyNode cur = head;
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = node;
                node.prev = cur;
            }
            size++;
        }

        /** Add a DoublyNode of value val before the index-th DoublyNode in the linked list. 
        * If index equals to the length of linked list, the DoublyNode will be appended to the end of linked list. 
        * If index is greater than the length, the DoublyNode will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index > size) return;
            else if (index == 0) AddAtHead(val);
            else if (size == index) AddAtTail(val);
            else if (index < size)
            {
                DoublyNode cur = new DoublyNode(val);
                DoublyNode prev = head;
                for (int i = 0; i < index - 1; i++)
                {
                    prev = prev.next;
                }
                //next DoublyNode connection to cur
                cur.next = prev.next;
                prev.next.prev = cur;
                //prev DoublyNode connection to cur
                prev.next = cur;
                cur.prev = prev;
                size++;
            }
        }

        /** Delete the index-th DoublyNode in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            if (index == 0)
            {
                head = head.next;
                head.prev = null;
                size--;

            }
            else if (index < size)
            {
                DoublyNode cur = head;
                for (int i = 0; i < index; i++)
                {
                    cur = cur.next;
                }
                cur.prev.next = cur.next;
                cur.next.prev = cur.prev;
                size--;

            }
        }
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
