using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.LinkedLists
{
    // Definition for a Node.
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node() { }
        public Node(int _val, Node _next, Node _random)
        {
            val = _val;
            next = _next;
            random = _random;
        }
    }
        
    public class CopyRandomListSolution
    {
        //Time - O(n) and Space - O(1)
        //https://www.youtube.com/watch?time_continue=451&v=OvpKeraoxW0&feature=emb_logo
        //https://github.com/bephrem1/backtobackswe/blob/master/Linked%20Lists/CloneLinkedListWithRandomPointers/CloneLinkedListWithRandomPointers.java

        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return head;
            //pass1 - Create a copy  and put it between cur--copy--cur.next
            Node cur = head;
            Node next = null;
            while (cur != null)
            {
                next = cur.next;
                Node c = new Node(cur.val, new Node(), null);
                c.next = next;
                cur.next = c;
                cur = next;
            }
            //pass2 - traverse and put random to copies from curr
            cur = head;
            while (cur != null)
            {
                if (cur.random != null)
                {
                    cur.next.random = cur.random.next;
                }
                cur = cur.next.next;
            }
            //pass3 - Create a dummy and attach the copy to it by removing cur-->copy and reset to cur-->cur.next
            cur = head;
            Node dummy = new Node(0, new Node(), null);
            Node copyTail = dummy;
            Node copy = null;

            while (cur != null)
            {
                next = cur.next.next;
                copy = cur.next;

                copyTail.next = copy;
                copyTail = copy;

                cur.next = next;
                cur = next;
            }

            return dummy.next;
        }
    }
}
