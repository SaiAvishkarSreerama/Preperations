using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.Data_Structures.Array
{
    public class SearchInsertPosition
    {
        /***********Linear Search****************/
        //Time Complexity - O(n)
        //Space Complexity - O(1)
        // public int SearchInsert(int[] nums, int target) {
        //     for(int i=0; i<nums.Length; i++){
        //         if(nums[i] >= target)
        //             return i;
        //         else if(i == nums.Length - 1 && nums[i] < target)
        //             return i+1;
        //     }
        //     return -1;
        // }


        /***********Binary Search****************/
        //TimeComplexity - O(logn)
        //space Complexity - O(1)
        public static int SearchInsert(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (nums[mid] == target) return mid;
                else if (nums[mid] > target) high = mid - 1;
                else low = mid + 1;
            }
            return low;
        }

        //public static void Main()
        //{
        //    int[] num = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //    Console.WriteLine(SearchInsert(num, 5));
        //    Console.ReadLine();
        //}
    }
}
