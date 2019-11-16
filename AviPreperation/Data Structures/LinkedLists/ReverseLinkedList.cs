using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class ReverseLinkedList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        //TimeComplexity - O(n)
        //SpaceComplexity - O(1)
        public static ListNode ReverseListIteration(ListNode head)
        {
            //USING ITERATION
            //To reverse the linked list, we need a head to move to back and back should comes to front
            //Take head as current
            //Move the cur.next(Next) to front of head by following below steps
            //1. cur.next = cur.next.next(Next.next)
            //2. Next.next = head;
            //3. Finalky make Next as head==> head=Next. Repeat it till we have cur.next null
            if (head != null)
            {
                ListNode cur = head;
                while (cur.next != null)
                {
                    ListNode nxt = cur.next;
                    cur.next = nxt.next;
                    nxt.next = head;
                    head = nxt;
                }
            }
            return head;
        }

        //TimeComplexity - O(n)
        //SpaceComplexity - O(n) // for recursion we are creating n stack of lists
        public static ListNode ReverseListRecursion(ListNode head)
        {
            //USING RECURSIVE
            if (head == null || head.next == null)
                return head;

            ListNode p = ReverseListRecursion(head.next);
            head.next.next = head;
            head.next = null;
            return p;
        }

        //public static void Main()
        //{
        //    ListNode node = new ListNode(1);
        //    node.next = new ListNode(2);
        //    node.next.next = new ListNode(3);
        //    node.next.next.next = new ListNode(4);
        //    node.next.next.next.next = new ListNode(5);

        //    ReverseListRecursion(node);
        //}

    }
}
