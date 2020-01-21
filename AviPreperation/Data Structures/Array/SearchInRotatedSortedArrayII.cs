using System;
using System.Collections.Generic;
using System.Text;
/*Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
* 
* (i.e., [0,0,1,2,2,5,6] might become [2,5,6,0,0,1,2]).
* 
* You are given a target value to search. If found in the array return true, otherwise return false.
* 
* Example 1:
* 
* Input: nums = [2,5,6,0,0,1,2], target = 0
* Output: true
* Example 2:
* 
* Input: nums = [2,5,6,0,0,1,2], target = 3
* Output: false
* Follow up:
* 
* This is a follow up problem to Search in Rotated Sorted Array, where nums may contain duplicates.
* Would this affect the run-time complexity? How and why?
* */
namespace AviPreperation.Data_Structures.Array
{
    
    public class SearchInRotatedSortedArrayIISolution
    {
        public bool Search(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                //if target is mid value
                int mid = start + (end - start) / 2;

                //if target lies between start and mid
                if (target == nums[mid])
                    return true;

                //only diff for sorted I problem is duplicates
                //avoid duplicate by checking mid and start and end
                if (nums[start] == nums[mid] && nums[end] == nums[mid])
                {
                    start++;
                    end--;
                }
                else if (nums[mid] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (target <= nums[end] && target > nums[mid])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }

            return false;
        }
    }

}
