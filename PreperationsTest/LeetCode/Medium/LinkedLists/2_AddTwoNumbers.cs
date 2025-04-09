/*
* TC - O(N) => O(max(l1 ,l2)) 
* SC - O(N), 
* 
* You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. 
* Add the two numbers and return the sum as a linked list.
* You may assume the two numbers do not contain any leading zero, except the number 0 itself.
* 
* Example 1:
* Input: l1 = [2,4,3], l2 = [5,6,4]
* Output: [7,0,8]
* Explanation: 342 + 465 = 807.
* 
* Example 2:
* Input: l1 = [0], l2 = [0]
* Output: [0]
* 
* Example 3: 
* Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
* Output: [8,9,9,9,0,0,0,1]
*/

namespace PreperationsTest.LeetCode.Medium.LinkedLists
{
    [TestClass]
    public class _2_AddTwoNumbers
    {
        [TestMethod]
        public void Run()
        {
            ListNode node3 = new ListNode(3);
            ListNode node2 = new ListNode(4, node3);
            ListNode l1 = new ListNode(2, node2);

            ListNode node4 = new ListNode(4);
            ListNode node6 = new ListNode(6, node4);
            ListNode l2 = new ListNode(5, node6);

            ListNode result = AddTwoNumbers(l1, l2);
            ListNode result1 = AddTwoNumbers_SolFromLeetCode(l1, l2);
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Listnode to return
            ListNode resultHead = new ListNode(0);

            // result node to add the iteration sum
            ListNode result = resultHead;

            // to carry the ieration sum carry
            int carry = 0;
            ListNode currL1 = l1;
            ListNode currL2 = l2;

            // Iterate while l1 or l2 or carry are not empty
            while (currL1 != null || currL2 != null || carry != 0)
            {
                int l1_Val = 0;
                int l2_Val = 0;
                if (currL1 != null)
                {
                    l1_Val = currL1.val;
                    currL1 = currL1.next;
                }

                if (currL2 != null)
                {
                    l2_Val = currL2.val;
                    currL2 = currL2.next;
                }

                int sum = l1_Val + l2_Val + carry;
                carry = 0;

                // sum > 9 mean it has two digits, 'carry(Tens) sum(ones)'
                if (sum > 9)
                {
                    carry = (sum / 10) % 10;
                    sum = sum % 10;
                }

                // Create new node for the sum and add it to the result, and move result to next
                ListNode currResult = new ListNode(sum);
                result.next = currResult;
                result = result.next;
            }

            return resultHead.next;
        }

        /// <summary>
        /// which utilises the input listnodes without creating any variables. 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers_SolFromLeetCode(ListNode l1, ListNode l2)
        {
            ListNode result = l1;

            while (l2 != null)
            {
                l1.val += l2.val;

                if (l1.val > 9)
                {
                    if(l1.next == null)
                    {
                        l1.next = new ListNode();
                    }
                    l1.next.val += 1;
                    l1.val = l1.val % 10;
                }

                if(l1.next == null && l2.next != null)
                {
                    l1.next = new ListNode();
                }
                if (l1.next != null)
                {
                    l1 = l1.next;
                }
                l2 = l2.next;
            }

            while (l1.val > 9)
            {
                if(l1.next == null)
                {
                    l1.next = new ListNode();
                }
                l1.next.val += 1;
                l1.val = l1.val % 10;
                l1 = l1.next;
            }

            return result;
        }
    }
}
