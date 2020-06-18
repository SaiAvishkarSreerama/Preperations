using System;
using System.Collections.Generic;
using System.Text;
/*Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.

Example:

Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
Output: [3,3,5,5,6,7] 
Explanation: 

Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
Note:
You may assume k is always valid, 1 ≤ k ≤ input array's size for non-empty array.

Follow up:
Could you solve it in linear time?*/
namespace AviPreperation.Data_Structures.Array
{
    public class SlidingWindowMAxSolution
    {
        //Time Complexity - O(n * k)
        //Space Complexity - O(1)
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0)
                return new int[0];

            List<int> res = new List<int>();

            for (int i = 0; i <= nums.Length - k; i++)
            {
                int max = int.MinValue;
                int limit = i + k;
                for (int j = i; j < limit; j++)
                    max = Math.Max(max, nums[j]);
                res.Add(max);
            }

            return res.ToArray();
        }

        //Time Complexity - O(n)
        //Space Complexity - O(n)
        public int[] MaxSlidingWindow1(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 1)
                return nums;
            int n = nums.Length;

            //find left max
            int[] leftMax = new int[n];
            leftMax[0] = nums[0];

            //find right max
            int[] rightMax = new int[n];
            rightMax[n - 1] = nums[n - 1];

            //left and right max values
            for (int i = 1; i < n; i++)
            {
                leftMax[i] = i % k == 0 ? nums[i] : Math.Max(nums[i], leftMax[i - 1]);

                int j = n - i - 1; // coming from back
                rightMax[j] = (j + 1) % k == 0 ? nums[j] : Math.Max(nums[j], rightMax[j + 1]);
            }

            int[] res = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
                res[i] = Math.Max(rightMax[i], leftMax[i + k - 1]);

            return res;
        }
    }
}
