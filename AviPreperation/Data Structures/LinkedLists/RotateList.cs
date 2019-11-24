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

        //Time Complexity - O(n)
        //Space Complexity - O(1)
    public class RotateListSolution
    {
        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || k == 0)
            {
                return head;
            }
            //find the length of the given linked list
            int l = 1;
            ListNode last = head;

            while (last.next != null)
            {
                last = last.next; // so, node last is at the end of the list, which helps to attach head to it for rotation 
                l++;
            }

            //figure out how many real rotations required
            k %= l;

            ListNode cur = head;
            //rotate k times
            if (k > 0)
            {
                //need to traverse the list upto the no of rotations
                int lt = l - (k + 1);

                while (lt > 0)
                {
                    cur = cur.next;
                    lt--;
                }

                last.next = head;
                head = cur.next;
                cur.next = null;
            }

            return head;
        }
    }
}
