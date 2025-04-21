/*
 * You are given the heads of two sorted linked lists list1 and list2.
 * Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.
 * Return the head of the merged linked list.
 * 
 * Example 1:
 * Input: list1 = [1,2,4], list2 = [1,3,4]
 * Output: [1,1,2,3,4,4]
 * 
 * Example 2:
 * Input: list1 = [], list2 = []
 * Output: []
 * 
 * Example 3:
 * Input: list1 = [], list2 = [0]
 * Output: [0]
 * 
 * Constraints:
 * The number of nodes in both lists is in the range [0, 50].
 * -100 <= Node.val <= 100
 * Both list1 and list2 are sorted in non-decreasing order.
 */

namespace PreperationsTest.LeetCode.Easy.LinkedLists
{
    [TestClass]
    public class _21_MergeTwoSortedLists
    {
        [TestMethod]
        public void Runt()
        {

            ListNode node4 = new ListNode(4);
            ListNode node2 = new ListNode(2, node4);
            ListNode node1 = new ListNode(1, node2);

            ListNode node5 = new ListNode(5);
            ListNode node3 = new ListNode(3, node5);
            ListNode node11 = new ListNode(1, node3);

            ListNode result = MergeTwoLists(node1, node11);
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
        /// Adding two sorted lists
        /// TC - O(M+N), where m and n are the total nodes in lists1 and list2
        /// SC - O(M+N)
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode result = new ListNode();
            ListNode resultHead = result;

            while (list1 != null && list2 != null)
            {
                ListNode curr = new ListNode();
                if (list1.val <= list2.val)
                {
                    curr.val = list1.val;
                    list1 = list1.next;
                }
                else
                {
                    curr.val = list2.val;
                    list2 = list2.next;
                }
                result.next = curr;
                result = result.next;
            }

            // append list1 remaining nodes
            if (list1 != null)
            {
                result.next = list1;
            }

            // append list2 remaining nodes
            if (list2 != null)
            {
                result.next = list2;
            }

            return resultHead.next;
        }
    }
}
