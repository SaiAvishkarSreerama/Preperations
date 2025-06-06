/*
 * A peak element is an element that is strictly greater than its neighbors.
 * Given a 0-indexed integer array nums, find a peak element, and return its index. If the array contains multiple peaks, return the index to any of the peaks.
 * You may imagine that nums[-1] = nums[n] = -∞. In other words, an element is always considered to be strictly greater than a neighbor that is outside the array.
 * You must write an algorithm that runs in O(log n) time.
 * 
 * Example 1:
 * Input: nums = [1,2,3,1]
 * Output: 2
 * Explanation: 3 is a peak element and your function should return the index number 2.
 * 
 * Example 2:
 * Input: nums = [1,2,1,3,5,6,4]
 * Output: 5
 * Explanation: Your function can return either index number 1 where the peak element is 2, or index number 5 where the peak element is 6.
 * 
 * Constraints:
 * 1 <= nums.length <= 1000
 * -231 <= nums[i] <= 231 - 1
 * nums[i] != nums[i + 1] for all valid i.
 * */

//Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Arrays
{
    [TestClass]
    public class _162_FindPeakElement
    {
        [TestMethod]
        public void Run()
        {
            int[] nums = [1, 2, 3, 1];
            FindPeakElement(nums);
        }

        // Use Binary search
        // TC - O(log n)
        // SC - O(1)
        // assumption, only one peak exists in the array
        // Fails if multipl peaks exists ex:[1 2 5 20 9 0 1 3 10 19 15 1], 20 should be highPeak, but binary search goes to right when mid=0 < mid+1=1 and stops at l=h=19
        public int FindPeakElement(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            int l = 0;
            int h = nums.Length - 1;
            while (l < h)
            {
                int mid = l + (h - l) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    h = mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return l;
        }


        // Brute force - O(n)
        // SC - O(1)
        // Can only find the peak value when has multiple peaks in O(n)
        public int FindPeakElement_OrderN(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            int peak = nums[0];
            int peakIndex = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > peak)
                {
                    peak = nums[i];
                    peakIndex = i;
                }
            }

            return peakIndex;
        }
    }
}
