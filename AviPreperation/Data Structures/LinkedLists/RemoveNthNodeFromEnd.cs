using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class RemoveNthNodeFromEndclass
    {
        /* Definition for singly-linked list.*/
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    
        //One pass over the linked list with 2pointers
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {


            //create a Dummy node for edge case of head =[1], one value
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            //f and s starts from the dummy
            ListNode slow = dummy;
            ListNode fast = dummy;

            //keeing the distance between s and f as n, so not traversing s untill f moves n times by reducing the n
            // each time, once n becomes 0 after n passes, s starts, so f-s=n(given number)
            while (fast.next != null)
            {
                fast = fast.next;

                if (n <= 0)
                    slow = slow.next;
                n--;
            }
            //once f.next is null then f is at last num, and s is n steps behind
            //so, replace s.next with s.next.next
            slow.next = slow.next.next;
            return dummy.next;
        }
    }
}
