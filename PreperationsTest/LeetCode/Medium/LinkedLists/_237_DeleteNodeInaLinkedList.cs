/*
 * There is a singly-linked list head and we want to delete a node node in it.
 * You are given the node to be deleted node. You will not be given access to the first node of head.
 * All the values of the linked list are unique, and it is guaranteed that the given node node is not the last node in the linked list.
 * 
 * Delete the given node. Note that by deleting the node, we do not mean removing it from memory. We mean:
 * The value of the given node should not exist in the linked list.
 * The number of nodes in the linked list should decrease by one.
 * All the values before node should be in the same order.
 * All the values after node should be in the same order.
 * 
 * Custom testing:
 * For the input, you should provide the entire linked list head and the node to be given node. node should not be the last node of the list and should be an actual node in the list.
 * We will build the linked list and pass the node to your function.
 * The output will be the entire list after calling your function.
 *
 * Input: head = [4,5,1,9], node = 5
 * Output: [4,1,9]
 * Explanation: You are given the second node with value 5, the linked list should become 4 -> 1 -> 9 after calling your function.
 */

// Companies: @Meta @Google @Apple @Nvidia @Microsoft @Amazon
namespace PreperationsTest.LeetCode.Medium.LinkedLists
{
    [TestClass]
    public class _237_DeleteNodeInaLinkedList
    {
        //  Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        [TestMethod]
        public void Run()
        {
            ListNode node3 = new ListNode(3);
            ListNode node5 = new ListNode(5);
            ListNode node1 = new ListNode(1);
            ListNode node6 = new ListNode(6);
            ListNode node2 = new ListNode(2);
            ListNode node0 = new ListNode(0);
            ListNode node8 = new ListNode(8);
            ListNode node7 = new ListNode(7);
            ListNode node4 = new ListNode(4);

            // Connect nodes
            node3.next = node5;
            node5.next = node1;
            node1.next = node6;
            node6.next = node2;
            node2.next = node0;
            node0.next = node8;
            node8.next = node7;
            node7.next = node4;
            node4.next = null;

            // node to remove = node6
            // input: 3-5-1-6-2-0-8-7-4
            // output: 3-5-1-2-0-8-7-4
            DeleteNode(node6);
        }

        // We don't have access to head, we get only the node that we are removing
        // But, we can have all next nodes, so instead of doing node.prev = node.next for a doubly linked list
        // here we have single linked list, so copy the next to current node and change the next to next.next simple
        // TC - O(1)
        // SC - O(1)
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
