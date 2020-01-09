using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

    //TC- O(max(m,n))
    //SC - O(max(m,n))
    public class AddTwoNumbersSolII
    {
        public ListNode AddTwoNumbersII(ListNode l1, ListNode l2)
        {
            l1 = Reverse(l1);
            l2 = Reverse(l2);

            ListNode head = new ListNode(0);
            ListNode cur = head;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;
                int sum = x + y + carry;
                carry = sum / 10;

                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            if (carry > 0)
            {
                cur.next = new ListNode(carry);
            }

            ListNode res = Reverse(head.next);
            return res;
        }

        public ListNode Reverse(ListNode head)
        {
            ListNode cur = head;
            while (cur.next != null)
            {
                ListNode next = cur.next;
                cur.next = next.next;
                next.next = head;
                head = next;
            }
            return head;
        }
    }
}
