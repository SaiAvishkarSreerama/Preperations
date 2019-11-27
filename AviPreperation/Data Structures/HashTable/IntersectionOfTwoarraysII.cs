using System;
using System.Collections.Generic;
using System.Text;
/*
*  Given two arrays, write a function to compute their intersection.
* 
* Example 1:
* 
* Input: nums1 = [1,2,2,1], nums2 = [2,2]
* Output: [2,2]
* Example 2:
* 
* Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
* Output: [4,9]
* Note:
* 
* Each element in the result should appear as many times as it shows in both arrays.
* The result can be in any order.
* Follow up:
* 
* What if the given array is already sorted? How would you optimize your algorithm?
* What if nums1's size is small compared to nums2's size? Which algorithm is better?
* What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?
 */
namespace AviPreperation.Data_Structures.HashTable
{
    public class Solution
    {
        //Time Complexity - O(m + n)
        //Space Complexity - O(m)
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            List<int> list = new List<int>();

            //push nums1 to disctionary and increment the value of that key if appear multiple times
            foreach (var v in nums1)
            {
                if (d.ContainsKey(v))
                    d[v]++;
                else
                    d.Add(v, 1);
            }

            //print the values of nums2 that consisted in nums1/dictionary untill that key value becomes 0
            foreach (var n in nums2)
            {
                if (d.ContainsKey(n) && d[n] > 0)
                {
                    list.Add(n);
                    d[n]--;
                }
            }

            return list.ToArray();
        }
    }
}
