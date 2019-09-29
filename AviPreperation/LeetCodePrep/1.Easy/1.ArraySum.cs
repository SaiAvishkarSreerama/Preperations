//Given an array of integers, return indices of the two numbers such that they add up to a specific target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.

//Example:
//Given nums = [2, 7, 11, 15], target = 9,
//Because nums[0] + nums[1] = 2 + 7 = 9,
//return [0, 1].

using System.Collections.Generic;
namespace AviPreperation.LeetCodePrep._1.Easy
{
    public class TwoSumSol
    {
        /********My Solution********* --> O(n^2) *****/
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = new int[] { };

            //verfying each element with other element for only ones
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result = new[] { i, j };
                        break;
                    }
                }
            }
            return result;
        }

        /********Recommended Solution********* --> O(n) *****/
        public int[] TwoSum1(int[] nums, int target)
        {
            //declare a dictionary sum
            var sum = new Dictionary<int, int>();

            //looping the given array
            for (int i = 0; i < nums.Length; i++)
            {
                //if the target - nums[i] whcih is our value is in Dictionary then returns that value
                //for i=0 --> Here intitially dictionary is empty, target-nums[i] will not find then inserting the key:num[i] and value:index into the dictioanry
                //for i=1 --> We already added nums[i] in it then if the target-nums[i] === num[0] that we inserted before then it treturns the nums[i]
                if (sum.ContainsKey(target - nums[i]))
                    return new int[] { sum[target - nums[i]], i };
                else
                    sum.Add(nums[i], i);
            }

            //if no such match found then return a empty integer array
            return new int[] { };
        }
    }
}