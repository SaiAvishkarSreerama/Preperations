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
    public class ReverseALinkedListinKGroupsSolution
    {
        //Using ITERATION
        //TC - O(N)
        //SC - O(1)
        public ListNode ReverseKGroup1(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 1)
                return head;

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode start = dummy;
            int i = 0;
            while (head != null)
            {
                i++;
                if (i % k == 0)
                {
                    start = ReverseList(start, head.next);
                    head = start.next;
                }
                else
                {
                    head = head.next;
                }
            }

            return dummy.next;
        }

        public ListNode ReverseList(ListNode start, ListNode end)
        {
            ListNode first, prev, cur, next;
            prev = start;
            cur = start.next;
            first = cur;
            while (cur != end)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
            }
            start.next = prev;
            first.next = cur;
            return first;
        }

        //ITERATION
        //TC - O(N)
        //SC - O(N)
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode curr = head;
            int count = 0;
            while (curr != null && count != k)
            { // find the k+1 node
                curr = curr.next;
                count++;
            }
            if (count == k)
            { // if k+1 node is found
                curr = ReverseKGroup(curr, k); // reverse list with k+1 node as head
                                               // head - head-pointer to direct part, 
                                               // curr - head-pointer to reversed part;
                while (count-- > 0)
                { // reverse current k-group: 
                    ListNode tmp = head.next; // tmp - next head in direct part
                    head.next = curr; // preappending "direct" head to the reversed list 
                    curr = head; // move head of reversed part to a new node
                    head = tmp; // move "direct" head to the next node in direct part
                }
                head = curr;
            }
            return head;
        }

        //public static void Main()
        //{
        //    ListNode a = new ListNode(1);
        //    a.next = new ListNode(2);
        //    a.next.next = new ListNode(3);
        //    a.next.next.next = new ListNode(4);
        //    a.next.next.next.next = new ListNode(5);
        //    a.next.next.next.next.next = new ListNode(6);
        //    a.next.next.next.next.next.next = new ListNode(7);


        //    var obj = new ReverseALinkedListinKGroupsSolution();
        //    obj.ReverseKGroup(a, 3);

        //}
    }
}
