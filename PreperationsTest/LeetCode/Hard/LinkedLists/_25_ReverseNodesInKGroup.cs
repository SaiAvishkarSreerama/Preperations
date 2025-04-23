/*
 *  Given the head of a linked list, reverse the nodes of the list k at a time, and return the modified list.
 * k is a positive integer and is less than or equal to the length of the linked list. If the number of nodes is not a multiple of k then left-out nodes, in the end, should remain as it is.
 * You may not alter the values in the list's nodes, only nodes themselves may be changed.
 * 
 * Input: head = [1,2,3,4,5], k = 2
 * Output: [2,1,4,3,5]
 * 
 * Constraints:
 * The number of nodes in the list is n.
 * 1 <= k <= n <= 5000
 * 0 <= Node.val <= 1000
 * 
 * Follow-up: Can you solve the problem in O(1) extra memory space? -- Inplace reversal
 * Brute-Force: Get a new Listnode and iterate from head to k nodes and add each to the new head and return new head, it takes O(N) space for the new node
 *  */
namespace PreperationsTest.LeetCode.Hard.LinkedLists
{
    [TestClass]
    public class _25_ReverseNodesInKGroup
    {
        [TestMethod]
        public void Run()
        {
            ListNode node8 = new ListNode(8);
            ListNode node7 = new ListNode(7, node8);
            ListNode node6 = new ListNode(6, node7);
            ListNode node5 = new ListNode(5, node6);
            ListNode node4 = new ListNode(4, node5);
            ListNode node3 = new ListNode(3, node4);
            ListNode node2 = new ListNode(2, node3);
            ListNode node1 = new ListNode(1, node2);
            ReverseKGroup(node1, 3);
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
        /// <summary>
        /// Explanation: we need to check three conditions
        ///     1. If head is null or k=1 the nothing to do
        ///     2. If nodes are less than k, do nothing, in both cases return head as is
        ///     3. If nodes<k, then recursively reverse the knodes each time.
        ///         i. If all nodes reversed and any rem nodes are less than k, then they come as is
        ///         
        /// TC: O(N), traversing each node once
        /// SC: O(1), no extrac space is used and reversing the nodes inplace
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null || k <= 1)
            {
                return head;
            }

            // Check if nodes are less than K then 
            int count = 0;
            ListNode current = head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            if (count < k)
            {
                return head;
            }


            // THIS IS THE LOGIC TO REVERSE THE NODES IN A GROUP
            // simlar to reverseInPairs, where head-->temp are reversed as temp-->head-->(recursive), here prev-->current-->head-->(recursive)
            ListNode prev = null;
            ListNode Next = null;
            current = head;
            for (int i = 0; i < k; i++)
            {
                // Get the next value to traverse
                // For (1)-->(2)-->(3), curr-(2), next-(3)
                Next = current.next;

                // This adds the prev seen node to next (1)-->(2)-->(3),
                // let say curr-2, prev-1, (2)-->(1)
                current.next = prev;
                prev = current;

                // traverse to next value for next iteration
                // curr = (3)-->(4)-->....->
                current = Next;
            }

            // Recursive call to do the same for remaining k-Groups
            // since our head is (1), now after 1st reverse (3)-->(2)-->(1)=head, current=(3)-->(4)-->....
            // we need to find the head.next values 
            head.next = ReverseKGroup(current, k);

            // 'prev' is now the new head of this group
            return prev;

        }
    }
}
