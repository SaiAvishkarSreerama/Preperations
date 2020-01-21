using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class AddTwoNumbersSol
    {
        //TC- O(max(m,n))
        //SC- O(max(m,n)) for recusion call stack
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //return linked list
            ListNode res = new ListNode(0);

            //if both are nulls then return null
            if (l1 == null && l2 == null)
                return res.next;
            //if any one is null return the other
            if (l1 == null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }

            helper(l1, l2, res, 0);
            return res.next;
        }

        public void helper(ListNode l1, ListNode l2, ListNode res, int carry)
        {
            if (l1 == null && l2 == null)
            {
                if (carry > 0)
                    res.next = new ListNode(carry);
                return;
            }

            int v1 = l1 == null ? 0 : l1.val;
            int v2 = l2 == null ? 0 : l2.val;
            int val = v1 + v2 + carry;
            carry = val / 10;

            res.next = new ListNode(val % 10);
            res = res.next;
            helper(l1 == null ? l1 : l1.next, l2 == null ? l2 : l2.next, res, carry);
        }


        //Time Complexity - O(Max(m,n)), It will parallelly traverse both lists, but it has to traverse the maximum list completely to reach the last value and to add it.
        //Space complexity - O(Max(m,n)), The out put is addition of both some time +1 extra node also happens, like 9 + 1 = 10(2nodes)
        public ListNode AddTwoNumbers1(ListNode l1, ListNode l2)
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

        //public static void Main()
        //{
        //    //ListNode l1 = new ListNode(9);
        //    //ListNode l2 = new ListNode(1);
        //    //l2.next = new ListNode(9);
        //    //l2.next.next = new ListNode(9);
        //    //l2.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next.next.next.next.next = new ListNode(9);
        //    //l2.next.next.next.next.next.next.next.next.next.next = new ListNode(9);



        //    ListNode l1 = new ListNode(2);
        //    l1.next = new ListNode(4);
        //    l1.next.next = new ListNode(3);


        //    ListNode l2 = new ListNode(5);
        //    l2.next = new ListNode(6);
        //    l2.next.next = new ListNode(7);

        //    AddTwoNumbersSol add = new AddTwoNumbersSol();
        //    add.AddTwoNumbers(l1, l2);

        //}
    }
}
