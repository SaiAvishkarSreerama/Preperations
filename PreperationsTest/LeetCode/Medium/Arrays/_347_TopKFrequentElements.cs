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

// Companies: @Meta
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
            TopKFrequent_buckets(nums, k);
        }

        #region Using PriorityQueue/Heap
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
        #endregion

        #region Using Buckets logic
        /// <summary>
        /// Algo:
        /// 1. Get min and max numbers
        /// 2. Prepare the frequencies of num, in a freq array, index starts from 0 (is our min num => foreach num-min gives its index from 0)
        /// 3. Prepare buckets, each bucket is a frequency, that hold all numbers that has the frequecny
        /// 4. iterate from last bucket with high frequecny, collect the top k numbers from the bucket as result
        /// TC - O(N)
        /// SC - O(N)
        /// But the priorityqueueu approach is better, as here we prepare the frequency array of lenght min-max+1, if our min is -1000, max is 1000, we will have array of 2001 length, which is huge
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] TopKFrequent_buckets(int[] nums, int k)
        {
            //base case
            if (nums.Length == 0 || k <= 0)
            {
                return new int[0];
            }

            if (nums.Length == k)
            {
                return nums;
            }

            // Step1: get min and max
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (int num in nums)
            {
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            // step2: create the frequencies of the numbers
            int[] frequencies = new int[max - min + 1];
            int maxFreq = 0;
            foreach (int num in nums)
            {
                frequencies[num - min]++;
                maxFreq = Math.Max(maxFreq, frequencies[num - min]);
            }

            //Step3: create buckets with frequencies and add the real nums to its freq buckets
            List<List<int>> buckets = new List<List<int>>();
            for (int i = 0; i <= maxFreq; i++)
            {
                buckets.Add(new List<int>());
            }
            for (int i = min; i <= max; i++)
            {
                int freqIndex = frequencies[i - min]; ; // we get the frequencies index of that num ex:num=-10, min=-10, index = num-min = 0
                buckets[freqIndex].Add(i); // put the num -10 in its freq bucket
            }


            // Step 4: Collect top k frequent elements from highest frequency down
            List<int> result = new List<int>();
            for (int i = buckets.Count - 1; i > 0 && result.Count < k; i--) // Skip bucket[0]
            {
                foreach (int num in buckets[i])
                {
                    result.Add(num);
                    if (result.Count == k)
                        break;
                }
            }

            return result.ToArray();
        }

        #endregion
    }
}
