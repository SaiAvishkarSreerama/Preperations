/*
 * Given the head of a linked list, remove the nth node from the end of the list and return its head.
 * 
 * Example 1:
 * Input: head = [1,2,3,4,5], n = 2
 * Output: [1,2,3,5]
 * 
 * Example 2:
 * Input: head = [1], n = 1
 * Output: []
 * 
 * Example 3:
 * Input: head = [1,2], n = 1
 * Output: [1]
 * 
 * Constraints:
 * The number of nodes in the list is sz.
 * 1 <= sz <= 30
 * 0 <= Node.val <= 100
 * 1 <= n <= sz
* **/

namespace PreperationsTest.LeetCode.Medium.LinkedLists
{
    [TestClass]
    public class _19_REmoveNthNodeFromtheEnd
    {
        [TestMethod]
        public void Run()
        {
            ListNode node5 = new ListNode(5);
            ListNode node4 = new ListNode(4, node5);
            ListNode node3 = new ListNode(3, node4);
            ListNode node2 = new ListNode(2, node3);
            ListNode node1 = new ListNode(1, node2);

            ListNode result1 = RemoveNthFromEnd(node1, 2);
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        #region My code
        /// <summary>
        /// Remove the nth node from the end of the list
        /// here n=2 for this example
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode currentNode = head;
            int count = 1;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                count++;
            }

            int n_1thNode = count - n;
            currentNode = head;
            count = 1;

            if (n_1thNode == 0)
            {
                return currentNode.next != null ? currentNode.next : null;
            }
            while (currentNode != null)
            {
                if (count == n_1thNode)
                {
                    //we are at nth node
                    if (currentNode.next != null)
                    {
                        currentNode.next = currentNode.next.next;
                    }
                    else
                    {
                        currentNode.next = null;
                    }
                }
                currentNode = currentNode.next;
                count++;
            }
            return head;
        }
        #endregion

        #region LeetCode Solution
        /// <summary>
        /// Using distance between two pointers
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd_LC(ListNode head, int n)
        {
            ListNode result = new ListNode(0, head);
            ListNode dummy = result;

            // move head to n postions
            for(int i=0; i<n; i++)
            {
                head = head.next;
            }

            // move head and dummy till head becomes next
            // at this poisition our dummy will be at n-1 th position so we can remove the nth node
            while(head != null)
            {
                head = head.next;
                dummy = dummy.next;
            }

            //now our dummy is at n-1th position
            dummy.next = dummy.next.next;

            return result.next;
        }
        #endregion
    }
}
