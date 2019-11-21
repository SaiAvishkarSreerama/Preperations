using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class SingleNumberSol
    {
        //Time Complexity - O(n) - Linear - Traversing all values
        //Space complexity - O(1) - no extra space is using 
        public int SingleNumber(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res = res ^ nums[i]; // res ^= nums[i];
            }
            return res;
        }
    }
}
