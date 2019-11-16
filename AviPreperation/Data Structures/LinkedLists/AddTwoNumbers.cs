using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class AddTwoNumbersSol
    {

        //Time Complexity - O(Max(m,n)), It will parallelly traverse both lists, but it has to traverse the maximum list completely to reach the last value and to add it.
        //Space complexity - O(Max(m,n)), The out put is addition of both some time +1 extra node also happens, like 9 + 1 = 10(2nodes)
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(0);
            ListNode cur = dummy;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                cur.next = new ListNode(sum % 10);
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry > 0)
                cur.next = new ListNode(carry);

            return dummy.next;
        }

        public static void Main()
        {
            ListNode l1 = new ListNode(9);
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(9);
            l2.next.next.next = new ListNode(9);
            l2.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next.next.next = new ListNode(9);
            l2.next.next.next.next.next.next.next.next.next.next = new ListNode(9);

            AddTwoNumbersSol add = new AddTwoNumbersSol();
            add.AddTwoNumbers(l1, l2);

        }
    }
}
