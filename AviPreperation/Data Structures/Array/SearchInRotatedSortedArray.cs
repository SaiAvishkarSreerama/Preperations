using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class SearchInRotatedSortedArraySolution
    {
        //TC - O(log n)
        // SC - O(1)
        public int SearchRotatedSortedArray(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                //if target == mid value
                if (target == nums[mid])
                    return mid;

                //if start < mid
                else if (nums[mid] >= nums[start])
                {
                    //in left half
                    //if start < target < mid then end moved to mid-1
                    //else start is mid+1
                    if (target >= nums[start] && target < nums[mid])
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                //if mid < end
                else
                {
                    if (target <= nums[end] && target > nums[mid])
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }

            return -1;
        }
    }
}
