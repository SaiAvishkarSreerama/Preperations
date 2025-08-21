/*
*  Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
* Example 1:
* Input: nums = [1,1,1,2,2,3], k = 2
* Output: [1,2]
* 
* Example 2:
* Input: nums = [1], k = 1
* Output: [1]
* 
* Constraints:
* 1 <= nums.length <= 105
* -104 <= nums[i] <= 104
* k is in the range [1, the number of unique elements in the array].
* It is guaranteed that the answer is unique.
* */

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _347_TopKFrequentElements
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = [1, 1, 1, 2, 2, 3];
            int k = 2;
            TopKFrequent(nums, k);
        }

        /// <summary>
        /// TC - O(N logk)
        /// SC - O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent(int[] nums, int k)
        {
            // edge case
            if (nums.Length == k)
            {
                return nums;
            }
            // Algo:
            // TC - O(n);
            // step1: count the num and its frequency in a dictionary
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!frequency.ContainsKey(nums[i]))
                {
                    frequency.Add(nums[i], 0);
                }
                frequency[nums[i]]++;
            }

            //step 2: create a Heap/priorityQueue to keep top k elements only
            // TC - O(N logk)
            PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
            foreach (var pair in frequency)
            {
                heap.Enqueue(pair.Key, pair.Value);
                if (heap.Count > k)
                {
                    heap.Dequeue();
                }
            }

            // step3: collect the k elements from the heap and return the restult
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = heap.Dequeue();
            }

            return result;
        }
    }
}
