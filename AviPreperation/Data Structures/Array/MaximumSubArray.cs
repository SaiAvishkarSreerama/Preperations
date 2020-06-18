using System;
using System.Collections.Generic;
using System.Text;
/*Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
* 
* Example:
* 
* Input: [-2,1,-3,4,-1,2,1,-5,4],
* Output: 6
* Explanation: [4,-1,2,1] has the largest sum = 6.
* Follow up:
* 
* If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
**/
namespace AviPreperation.Data_Structures.Array
{
    public class MaximumSubArraySolution
    {
        //TimeComplexity - O(N)
        //SpaceComplexity - O(1)
        public int MaxSubArray(int[] nums)
        {
            int curSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                curSum = Math.Max(curSum + nums[i], nums[i]);
                maxSum = Math.Max(curSum, maxSum);
            }

            return maxSum;
        }
    }
}
