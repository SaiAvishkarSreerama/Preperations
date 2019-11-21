using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AviPreperation.Data_Structures.HashTable
{
    public class InterSectionOfTwoArraysSolution
    {
        // Time Complexity = O(n + m) - where n and m are length of both input arrays
        // space Complexity = O(n + m) - Worst case if both m and n has marching scenarios, so both willbe added to 
        //    both hashsets
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            int i = 0;
            HashSet<int> h = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            //Insert unique values from nums1 into h HashSet
            for (i = 0; i < nums1.Length; i++)
                if (!h.Contains(nums1[i]))//contains is O(1)
                    h.Add(nums1[i]);

            //Now compare each value form nums2 with hashset h
            //if found which means an intersection value found, add it to result hashset
            for (i = 0; i < nums2.Length; i++)
                if (h.Contains(nums2[i]))
                    result.Add(nums2[i]);

            return result.ToArray();
        }
    }
}
