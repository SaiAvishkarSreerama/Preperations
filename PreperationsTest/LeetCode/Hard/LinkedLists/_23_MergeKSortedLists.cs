/*
 * You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
 * Merge all the linked-lists into one sorted linked-list and return it.
 * 
 * Example 1:
 * Input: lists = [[1,4,5],[1,3,4],[2,6]]
 * Output: [1,1,2,3,4,4,5,6]
 * Explanation: The linked-lists are:
 * [
 *   1->4->5,
 *   1->3->4,
 *   2->6
 * ]
 * merging them into one sorted list:
 * 1->1->2->3->4->4->5->6
 * 
 * Example 2:
 * Input: lists = []
 * Output: []
 * 
 * Example 3:
 * Input: lists = [[]]
 * Output: []
 * 
 * Constraints:
 * k == lists.length
 * 0 <= k <= 104
 * 0 <= lists[i].length <= 500
 * -104 <= lists[i][j] <= 104
 * lists[i] is sorted in ascending order.
 * The sum of lists[i].length will not exceed 104.
 */

using System.ComponentModel.Design;

namespace PreperationsTest.LeetCode.Hard.LinkedLists
{
    [TestClass]
    public class _23_MergeKSortedLists
    {
        [TestMethod]
        public void Run()
        {
            ListNode node9 = new ListNode(9);
            ListNode node5 = new ListNode(5, node9);
            ListNode node4 = new ListNode(4, node5);
            ListNode node7 = new ListNode(7, node4);

            ListNode node41 = new ListNode(4);
            ListNode node3 = new ListNode(3, node41);
            ListNode node11 = new ListNode(11, node3);

            ListNode node6 = new ListNode(6);
            ListNode node12 = new ListNode(12, node6);
            ListNode node2 = new ListNode(2, node12);
            MergeKLists([node7, node11, node2]);
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

        #region Using MinHeap
        /*
         *  Not recommended using minHeap in sorted lists scenario as they are already sorted and we can directly recursively merge (divide-conquer) them using merge sort technique
         *  Using minHeap , TC - O( N logk), N-number of elemnts in all lists, k number of lists
         *                  SC - O(N)
         * But for using merge, we can do it inplace memory and SC - O(1) and time taken will be same O(N logk)
         *         
         */
        public class minHeap
        {
            public List<int> heap = new List<int>();
            public int size = -1;

            public int ParentIndex(int i)
            {
                return (i - 1) / 2;
            }

            public int LeftChildIndex(int i)
            {
                return (2 * i + 1);
            }

            public int RightChildIndex(int i)
            {
                return (2 * i + 2);
            }

            public void Insert(int value)
            {
                size++;
                heap.Add(value);

                Heapify_shiftUp(size);
            }

            public int ExtractMin()
            {
                int topOne = heap[0];
                heap[0] = heap[size];

                Heapify_shiftDown(0);
                size--;

                return topOne;
            }

            public void Heapify_shiftUp(int size)
            {
                while (size > 0 && heap[size] < heap[ParentIndex(size)])
                {
                    int parentIndex = ParentIndex(size);
                    Swap(size, parentIndex);
                    size = parentIndex;
                }
            }

            public void Heapify_shiftDown(int i)
            {
                int currentIndex = i;
                int leftChildIndex = LeftChildIndex(i);
                if (leftChildIndex <= size && heap[leftChildIndex] < heap[currentIndex])
                {
                    currentIndex = leftChildIndex;
                }
                int rightChildIndex = RightChildIndex(i);
                if (rightChildIndex <= size && heap[rightChildIndex] < heap[currentIndex])
                {
                    currentIndex = rightChildIndex;
                }
                if (i != currentIndex)
                {
                    Swap(currentIndex, i);
                    Heapify_shiftDown(currentIndex);
                }
            }

            public void Swap(int i, int j)
            {
                int temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }

        }

        public ListNode MergeKLists1(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            minHeap heap = new minHeap();

            foreach (ListNode list in lists)
            {
                ListNode head = list;
                while (head != null)
                {
                    heap.Insert(head.val);
                    head = head.next;
                }
            }

            // taking lists[0] will cover [[]] case
            ListNode result = lists[0];
            if (heap.size > -1)
            {
                result = new ListNode();
            }
            ListNode curr = result;
            while (heap.size >= 0)
            {

                curr.val = heap.ExtractMin();
                if (heap.size >= 0)
                {
                    curr.next = new ListNode();
                    curr = curr.next;
                }
            }

            return result;
        }

        #endregion

        #region Divide-and-Conquer (Highly recommended)
        /*
         * TC: Divide and conquer - O(log k), merging - O(n), total O(n logk)
         * SC - O(n + logk), no extra space is used, input list is used. But the recursion of merging lists takes up to N recursions O(N)
         */
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            return Merge(lists, 0, lists.Length - 1);
        }

        /// <summary>
        /// Divide and conquer 
        /// dividing to single lists and merging two each, as merge sort
        /// </summary>
        /// <param name="lists"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public ListNode Merge(ListNode[] lists, int low, int high)
        {
            if (low == high)
            {
                return (lists[low]);
            }

            int mid = (low + high) / 2;
            ListNode list1 = Merge(lists, low, mid);
            ListNode list2 = Merge(lists, mid + 1, high);

            return MergeTwoLists_Recursion(list1, list2);
        }

        /// <summary>
        /// Return the merged sorted list
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists_Recursion(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }

            if (list2 == null)
            {
                return list1;
            }

            if (list1.val <= list2.val)
            {
                list1.next = MergeTwoLists_Recursion(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists_Recursion(list1, list2.next);
                return list2;
            }
        }

        /// <summary>
        /// SC - O(1) extra sapce, O(logk) for merged k lists
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists_Iteration(ListNode list1, ListNode list2)
        {
            if (list1 == null)
            {
                return list2;
            }

            if (list2 == null)
            {
                return list1;
            }
            ListNode result = new ListNode();
            ListNode curr = result;

            while(list1 != null && list2 != null){
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
                curr = curr.next;
            }

            if(list1 != null)
            {
                curr.next = list1;
            }

            if (list2 != null)
            {
                curr.next = list2;
            }
            return result;
        }
        #endregion
    }
}
