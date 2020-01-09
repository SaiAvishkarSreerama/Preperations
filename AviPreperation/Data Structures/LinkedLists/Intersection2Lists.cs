using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
 
   //Definition for singly-linked list.
   public class ListNode1 {
       public int val;
       public ListNode1 next;
       public ListNode1(int x) { val = x; }
   }
   
    public class Solution
    {
        //TC - O(m+n)
        //SC - O(1)
        public ListNode1 GetIntersectionNode(ListNode1 headA, ListNode1 headB)
        {
            if (headA == null || headB == null)
                return null;
            //using 2pointer and staring pointers are both list heads
            ListNode1 a = headA;
            ListNode1 b = headB;

            // Here A and B length might not be same, so we cannot get a meeting point
            // So once either of the lists becomes null, then assign other head to it; a=headB&& b=headA
            // So the total list a can traverse is A+B and b is B+A, so 
            while (a != b)
            {
                a = a == null ? headB : a.next; //a == > 2,4,6,[null],1,5,[null]
                b = b == null ? headA : b.next; //b == > 1,5,[null],2,4,6,[null] now both a==b==null then no loop

            }

            //it means a==b at one point, just retrun a or b
            return a;
        }
    }
}
