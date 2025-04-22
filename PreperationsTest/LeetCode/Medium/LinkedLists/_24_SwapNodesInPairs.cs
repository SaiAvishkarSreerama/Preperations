/*
 * Given a linked list, swap every two adjacent nodes and return its head. You must solve the problem without modifying the values in the list's nodes (i.e., only nodes themselves may be changed.)
 * 
 * Example 1:
 * Input: head = [1,2,3,4]
 * Output: [2,1,4,3]
 * 
 * Example 2:
 * Input: head = []
 * Output: []
 * 
 * Example 3:
 * Input: head = [1]
 * Output: [1]
 * 
 * Example 4:
 * Input: head = [1,2,3]
 * Output: [2,1,3]
 * 
 * Constraints:
 * The number of nodes in the list is in the range [0, 100].
 * 0 <= Node.val <= 100
 * */
namespace PreperationsTest.LeetCode.Medium.LinkedLists
{
    [TestClass]
    public class _24_SwapNodesInPairs
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
            SwapPairs(node1);
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
        /// Explanation:
        ///   1. (1)-->(2)-->(3)-->(4)
        ///   2. head(1) && temp(2)
        ///   3. temp.next == head => (2)-->(1) && head.next = {swap rem (3)-->(4)}, where 3 is our intial temp.next
        ///   4. Sqp 3 & 4 gives back (4)-->(3)
        ///   5. #3 returning temp (2)-->(1)-->(4)-->(3)
        ///   
        /// TC - O(n), traversing all nodes once
        /// SC - O(1), no extra space is used
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode SwapPairs(ListNode head)
        {
            // if no nodes or 1 node return the input as is
            if(head == null || head.next == null)
            {
                return head;
            }

            // head is first node, temp is 2nd node
            // take 2nd node
            ListNode temp = head.next;

            // recurse for remaining node
            // we get back swapped nodes (8)-(7), (6)-->(5), (4)-->(3)
            head.next = SwapPairs(temp.next);

            // swapping here
            // (2)-->(1)
            temp.next = head;

            //return (2)-->(1)
            return temp;
        }
    }
}
