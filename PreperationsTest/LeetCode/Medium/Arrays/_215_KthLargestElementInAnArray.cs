using PreperationsTest.LeetCode.Easy.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreperationsTest.LeetCode.Medium.Arrays
{
     [TestClass]
    public class _215_KthLargestElementInAnArray
    {
        [TestMethod]
        public void Run()
        {
            int[] nums1 = [3, 2, 1, 4];
            FindKthLargest_Heap(nums1, 2);
            FindKthLargest_QuickSelect(nums1, 2);
        }


        #region Approach 1 : Using Dictionary - TIME LIMIT EXCEEDED FOR HUGE SET
        // TC - O(n logu), n no of elements in an array, u-no of unique elements
        // SC - O(u)
        public int FindKthLargest_Dict(int[] nums, int k)
        {
            // to store the num and frequency
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    map[nums[i]]++;
                }
                else
                {
                    map.Add(nums[i], 1);
                }
            }

            foreach (var key in map.Keys.Reverse())
            {
                int freq = map[key];
                if (k <= freq)
                {
                    return key;
                }
                k -= freq;
            }

            return -1;
        }
        #endregion

        #region Approach 2: Using MaxHeap (Implementing Priority Queue)
        public int[] heap { get; set; }
        int size = -1;
        public int FindKthLargest_Heap(int[] nums, int k)
        {
            heap = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                Insert(nums[i]);
            }

            return Remove(k);
        }

        // Insert into the heap
        public void Insert(int n)
        {
            size++;
            heap[size] = n;
            ShiftUp_Heapify(size);
        }

        // heapify, adjust the max value to top
        public void ShiftUp_Heapify(int index)
        {
            while (size > 0 && heap[index] > heap[ParentIndex(index)])
            {
                int parentIndex = ParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }

        // Get hierarcy indexs of current index
        public int ParentIndex(int index) { return (index - 1) / 2;}
        public int LeftChildIndex(int index) { return 2 * index + 1; }
        public int RightChildIndex(int index) { return 2 * index + 2; }

        // Swap parent and child values
        public void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        // Remove the kth max item
        public int Remove(int k)
        {
            while ( k > 1)
            {
                int getMax = heap[0];
                heap[0] = heap[size];
                size--;
                k--;
                ShiftDown_Heapify(0);
            }
            return heap[0];
        }

        // Heapify, adjusts the top replaced leaf value to its position
        public void ShiftDown_Heapify(int currIndex)
        {
            int maxIndex = currIndex;
            int left = LeftChildIndex(maxIndex);
            if (currIndex <= size && left <= size && heap[left] > heap[maxIndex])
            {
                maxIndex = left;
            }
            int right = RightChildIndex(maxIndex);
            if (currIndex <= size && right <= size && heap[right] > heap[maxIndex])
            {
                maxIndex = right;
            }

            if(currIndex != maxIndex)
            {
                Swap(maxIndex, currIndex);

                // iterate untill the current index value sets in position
                ShiftDown_Heapify(maxIndex);
            }
        }
        #endregion

        #region Approach 2: Using inbuilt MinHeap (Priority Queue) directly
        // TC - O (nlogk), n elements, logk time to insert in heap, O(1) for peek the value
        // SC - O(k), to maintain the heap
        public int FindKthLargest(int[] nums, int k)
        {
            // Here we store only k elements, so the 1st element in heap willbe out kth largest
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                minHeap.Enqueue(nums[i], nums[i]);

                // while adding ele to min heap we are removing the smallest numbers after k
                // when size becomes 4, the next element we insert will be on top, this is not our k+1th ele, so we remove this and maintina kth on top 
                if(minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            // Now we have only the kth elem on top and then the highest num than kth in the minheap
            return minHeap.Peek();
        }
        #endregion

        #region Approach 3: Using QuickSelect (QUickSort concept)
        /// <summary>
        /// TC - 
        ///     O(n) - Average case, if random pivot is somehwere at middle.
        ///     O(n^2) - worst case, if random pivot is either small or large number, we reduce the nums of small/large by one element on each recursion due to end pivotal value
        /// SC - 
        ///     O(nlogn) - Average case, new lists of n elements(left+right+mid) on every recursion(logn)
        ///     O(n^2) - worst case, for pivotal smaller/larger
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthLargest_QuickSelect(int[] nums, int k)
        {
            return QuickSelect(nums.ToList(), k);
        }

        public int QuickSelect(List<int> nums, int k)
        {
            var random = new Random();
            int pivotalIndex = random.Next(nums.Count);
            int pivot = nums[pivotalIndex];

            // left stored larger number, mid- pivotal equal number, right - smaller numbers
            List<int> left = new List<int>();
            List<int> mid = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] > pivot)
                {
                    left.Add(nums[i]); // insert larger nums in left
                }
                else if (nums[i] < pivot)
                {
                    right.Add(nums[i]); // insert smaller nums in right
                }
                else
                {
                    mid.Add(nums[i]); // insert equal nums in mid
                }
            }

            // if k is less than left, means we have bigger nums in left and k is with in its range 
            if (k <= left.Count)
            {
                return QuickSelect(left, k);
            }

            // if k is greater then left+mid, means kth element is somewhere in right list, left+mid elements still cant beat the kth largest ele
            if (left.Count + mid.Count < k)
            {
                return QuickSelect(right, k - (left.Count + mid.Count));
            }

            return pivot;
        }
        #endregion
    }
}
