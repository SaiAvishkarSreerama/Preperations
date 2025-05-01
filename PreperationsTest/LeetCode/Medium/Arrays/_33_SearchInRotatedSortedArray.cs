/*
 * There is an integer array nums sorted in ascending order (with distinct values).
 * Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
 * Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
 * You must write an algorithm with O(log n) runtime complexity.
 * 
 * Example 1:
 * Input: nums = [4,5,6,7,0,1,2], target = 0
 * Output: 4
 * 
 * Example 2:
 * Input: nums = [4,5,6,7,0,1,2], target = 3
 * Output: -1
 * 
 * Example 3:
 * Input: nums = [1], target = 0
 * Output: -1
 * 
 * Constraints:
 * 1 <= nums.length <= 5000
 * -104 <= nums[i] <= 104
 * All values of nums are unique.
 * nums is an ascending array that is possibly rotated.
 * -104 <= target <= 104
 */

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _33_SearchInRotatedSortedArray
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 4, 5, 6, 7, 0, 1, 2 };
            Search(nums, 0);
        }

        /// <summary>
        /// Binary Search
        /// TC - O (LogN)
        /// SC - O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = nums.Length - 1;// (low + high) /2

            while (low <= high)
            {
                // Base case
                int mid = low - (low - high) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                // Check if the left side is sorted
                if (nums[low] <= nums[mid])
                {
                    //check if the target is in left
                    if (nums[low] <= target && target < nums[mid])
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        // even though left is sorted, but our target is not there, so move to right part
                        low = mid + 1;
                    }
                }
                // else right is sorted
                if (nums[mid] <= nums[high])
                {
                    //check if the target is in left
                    if (nums[mid] < target && target <= nums[high])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        // even though right is sorted, but our target is not there, so move to left part
                        high = mid - 1;
                    }
                }
            }
            return -1;
        }
    }
}