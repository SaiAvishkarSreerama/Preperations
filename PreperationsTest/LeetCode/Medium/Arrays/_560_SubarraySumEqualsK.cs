//https://www.youtube.com/watch?v=fFVZt-6sgyo&ab_channel=NeetCode
/*
 * Given an array of integers nums and an integer k, return the total number of subarrays whose sum equals to k.
 * A subarray is a contiguous non-empty sequence of elements within an array.
 * 
 * Example 1:
 * Input: nums = [1,1,1], k = 2
 * Output: 2
 * 
 * Example 2:
 * Input: nums = [1,2,3], k = 3
 * Output: 2
 * 
 * Constraints:
 * 1 <= nums.length <= 2 * 104
 * -1000 <= nums[i] <= 1000
 * -107 <= k <= 107
 */

// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _560_SubarraySumEqualsK
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 1, -1, 0 };
            int k = 0;
            int count = SubarraySum(nums, k);
        }

        /// <summary>
        /// Algo:
        ///  x. when we add num one by one(sum), we check if the sum at that position matches to k, if removing any prefix nums can still give us k?
        ///  x. let say we have 1 -1 1 1 and k=2, if removing 1(0 index) from total still gives us 2, removin 1 -1(0 & 1 indexes) also gives us 2. so we hunt for prefix that we seen before or not
        ///  TC - O(n)
        ///  SC - O(n)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraySum(int[] nums, int k)
        {
            int count = 0;
            int sum = 0;

            // hashmap to store the sum and its frequency
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict[0] = 1; // means sum-0 appears 1 time

            foreach (int num in nums)
            {
                sum += num;
                // base case: if we have already seen prefixSum ('sum-k') before, so we have the count, add that count from dict to our count
                int prefixSum = sum - k;
                if (dict.ContainsKey(prefixSum))
                {
                    count += dict[prefixSum];
                }
                // we keep note of every sum, so that it could be a prefixSum for another subarray
                if (!dict.ContainsKey(sum))
                {
                    dict[sum] = 0;
                }
                dict[sum]++;
            }
            return count;
        }
    }
}
