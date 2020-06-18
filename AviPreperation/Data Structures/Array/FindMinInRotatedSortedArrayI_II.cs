using System;
using System.Collections.Generic;
using System.Text;

/*
* Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
* (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).
* 
* Find the minimum element.
* You may assume no duplicate exists in the array.
* 
* Example 1:
* Input: [3,4,5,1,2] 
* Output: 1
* 
* Example 2:
* Input: [4,5,6,7,0,1,2]
* Output: 0
* 
* 
* Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
* (i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).
* Find the minimum element.
* The array may contain duplicates.
* 
* Example 1:
* Input: [1,3,5]
* Output: 1
* 
* Example 2:
* Input: [2,2,2,0,1]
* Output: 0
* 
* Note:
* This is a follow up problem to Find Minimum in Rotated Sorted Array.
* Would allow duplicates affect the run-time complexity? How and why?
* * */
namespace AviPreperation.Data_Structures.Array
{
    public class FindMinInRotatedSortedArrayI_II_Solution
    {
        //TC - O(logN)
        //SC - O(1)
        public int FindMinI(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int min = int.MaxValue;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] >= nums[start])
                {
                    min = Math.Min(min, nums[start]);
                    start = mid + 1;
                }
                else
                {
                    min = Math.Min(min, nums[mid]);
                    end = mid - 1;
                }
            }

            return min;
        }


        //TC - O(logN)
        //SC - O(1)
        public int FindMinII(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int mid = 0;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] > nums[end])
                {
                    start = mid + 1;
                }
                else if (nums[mid] < nums[end])
                {
                    end = mid;
                }
                else
                {
                    end--;
                }
            }

            return nums[mid];
        }
    }
}
