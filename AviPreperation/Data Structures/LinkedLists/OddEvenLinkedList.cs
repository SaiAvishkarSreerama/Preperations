using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    //Odd and even are the positions, not the values
    class OddEvenLinkedList
    {
        //Time Complexity - O(n) as it traverse to all nodes only once
        //Space Complexity - O(1) as we did not use any extra DS to store, we used the given linkedlist only
        public ListNode OddEvenList(ListNode head)
        {
            //Null case
            if (head == null)
                return head;

            //we need an 
            //odd pointer at head and oddHead at head
            //even pointer at head.next and evenHead at even
            ListNode odd = head; //oddHead
            ListNode even = head.next;
            ListNode evenHead = even;

            //Logic is at first odd is at odd node, even is at even node,
            // after even there comes another odd node, shift that node to odd.next and nexct even to current even
            // once we shift them, move odd and even to next nodes.
            // now odd - odd - even - even - odd- even  -odd - even.......
            //REPEAT it till the odds are foillowed by even.
            //But the last odd is not attached to first even, there comes the evenHEad is still at first even node
            //now put odd.next = evenHead and return head
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}
