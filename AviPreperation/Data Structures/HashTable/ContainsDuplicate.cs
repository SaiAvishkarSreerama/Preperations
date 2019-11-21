using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    class ContainsDuplicateSol
    {
        //Time Complexity - O(n)
        //Space complexity - O(n)
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> h = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (h.Contains(nums[i]))
                    return true;
                h.Add(nums[i]);
            }
            return false;
        }
    }
}
