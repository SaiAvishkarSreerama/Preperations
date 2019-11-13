using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    
    public class RemoveLinkedListEleSol
    {

        //TimeComplexity - O(n)
        //SpaceComplexity - O(1)
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return head;

            //creating a dummy note for the case, if the head is equal to val
            //then seeing from dummy value, eliminate head and then next numbers
            ListNode dummy = new ListNode(val);
            dummy.next = head;

            //set cur value to dummy
            ListNode cur = dummy;

            //if cur.next not null, then loop
            //if cur.next==val, then exclude cur.next by setting to cur.next.next, else move cur forward
            while (cur.next != null)
            {
                if (cur.next.val == val)
                {
                    cur.next = cur.next.next;
                }
                else
                {
                    cur = cur.next;
                }
            }

            //eliminate dummy and return from next nodes
            return dummy.next;
        }
    }
}
