/* Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
 * If target is not found in the array, return [-1, -1].
 * You must write an algorithm with O(log n) runtime complexity.
 * 
 * Example 1:
 * Input: nums = [5,7,7,8,8,10], target = 8
 * Output: [3,4]
 * 
 * Example 2:
 * Input: nums = [5,7,7,8,8,10], target = 6
 * Output: [-1,-1]
 * 
 * Example 3:
 * Input: nums = [], target = 0
 * Output: [-1,-1]
*/

namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _34_FindFirstAndLastPositionOfElementInSortedArray
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = { 2, 2 };
            SearchRange(nums, 2);
        }

        /// <summary>
        /// Binary Search
        /// TC - O (LogN)
        /// SC - O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] SearchRange(int[] nums, int target)
        {
            int[] result = new int[] { -1, -1 };
            if (nums == null || nums.Length == 0)
            {
                return result;
            }

            int low = 0;
            int high = nums.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                // If mid is target, then check if the same num are repeated in front of it and after
                if (nums[mid] == target)
                {
                    int first = mid, last = mid;
                    // if our previous num also same as target, move back till we see diff num
                    while (first > low && nums[first] == target)
                        first--;
                    // if our next num also same as target, move next till we see diff num
                    while (last < high && nums[last] == target)
                        last++;

                    // Now we have first and last occurances of the target
                    result[0] = first;
                    result[1] = last;

                    // break the loop here, otehrwise, low=mid+1 and we loose this result
                    break;
                }

                if (nums[mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
