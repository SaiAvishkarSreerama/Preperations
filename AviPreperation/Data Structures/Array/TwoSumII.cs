using System;
using System.Collections.Generic;
using System.Text;

/*
 * Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.

Note:

Your returned answers (both index1 and index2) are not zero-based.
You may assume that each input would have exactly one solution and you may not use the same element twice.
Example:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
 * */
namespace AviPreperation.Data_Structures.Array
{
    public class TwoSumIISolution
    {
        //Using Two pointers
        //Time Complexity - O(n)
        //Space Complexity - O(1)
        public int[] TwoSumII_1(int[] n, int t)
        {
            int l = 0;
            int r = n.Length - 1;
            while(l < r)
            {
                int res = n[l] + n[r];
                //Console.WriteLine("l - " + l + ", r =" + r + ", res =" + res);
                if (res == t)
                    return new int[] { l + 1, r + 1 };
                else if (res > t)
                    r--;
                else
                    l++;
            }
            return new int[2];
        }

        //TC - O(n)
        //SC - O(n)
        public int[] TwoSumII_2(int[] numbers, int target)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (d.ContainsKey(target - numbers[i]))
                {
                    return new int[] { d[target - numbers[i]], i + 1 };
                }
                else if (!d.ContainsKey(numbers[i]))
                {
                    d.Add(numbers[i], i + 1);
                }
            }

            return new int[0];
        }
    }
}
