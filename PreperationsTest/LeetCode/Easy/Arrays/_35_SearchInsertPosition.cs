/*
 * Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
 * You must write an algorithm with O(log n) runtime complexity.
 * 
 * Example 1:
 * Input: nums = [1,3,5,6], target = 5
 * Output: 2
 * 
 * Example 2:
 * Input: nums = [1,3,5,6], target = 2
 * Output: 1
 * 
 * Example 3:
 * Input: nums = [1,3,5,6], target = 7
 * Output: 4
 * 
 * Constraints:
 * 1 <= nums.length <= 104
 * -104 <= nums[i] <= 104
 * nums contains distinct values sorted in ascending order.
 * -104 <= target <= 104
 * 
 * TC - O(log N), Binary search
 * SC - O(1), inplace
 */

namespace PreperationsTest.LeetCode.Easy.Arrays
{
    [TestClass]
    public class _35_SearchInsertPosition
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 1, 3, 5, 6 };
            SearchInsert(nums, 2);
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int low = 0;
            int high = nums.Length - 1;

            // Binary search for the element
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                // if the target matches with mid index, return it
                if (target == nums[mid])
                {
                    return mid;
                }
                // target is smaller than mid num, means move left
                else if (target < nums[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    // else move right
                    low = mid + 1;
                }
            }

            // let say we dont find the num in the given array
            // our low moved to a place where next num is next to the target element, means we are at target position
            return low;
        }
    }
}
