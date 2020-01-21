using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    class MergeSortedLinkedLists
    {
        /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

        /***************************RECURSION*****************************************/
        //TimeComplexity - O(m+n)
        //SpaceComplexity - O(m+n) n+m stack frames for n+m output
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            ListNode res = new ListNode(0);

            helper(l1, l2, res);
            return res.next;
        }

        public void helper(ListNode l1, ListNode l2, ListNode res)
        {
            if (l1 == null)
            {
                res.next = l2;
                return;
            }
            if (l2 == null)
            {
                res.next = l1;
                return;
            }

            if (l1.val < l2.val)
            {
                res.next = new ListNode(l1.val);
                l1 = l1.next;
            }
            else
            {
                res.next = new ListNode(l2.val);
                l2 = l2.next;
            }
            res = res.next;
            helper(l1, l2, res);
        }

        /***************************ITERATION*****************************************/
        //TimeComplexity - O(m+n), m = length l1, n = length l2
        //SpaceComplexity - O(1) 
        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            ListNode dummy = new ListNode(0);
            ListNode cur = dummy;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }
                cur = cur.next;
            }

            //if (l1 == null)
            //{
            //    cur.next = l2;
            //}
            //if (l2 == null)
            //{
            //    cur.next = l1;
            //}

            cur.next = l1 == null ? l2 : l1;

            return dummy.next;
        }
    }
}
