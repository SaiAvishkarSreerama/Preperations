using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation
{
    public class _3SumClosestSolution
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            //TC - (n2 + nlogn) = O(n2);
            //SC - O(1)
            int closestSum = nums[0] + nums[1] + nums[nums.Length - 1];
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (Math.Abs(sum - target) < Math.Abs(closestSum - target))
                        closestSum = sum;
                    if (sum > target)
                        k--;
                    else
                        j++;
                }
            }
            return closestSum;
        }
    }
}
