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

    //Time Complexity - O(n) as it is traversing the whole list
    //Space Complexity - O(1), not using any other DS

    public class IsPalindromeSolution
    {
        public static bool IsPalindrome(ListNode head)
        {
            //always check for null case
            if (head == null)
                return true;

            ListNode slow = head;
            ListNode fast = head;

            //Move fast to the end(double the speed of slow) , means slow will be at exactly middle of the list
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            //now put fast to head and slow from middle
            fast = head;
            //reverse the slow 
            slow = reverse(slow);

            //Compare fast and slow by traversing one step each
            //If not match return false
            while (slow != null)
            {
                if (slow.val != fast.val)
                {
                    return false;
                }
                fast = fast.next;
                slow = slow.next;
            }

            return true;
        }

        //reverse the list with iterative approach, also check ReverseLinkedList.cs file for recursive approach
        public static ListNode reverse(ListNode head)
        {
            ListNode cur = head;

            while (cur.next != null)
            {
                ListNode Next = cur.next;
                cur.next = Next.next;
                Next.next = head;
                head = Next;
            }

            return head;
        }

        //public static void Main()
        //{
        //    ListNode node = new ListNode(1);
        //    node.next = new ListNode(2);
        //    node.next.next = new ListNode(3);
        //    node.next.next.next = new ListNode(2);
        //    node.next.next.next.next = new ListNode(1);


        //    Console.WriteLine(IsPalindrome(node));
        //    Console.ReadLine();
        //}
    }
}
