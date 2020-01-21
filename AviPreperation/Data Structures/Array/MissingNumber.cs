using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class MissingNumberSolution
    {
        //Guass formula, sum of n natural num - sum of given array
        //TC - O(N)
        //SC - O(1)
        public int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            //since 0 is included sum of natural numbers (1,2,3,4,5...n) = n(n+1)/2
            int nSum = (n) * (n + 1) / 2;
            int sum = nums.Sum();

            return nSum - sum;
        }

        //USINg XOR (^), XOR(number and its index and so on finally with the length gives the given number)
        //TC - (n)
        //SC - O(1)
        public int MissingNumber1(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                missing = missing ^ i ^ nums[i];
            }
            return missing;
        }


        //approach 3: using a single hashset and add nums to it, iterate the hashset from i=0-->nums.Length, if hashSet does not contains i, ten return i; TC-O(n), SC-O(n)
    }
}
