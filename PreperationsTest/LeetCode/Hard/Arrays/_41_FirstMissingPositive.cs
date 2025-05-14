/*
 * Given an unsorted integer array nums. Return the smallest positive integer that is not present in nums.
 * ***************You must implement an algorithm that runs in O(n) time and uses O(1) auxiliary space.**************
 * Example 1:
 * Input: nums = [1,2,0]
 * Output: 3
 * Explanation: The numbers in the range [1,2] are all in the array.
 * 
 * Example 2:
 * Input: nums = [3,4,-1,1]
 * Output: 2
 * Explanation: 1 is in the array but 2 is missing.
 * 
 * Example 3:
 * Input: nums = [7,8,9,11,12]
 * Output: 1
 * Explanation: The smallest positive integer 1 is missing.
 *  
 * Constraints:
 * 1 <= nums.length <= 105
 * -231 <= nums[i] <= 231 - 1
 * */

namespace PreperationsTest.LeetCode.Hard.Arrays
{
    [TestClass]
    public class _41_FirstMissingPositive
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 1, 2, -3, -4, 1 };
            FirstMissingPositive(nums);
        }

        /// <summary>
        /// Using the same given input
        /// Explanation:
        ///     1. First pass: update <0, 0, >n to 1's and note if we seen 1, if not return 1;
        ///     2. Second pass: update the index to -ve for every seen num, num[3] = 5, then make nums[5] -ve
        ///     3. Third pass: if seen positve return that index, if nums[4] is +ve, means we dont have 4 in the array,so answer is 4
        ///     4. Edge case, we are not checking 0th index, as we convert 0 to 1, then use this space if store 'n' as we are not converting n to 1, only doing >n to 1, store it at 0 and simply return if nums[0] is positive
        ///         only after validating third pass...
        /// TC - O(n)
        /// SC - O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            // Check if 1 exists, and update Negatives and >nums.Length to 1
            // we know for n numbers, nothng is missing, we get n as max, if not means there is a missing before n, we dont need n+1 numbers
            int n = nums.Length;
            bool contains1 = false;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 1)
                {
                    contains1 = true;
                }
                else if (nums[i] <= 0 || nums[i] > n)
                {
                    nums[i] = 1;
                }
            }

            // not seen 1? our ans is 1 then..
            if (!contains1)
            {
                return 1;
            }

            // Now we have all +ve integers from 1 to n
            // Second pass, update the index of the number that we seen to negative,
            // any number we get positive in third pass, means that index num is not seen
            // ex: nums[i] = 3, then update nums[3] to -ve, in third pass, when we see index-3 is -ve means we have num 3 in array
            for (int i = 0; i < n; i++)
            {
                int value = Math.Abs(nums[i]); // get the +ve of the num
                if (value == n)
                { 
                    // we dont deal with 0 space, so use it to store n number, as we got from 1 to n-1
                    // if this is still +ve at the end and we dont find any +ve from 1 to n, we can say we have 1 to n-1, so next positve num is n
                    nums[0] = -Math.Abs(nums[0]);
                }
                else
                {
                    nums[value] = -Math.Abs(nums[value]);
                }
            }

            // Now we have all seen nums as -ve in their index 
            // the first index that we see positve,means we dont have that num
            // we dont have 0 in the list as we converted it to 1, so 0th index is always a positive, so check from index-1
            for (int i = 1; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    return i;
                }
            }

            // nums[0] stores whether n is in nums
            // if n[0] +ve means we have all nums from 1 to n
            if (nums[0] > 0)
            {
                return n;
            }

            return n + 1;
        }

        /// <summary>
        /// TC - O(n) 
        /// SC - O(n) 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive_UsedNSpace(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
                set.Add(nums[i]);
            }

            for (int i = 1; i <= max; i++)
            {
                if (!set.Contains(i))
                {
                    return i;
                }
            }

            return max < 0 ? 1 : max + 1;
        }
    }
}
