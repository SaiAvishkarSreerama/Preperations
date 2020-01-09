using System;
using System.Collections.Generic;
using System.Text;

/*Given a sorted linked list, delete all duplicates such that each element appear only once.

Example 1:

Input: 1->1->2
Output: 1->2
Example 2:

Input: 1->1->2->3->3
Output: 1->2->3*/
namespace AviPreperation.Data_Structures.LinkedLists
{
    public class RemoveDuplicatesfromSortedListSol
    {
        //Time Complexity - O(n)
        //Space Complexity - O(1)
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;

            ListNode cur = head;
            while (cur != null && cur.next != null)
            {
                if (cur.val == cur.next.val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }

            return head;
        }
    }
}
