using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given a linked list, swap every two adjacent nodes and return its head.
* You may not modify the values in the list's nodes, only nodes itself may be changed.
* 
* Example:
* Given 1->2->3->4, you should return the list as 2->1->4->3.
*/
namespace AviPreperation.Data_Structures.Recursion
{
    public class SwapNodesInPairsSolution { 


  //Definition for singly-linked list.
    public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        //Time Complexity - O(N)
        //Space Complexity - O(N), for n recursive stacks
        public ListNode SwapPairs_Recursive(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode n = head.next;
            head.next = SwapPairs_Recursive(head.next.next);
            n.next = head;
            return n;

        }

        //Iterative
        //Time Complexity - O(N)
        //Space Complexity - O(1)
        public ListNode SwapPairs_Iterative(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode cur = head;
            ListNode newHead = head.next;

            while (cur != null && cur.next != null)
            {
                ListNode temp = cur;         //AT THIS STEP: temp(1) --> cur(2) --> next group(3-->4)
                cur = cur.next;
                temp.next = cur.next;
                cur.next = temp;             //AT THIS STEP: cur(2) --> temp(1) --> next group(3-->4)
                cur = temp.next;
                if (cur != null && cur.next != null)//with out doing this it return 2-1-3 as the 1 still poits to 3
                    temp.next = cur.next;// by doing this we connect 2-1 ==> to 4, which is (cur.next)==>3.next
            }
            return newHead;
        }
    }
}
