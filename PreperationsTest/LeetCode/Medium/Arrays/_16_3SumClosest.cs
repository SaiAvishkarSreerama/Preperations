/*
 * Given an integer array nums of length n and an integer target, find three integers in nums such that the sum is closest to target.
 * Return the sum of the three integers.
 * You may assume that each input would have exactly one solution.
 * 
 * Example 1:
 * Input: nums = [-1,2,1,-4], target = 1
 * Output: 2
 * Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
 * 
 * Example 2:
 * Input: nums = [0,0,0], target = 1
 * Output: 0
 * Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).
 * 
 * Constraints:
 * 3 <= nums.length <= 500
 * -1000 <= nums[i] <= 1000
 * -104 <= target <= 104
*/

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _16_3SumClosest
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { -1, 1, 2, -4 };
            int ans = ThreeSumClosest(nums, 1);
        }

        /// <summary>
        /// TC - O(nlogn) for sorting + O(n2) for iterating all values of array in nested loops => O(n^2)
        /// SC - O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            int closestSum = nums[0] + nums[1] + nums[2];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                int l = i + 1;
                int r = nums.Length - 1;
                while (l < r)
                {
                    int sum = (nums[i] + nums[l] + nums[r]);
                    int currentDistance = sum - target; // current distance
                    int previousDistance = closestSum - target; // previous distance
                    if (Math.Abs(currentDistance) < Math.Abs(previousDistance))
                    {
                        closestSum = sum;
                    }
                    if (sum < target)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }

            return closestSum;
        }
    }
}
