using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
* Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
* 
* Example:
* 
* Input:
* [
*   1->4->5,
*   1->3->4,
*   2->6
* ]
* Output: 1->1->2->3->4->4->5->6
* */
namespace AviPreperation.Data_Structures.LinkedLists
{
    /**
    * Definition for singly-linked list.
    * public class ListNode {
    *     public int val;
    *     public ListNode next;
    *     public ListNode(int x) { val = x; }
    * }
    */
    public class MergeKSortedListsSolution
    {
        //implementing minHeap
        SortedDictionary<int, Queue<ListNode>> map = new SortedDictionary<int, Queue<ListNode>>();

        //Add key=node.val and Value=node
        //Adding a Key-Value to Sorted Dictionay takes O(LogN)
        public void Add(int val, ListNode node)
        {
            if (!map.ContainsKey(val))
            {
                map.Add(val, new Queue<ListNode>());
            }
            map[val].Enqueue(node);
        }

        //Dequeue first key value and remove the key if empty
        //Removing a Key-Value to Sorted Dictionay takes O(LogN)
        public ListNode PopMin()
        {
            int key = map.First().Key;
            ListNode node = map[key].Dequeue();

            if (map[key].Count == 0)
                map.Remove(key);

            return node;
        }

        //Time complexity for iterating through the each node of the list gives  N + Adding + Removing
        //Time Complexity - O(N LogN)
        //Space complexity - O(N), using a sorted dictionary
        public ListNode MergeKLists(ListNode[] lists)
        {
            //Add lists to min heap
            foreach (var node in lists)
            {
                if (node == null)
                    continue;
                Add(node.val, node);
            }

            ListNode head = new ListNode(0);
            ListNode cur = head;
            while (map.Count > 0)
            {
                ListNode node = PopMin();

                if (node.next != null)
                    Add(node.next.val, node.next);

                cur.next = new ListNode(node.val);
                cur = cur.next;
            }

            return head.next;
        }
    }


    /******************************************USING MERGE SORT*****************************************************/
    public class MergeKSortedListsSolution2
    {
     
        //This one to implement the merge sort**************************************
        public ListNode MergeKLists2(ListNode[] lists)
        {

            return MergeKListsHelper(lists, 0, lists.Length - 1);
        }

        private ListNode MergeKListsHelper(ListNode[] lists, int low, int high)
        {
            if (low > high) return null;
            if (low == high) return lists[low];

            var mid = (high - low) / 2 + low;
            var left = MergeKListsHelper(lists, low, mid);
            var right = MergeKListsHelper(lists, mid + 1, high);

            return Merge2List(left, right);
        }
        /**************************************************************************/
                                            //OR
        /**************************************************************************/
        //Other approach t implement the merge sort*************************************
        public ListNode MergeKLists3(ListNode[] lists)
        {
            int len = lists.Length;

            if (len == 0)
            {
                return null;
            }
            else if (len == 1)
            {
                return lists[0];
            }

            // use divide and conqour idea
            int interval = 1;
            while (interval < len)
            {
                for (int i = 0; i < len - interval; i += interval * 2)
                {
                    lists[i] = this.Merge2List(lists[i], lists[i + interval]);
                }
                interval *= 2;
            }

            return lists[0];
        }

        private ListNode Merge2List(ListNode left, ListNode right)
        {
            if (left == null) return right;
            if (right == null) return left;
            var fakehead = new ListNode(-1);
            var start = fakehead;
            while (left != null && right != null)
            {
                if (left.val < right.val)
                {
                    start.next = left;
                    start = start.next;

                    left = left.next;
                }
                else
                {
                    start.next = right;
                    start = start.next;

                    right = right.next;
                }
            }

            if (left != null)
            {
                start.next = left;
            }
            if (right != null)
            {
                start.next = right;
            }

            return fakehead.next;
        }
    }
}
