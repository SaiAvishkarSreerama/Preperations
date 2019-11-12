    using System;
    using System.Collections.Generic;
    using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }
    class LinkedListCycle2
    {
        //Slow,fast meets at some point p if there is a loop
        //let say q is the place where loop starts
        //let distances
        // a - from head to q
        // b - from q to p
        // c - from p to q
        // at this time slow pointer covers a+b, where fast covers a+b+c+again b to meet p
        // fast is 2 times of slow
        // 2(a+b) = a+2b+c ==> a==c; so while slow covers remaing c to come to q. slow2 from head covers a to come to q
        // so both will meet at q, where the loops starts.
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;

                if (fast == slow)
                {
                    ListNode slow2 = head;
                    while (slow2 != slow)
                    {
                        slow2 = slow2.next;
                        slow = slow.next;
                    }
                    return slow;
                }
            }
            return null;
        }
    }
}