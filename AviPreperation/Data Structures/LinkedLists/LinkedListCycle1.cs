    using System;
    using System.Collections.Generic;
    using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class LinkedListCycle1
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

            public bool HasCycle(ListNode head)
            {

                ListNode slow = head;
                ListNode fast = head;

                while (slow != null && fast != null && fast.next != null)
                {

                    slow = slow.next;
                    fast = fast.next.next;

                    if (slow == fast)
                        return true;
                }
                return false;
            }
        }
    }
}